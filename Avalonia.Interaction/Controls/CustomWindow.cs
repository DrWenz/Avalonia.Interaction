using System;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.VisualTree;

namespace Avalonia.Interaction.Controls
{
    public class CustomWindow : Window
    {
        public static readonly StyledProperty<ICommand> LoadedCommandProperty =
            AvaloniaProperty.Register<CustomWindow, ICommand>(nameof(LoadedCommand));

        public CustomWindow()
        {
            NotificationManager = new WindowNotificationManager(this)
            {
                Position = NotificationPosition.BottomRight,
                MaxItems = 30
            };
            Opened += OnOpened;
        }

        public INotificationManager NotificationManager { get; }

        public ICommand LoadedCommand
        {
            get => GetValue(LoadedCommandProperty);
            init => SetValue(LoadedCommandProperty, value);
        }

        private void OnOpened(object? sender, EventArgs e)
        {
            LoadedCommand?.Execute(null);
        }

        public void SetFocusOnElement(string controlName)
        {
            var control = this.FindControl<TextBox>("TxtUserName");
            if (control == null)
                return;
            if(control.GetVisualRoot() != null)
                control.Focus();
            else
                control.AttachedToVisualTree += (s, e) => control.Focus();
        }
    }
}