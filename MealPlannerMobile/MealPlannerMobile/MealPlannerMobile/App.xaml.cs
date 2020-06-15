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

            //Result apiResult = new spoontacularAPI().GetRandomRecipe("", "", "", "main course", 28);
            Result apiResult = new Repository().result;
            MainPage = new PlanWeekPage();
            //MainPage = new ViewRecipe(apiResult.results[0]);
            //MainPage = new ShoppingList(apiResult.results);
            //MainPage = new RecipeSettings();
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
