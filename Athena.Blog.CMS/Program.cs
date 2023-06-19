using AntDesign.ProLayout;
using System;
using System.Net.Http;
using Athena.Blog.CMS;
using Athena.Blog.CMS.AuthProvider;
using Athena.Blog.CMS.HttpRepositories;
using Athena.Blog.CMS.HttpRepositories.Impl;
using Athena.Blog.CMS.Services;
using Athena.Blog.CMS.Services.Impl;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var configuration = builder.Configuration;

builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"] ??
                          throw new InvalidOperationException("API Config not found"))
});
builder.Services.AddAntDesign();
builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

await builder.Build().RunAsync();