using Microsoft.AspNetCore.Components.WebView;
using ProjectWork.Utilities;

namespace ProjectWork;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        var accessType = Connectivity.Current.NetworkAccess;
        if (accessType == NetworkAccess.Internet) return;
        UtilityToolkit.CreateToast("Internet Connection Required, Try Later");
        Application.Current.Quit();
        Environment.Exit(0);
    }

    private void Bwv_BlazorWebViewInitialized(object sender, BlazorWebViewInitializedEventArgs e)
    {
    }
}