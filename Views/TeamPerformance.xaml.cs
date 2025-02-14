namespace MotorSports.AppOne.Views;

public partial class TeamPerformance : ContentPage
{
	public TeamPerformance()
	{
		InitializeComponent();
	}

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RaceResultsPage());
    }

    private async void OnGoBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}