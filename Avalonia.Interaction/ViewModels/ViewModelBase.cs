using System;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Notifications;
using Avalonia.Interaction.Controls;
using Avalonia.Interaction.Views;
using Avalonia.Threading;
using ReactiveUI;

namespace Avalonia.Interaction.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        #region Private Deklaration

        private const int NotificationDefaultExpirationSeconds = 7;

        #endregion

        #region Helper

        private Window? FindCurrentActiveWindow()
        {
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop &&
                desktop.Windows.Count > 0)
            {
                var active = desktop.Windows.FirstOrDefault(window => window.IsActive);
                return active ?? desktop.Windows[0];
            }
            return null;
        }

        private MainWindow? FindCurrentActiveMainWindow()
        {
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop &&
                desktop.Windows.Count > 0)
                return desktop.Windows.First(window => window.GetType() == typeof(MainWindow) && window.IsActive) as
                    MainWindow;
            return null;
        }

        #endregion

        #region Notifition Show - Base method

        private void ShowNotification(string header, string message, NotificationType type,
            int expiration = NotificationDefaultExpirationSeconds)
        {
            if (FindCurrentActiveMainWindow() is { } mainWindow)
                mainWindow.NotificationManager.Show(
                    new Notification(
                        header, message, type, TimeSpan.FromSeconds(expiration)));
        }

        internal void ShowNotificationInfo(string header, string message,
            int expirations = NotificationDefaultExpirationSeconds)
        {
            ShowNotification(header, message, NotificationType.Information, expirations);
        }

        internal void ShowNotificationWarning(string header, string message,
            int expirations = NotificationDefaultExpirationSeconds)
        {
            ShowNotification(header, message, NotificationType.Warning, expirations);
        }

        internal void ShowNotificationError(string header, string message,
            int expirations = NotificationDefaultExpirationSeconds)
        {
            ShowNotification(header, message, NotificationType.Error, expirations);
        }

        internal void ShowNotificationSuccess(string header, string message,
            int expirations = NotificationDefaultExpirationSeconds)
        {
            ShowNotification(header, message, NotificationType.Success, expirations);
        }

        #endregion

        #region Dialog

        protected Task ShowDialogInfo(string header, string content = "", string btn = "Ok")
        {
            return ShowDialog(header, content, btn, "", "");
        }

        protected Task ShowDialogAlert(string header, string content = "", string btn = "Ok")
        {
            return ShowDialog(header, content, btn, "", "", DialogType.Alert);
        }

        protected Task<DialogAnswer> ShowDialogQuestion(string header, string content, string btnAnswerA,
            string btnAnswerB)
        {
            return ShowDialog(header, content, "", btnAnswerA, btnAnswerB, DialogType.Question);
        }

        protected Task<DialogAnswer> ShowDialogQuestionAlert(string header, string content, string btnAnswerA,
            string btnAnswerB)
        {
            return ShowDialog(header, content, "", btnAnswerA, btnAnswerB, DialogType.QuestionAlert);
        }

        private Task<DialogAnswer> ShowDialog(string header, string content, string btn = "Ok", string btnAnswerA = "A",
            string btnAnswerB = "B", DialogType type = DialogType.Information)
        {
            var window = FindCurrentActiveWindow();
            var dialog = new DialogWindow(header, content, btn, btnAnswerA, btnAnswerB, type, window);
            return dialog.ShowDialog<DialogAnswer>(window);
        }

        #endregion
    }
}