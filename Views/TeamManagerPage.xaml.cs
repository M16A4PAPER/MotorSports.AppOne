namespace MotorSports.AppOne.Views;

public partial class TeamManagerPage : ContentPage
{
	public TeamManagerPage()
	{
		InitializeComponent();
	}

    private async void ButtonManageTeam_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ManageTeamOptions());
    }

    private async void ButtonViewTeamPerformance_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TeamPerformance());
    }
}