using MotorSports.AppOne.Services;
using MotorSports.DomainObjects;
using Newtonsoft.Json;

namespace MotorSports.AppOne.Views;

public partial class ParticipantPage : ContentPage
{
    private ApiService _participantApiService;

	public ParticipantPage()
	{
		InitializeComponent();

	}

    private async void ButtonViewUpcomingRaces_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewAllEventsPage());
    }

    private async void ButtonRegisterForRace_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RaceRegistrationPage());
    }

    private async void ButtonViewResults_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RaceResultsPage());
    }
}