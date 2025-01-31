namespace MotorSports.AppOne.Views;
using MotorSports.AppOne.Services;
using MotorSports.DomainObjects;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

public partial class RaceResultsPage : ContentPage
{
    private readonly ApiService _participantsApiService;
    public ObservableCollection<RaceResult> RaceResultList { get; set; } = new();

    public RaceResultsPage()
    {
        InitializeComponent();
        _participantsApiService = new ApiService();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadRaceResults();
    }


    private async Task LoadRaceResults()
    {
        try
        {
            string jsonData = await _participantsApiService.GetRaceResults();
            Console.WriteLine($"API Response: {jsonData}"); // Debug log

            if (!string.IsNullOrEmpty(jsonData))
            {
                var results = JsonConvert.DeserializeObject<List<RaceResult>>(jsonData);
                RaceResultList.Clear();

                foreach (var rslt in results)
                {
                    RaceResultList.Add(rslt);
                }
            }
            else
            {
                await DisplayAlert("No Results", "No results found.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to fetch results: {ex.Message}", "OK");
        }
    }

    private async void OnGoBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
