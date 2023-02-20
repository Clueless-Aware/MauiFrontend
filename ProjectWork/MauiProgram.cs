using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ProjectWork.Data.ViewModels;

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

        builder.Services.AddSingleton<ArtworkViewModel>();
        builder.Services.AddSingleton<AccountViewModel>();

        return builder.Build();
    }
}