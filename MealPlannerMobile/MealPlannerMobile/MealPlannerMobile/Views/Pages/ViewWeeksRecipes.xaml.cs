﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealPlannerMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewWeeksRecipes : ContentPage
    {
        public ViewWeeksRecipes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnCardTapped(object sender, EventArgs e)
        {
            // TODO: Find out how to get the data from the tapped card
            await Navigation.PushModalAsync(new ViewRecipe(  new Recipe()  ));
        }
    }
}