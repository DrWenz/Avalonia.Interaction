using Avalonia.Interaction.Controls;

namespace Avalonia.Interaction.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public void TestShowNotificationSuccess()
        {
            ShowNotificationSuccess("Erfolgreiche Nachricht",
                "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea");
        }

        public void TestShowNotificationInfo()
        {
            ShowNotificationInfo("Sie haben etwas geklickt",
                "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea");
        }

        public void TestShowNotificationWarning()
        {
            ShowNotificationWarning("Warnung - fast n Fehler",
                "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea");
        }

        public void TestShowNotificationError()
        {
            ShowNotificationError("Critical Error",
                "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea");
        }

        public void TestShowDialogInfo()
        {
            ShowDialogInfo("Titel des Dialoges",
                "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea");
        }

        public void TestShowDialogError()
        {
            ShowDialogAlert("Titel des Dialoges Type Alert",
                "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea",
                "VERSTANDEN");
        }

        public async void TestShowDialogQuestion()
        {
            var answer = await ShowDialogQuestion("Wichtige Frage !",
                "Was möchten Sie heute essen ?",
                "SCHNITZEL", "STEAK");
            if (answer == DialogAnswer.AnswerA)
                ShowNotificationWarning("Leider ...", "Sind alle Schnitzel aus :(");
            else
                ShowNotificationSuccess("Guute Wahl :)", "Ihr Steak wird in kürze geliefert. Bon Appetit.");
        }
        
        public async void TestShowDialogQuestionAlert()
        {
            var answer = await ShowDialogQuestionAlert("Datensatz löschen ?",
                "Möchten Sie diesen Datensatz wirklich löschen ? Kann nicht rückgängig gemacht werden",
                "ABBRECHEN", "LÖSCHEN");
            if (answer == DialogAnswer.AnswerA)
                ShowNotificationInfo("ok :)", "Datensatz wird nicht gelöscht !");
            else
                ShowNotificationSuccess("ALLES KLAR!", "Datensatz wurde erfolgreich gelöscht !!!");
        }
    }
}