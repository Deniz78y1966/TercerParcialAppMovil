using CommunityToolkit.Maui;
using Parcial13_GaleriaMusical.Services;
using Parcial13_GaleriaMusical.ViewModels;

namespace Parcial13_GaleriaMusical;

public static class MauiAppProgram
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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // ✅ .NET 10 FIX: Use Environment
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "music.db");
        builder.Services.AddSingleton(new DatabaseService(dbPath));
        builder.Services.AddTransient<MediaPlayerViewModel>();

        return builder.Build();
    }
}