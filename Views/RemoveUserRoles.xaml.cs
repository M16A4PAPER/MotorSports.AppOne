using Microsoft.Maui.Controls;
using MotorSports.AppOne.Services;
using System;

namespace MotorSports.AppOne.Views
{
    public partial class RemoveUserRoles : ContentPage
    {
        public RemoveUserRoles()
        {
            InitializeComponent();
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); 
        }

        private readonly ApiService _apiService = new ApiService();

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            if (int.TryParse(UserIdEntry.Text?.Trim(), out int userId) && int.TryParse(RoleIdEntry.Text?.Trim(), out int roleId))
            {
                string response = await _apiService.RemoveUserRole(userId, roleId);
                await DisplayAlert("API Response", response, "OK");
            }
            else
            {
                await DisplayAlert("Error", "Invalid input. Please enter valid integer values for User ID and Role ID.", "OK");
            }
        }

    }
}
