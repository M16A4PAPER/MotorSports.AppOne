using Microsoft.Maui.Controls;
using MotorSports.AppOne.Models;
using MotorSports.AppOne.Services;
using System;
using System.Threading.Tasks;

namespace MotorSports.AppOne.Views
{
    public partial class RaceRegistrationPage : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();

        public RaceRegistrationPage()
        {
            InitializeComponent();
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            // Get values from input fields
            if (!int.TryParse(TeamIdEntry.Text, out int teamId) || !int.TryParse(EventIdEntry.Text, out int eventId))
            {
                await DisplayAlert("Error", "Please enter valid numeric values.", "OK");
                return;
            }

            // Create request model
            var registration = new RaceRegistration
            {
                TeamId = teamId,
                EventId = eventId
            };

            // Call API
            string response = await _apiService.RegisterTeamForRace(registration);

            // Show success or failure message
            if (!response.Contains("Error"))
            {
                await DisplayAlert("Success", "Team registered successfully!", "OK");
            }
            else
            {
                await DisplayAlert("Error", response, "OK");
            }
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
