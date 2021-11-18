using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interaction.Views;
using Avalonia.Markup.Xaml;

namespace Avalonia.Interaction
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                // this is the start window
                desktop.MainWindow = new SplashScreen();

            base.OnFrameworkInitializationCompleted();
        }
    }
}