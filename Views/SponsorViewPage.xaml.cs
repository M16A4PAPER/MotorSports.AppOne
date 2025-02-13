namespace MotorSports.AppOne.Views;

public partial class SponsorViewPage : ContentPage
{
	public SponsorViewPage()
	{
		InitializeComponent();
	}

    private async void OnGoBackClicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}