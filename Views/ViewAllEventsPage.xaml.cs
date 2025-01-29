using MotorSports.AppOne.Models;
using MotorSports.AppOne.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MotorSports.AppOne.Views;

public partial class ViewAllEventsPage : ContentPage
{
	private EventApiService _eventApiService;
	public ObservableCollection<Event> EventsList { get; set; } = new();

	public ViewAllEventsPage()
	{
		InitializeComponent();
		_eventApiService = new EventApiService();
		BindingContext = this;
        LoadEvents();
	}

    private async void LoadEvents()
    {
        try
        {
            string jsonData = await _eventApiService.GetAllEvents();

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
                await DisplayAlert("No Events", "No events found.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to fetch events: {ex.Message}", "OK");
        }
    }

    private async void ButtonGoBack_Click(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}