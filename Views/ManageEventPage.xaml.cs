using Microsoft.Maui.Controls;
using System;

namespace MotorSports.AppOne.Views
{
    public partial class ManageEventsPage : ContentPage
    {
        public ManageEventsPage()
        {
            InitializeComponent();
        }

        private async void ButtonAssignSponsor_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SponsorAssignation());
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void ButtonAssignTeam_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TeamAssignation());
        }
    }
}
