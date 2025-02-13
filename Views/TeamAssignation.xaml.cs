using MotorSports.AppOne.Services;
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MotorSports.AppOne.Views
{
    public partial class TeamAssignation : ContentPage
    {
        private readonly ApiService apiService = new ApiService();

        public TeamAssignation()
        {
            InitializeComponent();
        }

        private async void GoBackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtEventId.Text, out int eventId) && int.TryParse(txtTeamId.Text, out int teamId))
            {
                lblMessage.Text = "Assigning team to event...";
                string response = await apiService.AssignTeamToEvent(eventId, teamId);
                lblMessage.Text = response;
            }
            else
            {
                lblMessage.Text = "Please enter valid numeric IDs.";
            }
        }
    }
}
