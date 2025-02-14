using MotorSports.AppOne.Services;
using System;
using System.Threading.Tasks;

namespace MotorSports.AppOne.Views
{
    public partial class SponsorDeletePage : ContentPage
    {
        private readonly ApiService _apiService;

        public SponsorDeletePage()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEventId.Text) || string.IsNullOrWhiteSpace(txtSponsorId.Text))
            {
                await DisplayAlert("Error", "Please enter both Event ID and Sponsor ID.", "OK");
                return;
            }

            if (!int.TryParse(txtEventId.Text, out int eventId) || !int.TryParse(txtSponsorId.Text, out int sponsorId))
            {
                await DisplayAlert("Error", "Invalid input. Please enter numeric values only.", "OK");
                return;
            }

            bool confirm = await DisplayAlert("Confirm", "Are you sure you want to delete this sponsorship?", "Yes", "No");
            if (!confirm) return;

            string result = await _apiService.DeleteSponsorship(eventId, sponsorId);
            if (result.StartsWith("Error"))
            {
                await DisplayAlert("Failed", $"Deletion failed: {result}", "OK");
            }
            else
            {
                await DisplayAlert("Success", "Sponsorship deleted successfully!", "OK");
                await Navigation.PopAsync();
            }
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
