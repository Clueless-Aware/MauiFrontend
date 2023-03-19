using Microsoft.AspNetCore.Components.WebView;
using ProjectWork.Utilities;

namespace ProjectWork;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;
        if (accessType == NetworkAccess.Internet) return;
        UtilityToolkit.CreateToast("Internet Connection Required, Try Later");
        App.Current.Quit();
        System.Environment.Exit(0);
    }

    private void Bwv_BlazorWebViewInitialized(object sender, BlazorWebViewInitializedEventArgs e)
    {
#if ANDROID
          e.WebView.Settings.MixedContentMode = Android.Webkit.MixedContentHandling.AlwaysAllow;
#endif
    }
}