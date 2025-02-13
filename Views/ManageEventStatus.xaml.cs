using Microsoft.Maui.Controls;

namespace MotorSports.AppOne.Views
{
    public partial class ManageEventStatus : ContentPage
    {
        public ManageEventStatus()
        {
            InitializeComponent();
        }

        private async void SetEventStatus_Click(object sender, EventArgs e)
        {
            await DisplayAlert("Not Implemented", "The API for Setting Event Status is not available.", "OK");
        }

        private async void ViewEventStatus_Click(object sender, EventArgs e)
        {
            await DisplayAlert("Not Implemented", "The API for Viewing Event Status is not available.", "OK");
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
