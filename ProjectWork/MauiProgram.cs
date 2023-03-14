using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ProjectWork.Services.Core;
using ProjectWork.Utilities;
using ProjectWork.ViewModels.Artist;
using ProjectWork.ViewModels.Artwork;
using ProjectWork.ViewModels.Core;
#if WINDOWS
using Microsoft.Maui.LifecycleEvents;
#endif

namespace ProjectWork;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        //To disable the default conversion to https
        Environment.SetEnvironmentVariable("WEBVIEW2_ADDITIONAL_BROWSER_ARGUMENTS", "--unsafely-treat-insecure-origin-as-secure=http://51.103.212.24:80");


        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton(x => new DRFAuthentication(new ServiceAPI(
            Endpoints.SiteUrl, new ImageOptions
            {
                FileName = "profile_picture"
            })));


        builder.Services.AddScoped<SearchArtworkVM>();
        builder.Services.AddScoped<DashboardAdminArtworkVM>();

        builder.Services.AddScoped<SearchArtistVM>();
        builder.Services.AddScoped<DashboardAdminArtistVM>();

#if WINDOWS
        builder.ConfigureLifecycleEvents(events =>
        {

            events.AddWindows(windowsLifecycleBuilder =>
            {
                windowsLifecycleBuilder.OnWindowCreated(window =>
                {
                    window.ExtendsContentIntoTitleBar = true;
                    var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
                    var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
                    switch (appWindow.Presenter)
                    {
                        case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
                            overlappedPresenter.SetBorderAndTitleBar(true, true);
                            overlappedPresenter.Maximize();
                            break;
                    }
                });
            });
        });
#endif
        return builder.Build();
    }
}