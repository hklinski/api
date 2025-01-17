﻿using PeopleStoreApp.DataContracts;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeopleStoreApp
{
    public partial class App : Application
    {
        private const string API_URL = "http://192.168.0.105:5000/api";
        public App()
        {
            InitializeComponent();
            var client = RestEase.RestClient.For<IPeopleClient>(API_URL);

            MainPage = new MainPage(client);
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
