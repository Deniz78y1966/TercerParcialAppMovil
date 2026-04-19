using Parcial13_GaleriaMusical.Models;
using Parcial13_GaleriaMusical.ViewModels;

namespace Parcial13_GaleriaMusical;

public partial class PlayerPage : ContentPage
{
    public PlayerPage(MediaPlayerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnSongSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Song song && BindingContext is MediaPlayerViewModel viewModel)
        {
            viewModel.CurrentSong = song;
        }
    }
}