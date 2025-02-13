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
            await Navigation.PushAsync(new SetEventStatus());
        }

        private async void ViewEventStatus_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewEventStatus());
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
