using Microsoft.Maui.Controls;
using MotorSports.AppOne.Services;
using MotorSports.AppOne.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorSports.AppOne.Views
{
    public partial class ManageUsersAndRoles : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();

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
            await Navigation.PushAsync(new AssignRolePage());
        }

        private async void RemoveRole_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RemoveUserRoles());
        }

        private async void ViewUsersRoles_Click(object sender, EventArgs e)
        {
            try
            {
                var usersRolesList = await _apiService.GetUsersAndRoles() ?? new List<UserRole>();
                await Navigation.PushAsync(new ViewUsersRoles(usersRolesList)); 
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load users and roles: {ex.Message}", "OK");
            }
        }
    }
}
