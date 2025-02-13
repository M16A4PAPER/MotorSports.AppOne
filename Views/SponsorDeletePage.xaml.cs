namespace MotorSports.AppOne.Views;

public partial class SponsorDeletePage : ContentPage
{
	public SponsorDeletePage()
	{
		InitializeComponent();
	}

    private async void OnGoBackClicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}