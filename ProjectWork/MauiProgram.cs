using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ProjectWork.Data;
using ProjectWork.Data.Services;
using ProjectWork.Data.ViewModels;
using Microsoft.Maui.LifecycleEvents;

namespace ProjectWork;

public static class MauiProgram
{


    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });




        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<ArtworkViewModel>();
        builder.Services.AddSingleton<AccountViewModel>();

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
