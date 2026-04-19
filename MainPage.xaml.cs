using Parcial13_GaleriaMusical.Models;
using Parcial13_GaleriaMusical.Services;
using Parcial13_GaleriaMusical.ViewModels;

namespace Parcial13_GaleriaMusical;

public partial class MainPage : ContentPage
{
    private readonly DatabaseService _db;

    public MainPage(DatabaseService db)
    {
        InitializeComponent();
        _db = db;
        _ = LoadSongs();
    }

    private async Task LoadSongs()
    {
        var songs = await _db.GetSongsAsync();
        SongsListView.ItemsSource = songs;
        StatusLabel.Text = $"📱 Database: {songs.Count} songs loaded";
    }

    private async void OnAddSampleSongClicked(object sender, EventArgs e)
    {
        var song = new Song
        {
            Title = $"Rock Anthem {DateTime.Now:HH:mm:ss}",
            Artist = "Demo Artist",
            FileName = "demo_rock.mp3",
            DurationSeconds = new Random().Next(180, 240)
        };
        await _db.SaveSongAsync(song);
        await LoadSongs();
#pragma warning disable CS0618
        await DisplayAlert("✅", $"Added: {song.Title}", "OK");
    }

    private async void OnLoadSongsClicked(object sender, EventArgs e)
    {
        await LoadSongs();
    }

    private async void OnDeleteSongInvoked(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && swipeItem.BindingContext is Song song)
        {
            await _db.DeleteSongAsync(song);
            await LoadSongs();
            await DisplayAlert("🗑️", "Song deleted from database!", "OK");
#pragma warning restore CS0618
        }
    }
    private void OnToggleThemeClicked(object sender, EventArgs e)
    {
        Parcial13_GaleriaMusical.App.ToggleTheme();

        // Visual feedback
        var button = sender as Button;
        var isDark = Parcial13_GaleriaMusical.App.IsDarkMode;

        ThemeToggleButton.Text = isDark ? "🌙 Dark Mode" : "☀️ Light Mode";
        StatusLabel.Text = $"🎨 Theme switched to {(isDark ? "Dark 🌙" : "Light ☀️")}!";
    }

    // ✅ NEW: Go to Player Page
    private async void OnGoToPlayerClicked(object sender, EventArgs e)
    {
        var viewModel = new MediaPlayerViewModel();
        await Navigation.PushAsync(new PlayerPage(viewModel));
    }
}