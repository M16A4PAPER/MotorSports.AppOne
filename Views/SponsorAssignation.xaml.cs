using MotorSports.AppOne.Services;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace MotorSports.AppOne.Views
{
    public partial class SponsorAssignation : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();

        public SponsorAssignation()
        {
            InitializeComponent();
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            // Disable submit button to prevent multiple submissions
            btnSubmit.IsEnabled = false;
            lblMessage.Text = string.Empty;

            try
            {
                // Get user input
                string eventIdText = txtEventId.Text?.Trim();
                string sponsorIdText = txtSponsorId.Text?.Trim();

                // Validate input
                if (string.IsNullOrWhiteSpace(eventIdText) || string.IsNullOrWhiteSpace(sponsorIdText))
                {
                    DisplayError("Both fields are required!");
                    return;
                }

                if (!int.TryParse(eventIdText, out int eventId) || !int.TryParse(sponsorIdText, out int sponsorId))
                {
                    DisplayError("Event ID and Sponsor ID must be numbers!");
                    return;
                }

                // Call API to assign sponsor
                string response = await _apiService.AssignSponsorToEvent(eventId, sponsorId);

                if (!string.IsNullOrEmpty(response) && !response.StartsWith("Error:"))
                {
                    DisplaySuccess("Sponsor assigned successfully!");
                }
                else
                {
                    DisplayError(response ?? "Failed to assign sponsor.");
                }
            }
            catch (Exception ex)
            {
                DisplayError($"Unexpected error: {ex.Message}");
            }
            finally
            {
                // Re-enable submit button
                btnSubmit.IsEnabled = true;
            }
        }

        private void DisplayError(string message)
        {
            lblMessage.TextColor = Colors.Red;
            lblMessage.Text = message;
        }

        private void DisplaySuccess(string message)
        {
            lblMessage.TextColor = Colors.Green;
            lblMessage.Text = message;
        }

        private async void GoBackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
