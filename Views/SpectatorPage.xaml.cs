namespace MotorSports.AppOne.Views;

public partial class SpectatorPage : ContentPage
{
	public SpectatorPage()
	{
		InitializeComponent();
	}

    private async void ButtonViewRaceSchedule_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewAllEventsPage());
    }

    private async void ButtonViewRaceStandings_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RaceResultsPage());
    }
}