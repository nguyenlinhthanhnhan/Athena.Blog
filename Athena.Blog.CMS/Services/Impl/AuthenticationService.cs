using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Athena.Blog.CMS.AuthProvider;
using Athena.Blog.CMS.Helpers;
using Athena.Blog.CMS.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Athena.Blog.CMS.Services.Impl;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly ILocalStorageService _localStorage;

    public AuthenticationService(HttpClient httpClient,
        ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<AuthResponseDto> Authenticate(AuthRequestDto request)
    {
        var response = await _httpClient.PostAsJsonAsync(ApiUris.Authentication.Authenticate, request);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            var error = JsonSerializer.Deserialize<ApiException>(content, _jsonSerializerOptions);
            throw error;
        }

        var authResponse = JsonSerializer.Deserialize<AuthResponseDto>(content, _jsonSerializerOptions);
        await _localStorage.SetItemAsync("accessToken", authResponse.AccessToken);
        await _localStorage.SetItemAsync("refreshToken", authResponse.RefreshToken);

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("bearer", authResponse.AccessToken);

        return authResponse;
    }

    public async Task<string> RefreshToken()
    {
        var token = await _localStorage.GetItemAsync<string>("accessToken");
        var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");

        var response = await _httpClient.GetAsync($"token/refresh?refreshToken={refreshToken}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            var error = JsonSerializer.Deserialize<ApiException>(content, _jsonSerializerOptions);
            throw error;
        }
        
        var result = JsonSerializer.Deserialize<AuthResponseDto>(content, _jsonSerializerOptions);
        await _localStorage.SetItemAsync("authToken", result.AccessToken);
        await _localStorage.SetItemAsync("refreshToken", result.RefreshToken);

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.AccessToken);
        return result.AccessToken;
    }
}