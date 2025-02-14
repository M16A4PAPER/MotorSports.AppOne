using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using MotorSports.AppOne.Models;
using MotorSports.AppOne.Services;

namespace MotorSports.AppOne.Views
{
    public partial class SponsorViewPage : ContentPage
    {
        private readonly ApiService apiService;

        public SponsorViewPage()
        {
            InitializeComponent();
            apiService = new ApiService();
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            if (int.TryParse(txtSponsorId.Text, out int sponsorId))
            {
                // Call API to fetch events
                List<Event> events = await apiService.GetEventsBySponsor(sponsorId);

                if (events.Count > 0)
                {
                    // Navigate to ViewSponsorEvents page with the fetched data
                    await Navigation.PushAsync(new ViewSponsorEvents(events));
                }
                else
                {
                    await DisplayAlert("No Events", "No events found for this Sponsor ID.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Invalid Input", "Please enter a valid Sponsor ID.", "OK");
            }
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
