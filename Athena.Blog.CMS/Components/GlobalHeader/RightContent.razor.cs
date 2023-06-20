﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AntDesign;
using AntDesign.ProLayout;
using Athena.Blog.CMS.Services;
using Microsoft.AspNetCore.Components;

namespace Athena.Blog.CMS.Components;

public partial class RightContent
{
    [Inject] public IAuthenticationService AuthenticationService { get; set; }

    private NoticeIconData[] _notifications = { };
    private NoticeIconData[] _messages = { };
    private NoticeIconData[] _events = { };
    private readonly int _count = 0;

    private List<AutoCompleteDataItem<string>> DefaultOptions { get; set; } = new List<AutoCompleteDataItem<string>>
    {
        new AutoCompleteDataItem<string>
        {
            Label = "umi ui",
            Value = "umi ui"
        },
        new AutoCompleteDataItem<string>
        {
            Label = "Pro Table",
            Value = "Pro Table"
        },
        new AutoCompleteDataItem<string>
        {
            Label = "Pro Layout",
            Value = "Pro Layout"
        }
    };

    public AvatarMenuItem[] AvatarMenuItems { get; set; } =
    {
        new() { Key = "center", IconType = "user", Option = "Profile" },
        new() { Key = "setting", IconType = "setting", Option = "Setting" },
        new() { IsDivider = true },
        new() { Key = "logout", IconType = "logout", Option = "Logout" }
    };

    [Inject] protected NavigationManager NavigationManager { get; set; }

    [Inject] protected MessageService MessageService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        SetClassMap();
    }

    protected void SetClassMap()
    {
        ClassMapper
            .Clear()
            .Add("right");
    }

    public async Task HandleSelectUser(MenuItem item)
    {
        switch (item.Key)
        {
            case "center":
                NavigationManager.NavigateTo("/account/center");
                break;
            case "setting":
                NavigationManager.NavigateTo("/account/settings");
                break;
            case "logout":
                await AuthenticationService.Logout();
                NavigationManager.NavigateTo("/login", forceLoad: true);
                break;
        }
    }

    public void HandleSelectLang(MenuItem item)
    {
    }

    public async Task HandleClear(string key)
    {
        switch (key)
        {
            case "notification":
                _notifications = new NoticeIconData[] { };
                break;
            case "message":
                _messages = new NoticeIconData[] { };
                break;
            case "event":
                _events = new NoticeIconData[] { };
                break;
        }

        await MessageService.Success($"{key} has been cleared");
    }

    public async Task HandleViewMore(string key)
    {
        await MessageService.Info("Click on view more");
    }
}