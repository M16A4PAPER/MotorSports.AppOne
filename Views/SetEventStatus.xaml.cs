using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using MotorSports.AppOne.Services;

namespace MotorSports.AppOne.Views
{
    public partial class SetEventStatus : ContentPage
    {
        public SetEventStatus()
        {
            InitializeComponent();
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Submitted", "Event status updated!", "OK");
        }
    }
}
