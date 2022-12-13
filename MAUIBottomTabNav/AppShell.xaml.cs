using MAUIBottomTabNav.Views;

namespace MAUIBottomTabNav;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(FirstPage), typeof(FirstPage));
		Routing.RegisterRoute(nameof(SecondPage), typeof(SecondPage));
		Routing.RegisterRoute(nameof(ThirdPage), typeof(ThirdPage));
		Routing.RegisterRoute(nameof(FourthPage), typeof(FourthPage));
		Routing.RegisterRoute(nameof(FifthPage), typeof(FifthPage));
	}
}
