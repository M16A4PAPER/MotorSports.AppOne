using Microsoft.Maui.Controls;

namespace MotorSports.AppOne.Views
{
    public partial class ManageUsersAndRoles : ContentPage
    {
        public ManageUsersAndRoles()
        {
            InitializeComponent();
        }

        private async void GoBack_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void AssignRole_Click(object sender, EventArgs e)
        {
            await DisplayAlert("Not Implemented", "The API for Assign Role is not available.", "OK");
        }

        private async void RemoveRole_Click(object sender, EventArgs e)
        {
            await DisplayAlert("Not Implemented", "The API for Remove Role is not available.", "OK");
        }

        private async void ViewUsersRoles_Click(object sender, EventArgs e)
        {
            await DisplayAlert("Not Implemented", "The API for Viewing Users and Roles is not available.", "OK");
        }
    }
}
