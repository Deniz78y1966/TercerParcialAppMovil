namespace Parcial13_GaleriaMusical
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(PlayerPage), typeof(PlayerPage));
        }
    }
}
