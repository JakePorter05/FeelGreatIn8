﻿using FeelGreatIn8.Services;
using FeelGreatIn8.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeelGreatIn8
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
