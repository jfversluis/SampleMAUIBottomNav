using MAUIBottomTabNav.Views;
using Microsoft.Extensions.Logging;

namespace MAUIBottomTabNav;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<FirstPage>();
		builder.Services.AddSingleton<SecondPage>();
		builder.Services.AddSingleton<ThirdPage>();
		builder.Services.AddSingleton<FourthPage>();
		builder.Services.AddSingleton<FifthPage>();

		return builder.Build();
	}
}
