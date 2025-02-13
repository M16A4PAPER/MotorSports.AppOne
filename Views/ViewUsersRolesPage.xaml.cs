using Microsoft.Maui.Controls;
using System.Collections.Generic;
using MotorSports.AppOne.Models;

namespace MotorSports.AppOne.Views
{
    public partial class ViewUsersRoles : ContentPage
    {
        public List<UserRole> UsersRoles { get; set; }

        public ViewUsersRoles(List<UserRole> usersRoles)
        {
            InitializeComponent();
            UsersRoles = usersRoles ?? new List<UserRole>(); 
            BindingContext = this;
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
