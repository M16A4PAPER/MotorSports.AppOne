using MotorSports.AppOne.Services;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace MotorSports.AppOne.Views
{
    public partial class AssignRolePage : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();

        public AssignRolePage()
        {
            InitializeComponent();
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            if (int.TryParse(UserIdEntry.Text?.Trim(), out int userId) && int.TryParse(RoleIdEntry.Text?.Trim(), out int roleId))
            {
                string response = await _apiService.AssignRoleToUser(userId, roleId);
                await DisplayAlert("API Response", response, "OK");
            }
            else
            {
                await DisplayAlert("Error", "Invalid input. Please enter valid integer values for User ID and Role ID.", "OK");
            }
        }

    }
}
