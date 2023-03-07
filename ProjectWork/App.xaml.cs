using ProjectWork.ViewModels.Core;

namespace ProjectWork;

public partial class App : Application
{
	public static DRFAuthentication Authentication { get; private set; }
	public App(DRFAuthentication authentication)
	{
		InitializeComponent();

		MainPage = new MainPage();

		Authentication = authentication;
	}
}
