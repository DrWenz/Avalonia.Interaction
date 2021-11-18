using Avalonia;
using Avalonia.Controls;
using Avalonia.Interaction.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Avalonia.Interaction.Views
{
    public class SplashScreen : CustomWindow
    {
        public SplashScreen()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
            
            SetFocusOnElement("TxtUserName");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            SetFocusOnElement("TxtUserName");
        }
    }
}