using Microsoft.Maui.Controls;
using System;

namespace MotorSports.AppOne.Views
{
    public partial class AssignPositionPage : ContentPage
    {
        public AssignPositionPage()
        {
            InitializeComponent();
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
