using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interaction.Controls;
using Avalonia.Interaction.Views;

namespace Avalonia.Interaction.ViewModels
{
    public class SplashScreenViewModel : ViewModelBase
    {
        public SplashScreenViewModel()
        {
           
        }

        public void Test()
        {
            ShowDialogInfo("SIE WERDEN NUN EINGELOGGT");
        }
        public async void Cancel()
        {
            var answer = await ShowDialogQuestion("Suite beenden ?", "Möchten Sie die Suite wirklich beenden ?", "Nein",
                "BEENDEN");
            if (answer == DialogAnswer.AnswerB)
                if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                    desktop.Shutdown();
        }

        public async void Login()
        {
            await Task.Delay(1000);
            await ShowDialogInfo("SIE WERDEN NUN EINGELOGGT");
            
            // start a new "main" window for the application
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainWin = new MainWindow();
                desktop.MainWindow = mainWin;
                mainWin.Show();

                var splash = desktop.Windows.First<Window>(w => w.GetType() == typeof(SplashScreen));
                splash.Close();
            }
        }
    }
}