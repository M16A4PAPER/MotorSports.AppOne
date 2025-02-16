using MotorSports.AppOne.Services;
using MotorSports.AppOne.Models;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;

namespace MotorSports.AppOne.Views;

public partial class EventOrganizerPage : ContentPage
{
    private ApiService? EventApiService;
    public ObservableCollection<Event> EventsList { get; set; } = new();

    public EventOrganizerPage()
    {
        InitializeComponent();
        EventApiService = new ApiService();
        BindingContext = this; //Set binding context to this page.
    }

    private async void ButtonCreateEvent_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EventCreationPage());
    }

    private async void ButtonManageEvent_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ManageEventsPage());
    }

    private async void ButtonViewAllEvents_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewAllEventsPage());
    }
}