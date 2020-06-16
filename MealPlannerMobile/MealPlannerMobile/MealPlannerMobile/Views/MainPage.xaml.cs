using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MealPlannerMobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void ViewTodaysRecipe_Clicked(object sender, EventArgs e)
        {
            Recipe[] TodaysRecipes = { }; // Need to get recipes that are only for today
            await Navigation.PushModalAsync(new ViewWeeksRecipes(TodaysRecipes));
        }

        public async void ViewAllRecipes_Clicked(object sender, EventArgs e)
        {
            Recipe[] AllRecipes = { }; // Need to get recipes that are only for today
            await Navigation.PushModalAsync(new ViewWeeksRecipes(AllRecipes));
        }
    }
}
