﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealPlannerMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RecipeSettings();

            //MainPage = new MainPage();
        }

        protected override void OnStart()
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }
    }
}
