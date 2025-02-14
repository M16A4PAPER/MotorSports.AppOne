using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using MotorSports.AppOne.Models;

namespace MotorSports.AppOne.Views
{
    public partial class ViewSponsorEvents : ContentPage
    {
        public ViewSponsorEvents(List<Event> events)
        {
            InitializeComponent();
            EventsListView.ItemsSource = events; // Bind the event list
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
