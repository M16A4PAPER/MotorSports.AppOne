namespace MotorSports.AppOne.Views;

public partial class RaceRegistrationPage : ContentPage
{
	public RaceRegistrationPage()
	{
		InitializeComponent();
	}

    private async void OnGoBackClicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}