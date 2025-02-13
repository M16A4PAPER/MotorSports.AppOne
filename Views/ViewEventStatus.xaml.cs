using Microsoft.Maui.Controls;
using MotorSports.AppOne.Services;
using MotorSports.AppOne.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MotorSports.AppOne.Views
{
    public partial class ViewEventStatus : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();

        public List<EventStatus> EventStatuses { get; set; }

        public ViewEventStatus()
        {
            InitializeComponent();
            LoadEventStatuses();
        }

        private async void LoadEventStatuses()
        {
            string jsonResponse = await _apiService.GetAllEventStatuses();

            if (!string.IsNullOrEmpty(jsonResponse))
            {
                try
                {
                    EventStatuses = JsonConvert.DeserializeObject<List<EventStatus>>(jsonResponse);
                    EventStatusListView.ItemsSource = EventStatuses;
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Failed to load event statuses.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "No data received from API.", "OK");
            }
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
