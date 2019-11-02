using System;
using Xamarin.Forms;

namespace MatchFinder
{
    // singleton pattern
    public sealed class Frontend
    {
        private static readonly Frontend instance = new Frontend();

        private Label mainLabel;
        public Label MainLabel { get => mainLabel; set => mainLabel = value; }

        static Frontend() { }
        private Frontend() { }
        public static Frontend Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadMainLabel(Label label) => mainLabel = label;

        public void ChangeMainLabelText(string text) => mainLabel.Text = text;
    }   
}
