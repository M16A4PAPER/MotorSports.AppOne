using MotorSports.AppOne.Services;

namespace MotorSports.AppOne.Views;

public partial class AdminPage : ContentPage
{
    public AdminPage()
    {
        InitializeComponent();
    }

    private async void ButtonManageUsersAndRoles_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ManageUsersAndRoles());
    }

    private async void ButtonManageEventStatus_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ManageEventStatus());
    }
}