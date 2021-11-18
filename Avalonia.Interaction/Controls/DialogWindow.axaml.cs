using System;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Markup.Xaml;

namespace Avalonia.Interaction.Controls
{
    public enum DialogType
    {
        Information,
        Question,
        Alert,
        QuestionAlert
    }

    public enum DialogAnswer
    {
        Ok,
        AnswerA,
        AnswerB
    }

    [PseudoClasses("alert")]
    public class DialogWindow : Window
    {
        private readonly Grid _grid;
        private readonly Window? _parent;

        public DialogWindow(string header, string content, string btn = "Ok", string btnAnswerA = "A",
            string btnAnswerB = "B", DialogType type = DialogType.Information, Window? parent = null)
        {
            DialogType = type;
            _parent = parent;

            InitializeComponent();
            DataContext = this;
            Opened += (s, e) => WindowHeightHack();
#if DEBUG
            this.AttachDevTools();
#endif
            _grid = this.FindControl<Grid>("PartGrid");
            var txtHeader = this.FindControl<TextBlock>("PartHeader");
            var txtContent = this.FindControl<TextBlock>("PartContent");
            var btnOk = this.FindControl<Button>("PartBtnOk");
            var btnA = this.FindControl<Button>("PartBtnAnswerA");
            var btnB = this.FindControl<Button>("PartBtnAnswerB");

            txtHeader.Text = header;
            txtContent.Text = content;
            btnOk.Content = btn;
            btnOk.IsVisible = type is DialogType.Information or DialogType.Alert;
            btnA.Content = btnAnswerA;
            btnA.IsVisible = type is DialogType.Question or DialogType.QuestionAlert;
            btnB.Content = btnAnswerB;
            btnB.IsVisible = type is DialogType.Question or DialogType.QuestionAlert;

            if(type == DialogType.QuestionAlert)
            {
                txtHeader.Classes.Add("alert");
                btnB.Classes.Remove("answerB");
                btnB.Classes.Add("alert");
            }
            else if (type == DialogType.Alert)
            {
                txtHeader.Classes.Add("alert");
                btnOk.Classes.Remove("ok");
                btnOk.Classes.Add("alert");
            }
        }

        public DialogWindow() : this("Header", "Content")
        {
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void CloseDialog(DialogAnswer answer)
        {
            Close(answer);
        }

        private void WindowHeightHack()
        {
            // set the window size manual because Window.Height = Auto not working currently
            Height = Math.Min(_grid.DesiredSize.Height, 500);
            // set window position manually to parent window center
            if (_parent != null)
                Position = new PixelPoint(
                    (int)(_parent.Position.X + (_parent.Bounds.Width - Width) / 2.0),
                    (int)(_parent.Position.Y + (_parent.Bounds.Height - Height) / 2.0));
            // show window, hide object in init to avoid ugly scaling effect
            Opacity = 1;
        }

        #region Private Deklaration

        #endregion

        #region Public Deklaration

        public static readonly StyledProperty<DialogType> DialogTypeProperty =
            AvaloniaProperty.Register<DialogWindow, DialogType>(nameof(DialogTypeProperty));

        public DialogType DialogType
        {
            get => GetValue(DialogTypeProperty);
            init => SetValue(DialogTypeProperty, value);
        }

        public bool IsInformationDialog => DialogType == DialogType.Information;
        public bool IsQuestionDialog => DialogType == DialogType.Question;

        #endregion
    }
}