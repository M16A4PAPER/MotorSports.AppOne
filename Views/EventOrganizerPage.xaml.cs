using MotorSports.AppOne.Services;
using MotorSports.AppOne.Models;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;

namespace MotorSports.AppOne.Views;

public partial class EventOrganizerPage : ContentPage
{
    private EventApiService? EventApiService;
    public ObservableCollection<Event> EventsList { get; set; } = new();

    public EventOrganizerPage()
    {
        InitializeComponent();
        EventApiService = new EventApiService();
        BindingContext = this; //Set binding context to this page.
    }

    private void ButtonCreateEvent_Click(object sender, EventArgs e)
    {

    }

    private void ButtonManageEvent_Click(object sender, EventArgs e)
    {

    }

    private async void ButtonViewAllEvents_Click(object sender, EventArgs e)
    {
        try
        {
            if (EventApiService != null)
            {
                string jsonData = await EventApiService.GetAllEvents();

                if (!string.IsNullOrEmpty(jsonData))
                {
                    var events = JsonConvert.DeserializeObject<List<Event>>(jsonData);
                    EventsList.Clear();

                    foreach (var evnt in events)
                    {
                        EventsList.Add(evnt);
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No events found.", "OK");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to fetch events: {ex.Message}", "OK");
        }
    }
}