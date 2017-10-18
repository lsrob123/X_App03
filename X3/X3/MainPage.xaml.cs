using System;
using X3.Views;
using Xamarin.Forms;

namespace X3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Page1Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }
    }
}