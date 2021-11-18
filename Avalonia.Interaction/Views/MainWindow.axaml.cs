using Avalonia.Interaction.Controls;
using Avalonia.Markup.Xaml;

namespace Avalonia.Interaction.Views
{
    public class MainWindow : CustomWindow
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}