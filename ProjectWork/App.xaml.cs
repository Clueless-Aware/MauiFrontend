using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using ProjectWork.ViewModels.Core;
using Application = Microsoft.Maui.Controls.Application;

namespace ProjectWork;

public partial class App : Application
{
	public static DRFAuthentication Authentication { get; private set; }
	public App(DRFAuthentication authentication)
	{
		InitializeComponent();

		MainPage = new MainPage();

		Authentication = authentication;

        App.Current.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
    }
}
