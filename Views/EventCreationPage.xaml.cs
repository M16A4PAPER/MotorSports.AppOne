using MotorSports.AppOne.Models;
using MotorSports.AppOne.Services;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace MotorSports.AppOne.Views
{
    public partial class EventCreationPage : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();

        public EventCreationPage()
        {
            InitializeComponent();
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            // Get user input
            string eventName = txtEventName.Text?.Trim();
            string venueId = txtVenueId.Text?.Trim();
            string eventDate = txtEventDate.Text?.Trim();
            string totalLaps = txtTotalLaps.Text?.Trim();
            string statusId = txtStatusId.Text?.Trim();

            // Validate input
            if (string.IsNullOrWhiteSpace(eventName) || string.IsNullOrWhiteSpace(venueId) ||
                string.IsNullOrWhiteSpace(eventDate) || string.IsNullOrWhiteSpace(totalLaps) ||
                string.IsNullOrWhiteSpace(statusId))
            {
                lblMessage.Text = "All fields are required!";
                return;
            }

            if (!int.TryParse(venueId, out int venue) || !int.TryParse(totalLaps, out int laps) || !int.TryParse(statusId, out int status))
            {
                lblMessage.Text = "Venue ID, Total Laps, and Status ID must be numbers!";
                return;
            }

            if (!DateTime.TryParseExact(eventDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                lblMessage.Text = "Invalid date format! Use yyyy-mm-dd.";
                return;
            }

            // Create event DTO
            var eventRequest = new EventCreationRequest
            {
                EventName = eventName,
                VenueId = venue,
                EventDate = parsedDate,
                TotalLaps = laps,
                StatusId = status
            };

            string response = await _apiService.CreateEvent(eventRequest);

            if (!string.IsNullOrEmpty(response))
            {
                lblMessage.TextColor = Colors.Green;
                lblMessage.Text = "Event created successfully!";
            }
            else
            {
                lblMessage.Text = "Failed to create event.";
            }
        }

        private async void Button_GoBackClick(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
