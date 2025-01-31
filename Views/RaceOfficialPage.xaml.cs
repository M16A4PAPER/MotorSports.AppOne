namespace MotorSports.AppOne.Views;

public partial class RaceOfficialPage : ContentPage
{
	public RaceOfficialPage()
	{
		InitializeComponent();
	}

    private async void ButtonShowResults_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RaceResultsPage());
    }

    private void ButtonAssignPositions_Click(object sender, EventArgs e)
    {

    }
}