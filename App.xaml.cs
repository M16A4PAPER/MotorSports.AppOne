﻿using System.Diagnostics;

namespace MotorSports.AppOne
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
