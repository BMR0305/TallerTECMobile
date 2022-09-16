﻿using MobileTallerTEC.Services;
using MobileTallerTEC.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTallerTEC
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            Startup.ConfigureServices();

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
