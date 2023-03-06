using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProjectWork.Models.Artwork;
using ProjectWork.Resources.Static;
using ProjectWork.Services.Core;
using ProjectWork.ViewModels;
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
        Environment.SetEnvironmentVariable("WEBVIEW2_ADDITIONAL_BROWSER_ARGUMENTS", "--disable-features=AutoupgradeMixedContent");




        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<DRFAuthentication>(x => new DRFAuthentication(new ServiceAPI(Endpoints.getAccountEndpoint())));


        builder.Services.AddScoped<SearchArtworkVM>();
        builder.Services.AddScoped<DashboardAdminVM>();

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
