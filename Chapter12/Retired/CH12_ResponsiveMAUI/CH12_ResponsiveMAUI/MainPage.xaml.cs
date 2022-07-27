using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace CH12_ResponsiveMAUI
{
    public partial class MainPage : ContentPage
    {
        private string _message;
        private int _count;

        public MainPage()
        {
            InitializeComponent();
            MessageLabelProperty = "MAUI looks promising!";
        }

        public string MessageLabelProperty
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(MessageLabelProperty));
            }
        }

        private void SetSemanticFocusButton_Clicked(object sender, EventArgs e)
        {
            SemanticFocusLabel.SetSemanticFocus();
            SemanticFocusLabel.Text = "Received semantic focus";
        }

        public void MakeAnnouncementButton_Clicked(object sender, EventArgs e)
        {
            SemanticScreenReader.Announce("Make your applications accessible to MAUI users!");
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            _count++;
            CounterLabel.Text = $"Current count: {_count}";
        }
    }
}
