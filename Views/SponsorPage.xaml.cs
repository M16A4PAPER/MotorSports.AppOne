using MotorSports.AppOne.Models;
using MotorSports.AppOne.Services;
using MotorSports.DomainObjects;
using System.Collections.ObjectModel;

namespace MotorSports.AppOne.Views;

public partial class SponsorPage : ContentPage
{
    private ApiService _apiService;
    public ObservableCollection<Sponsor> SponsorsList { get; set; } = new();

    public SponsorPage()
    {
        InitializeComponent();
        _apiService = new ApiService();
        BindingContext = this;
    }

    private async void ButtonViewSponsorships_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SponsorViewPage());
    }

    private async void ButtonRemoveSponsorship_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SponsorDeletePage());
    }
}
