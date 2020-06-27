using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealPlannerMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanWeekPage : ContentPage
    {
        public PlanWeekPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles requesting the recipes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void OnClick(object sender, EventArgs args)
        {
            List<Tuple<string, bool>> Requests = new List<Tuple<string, bool>>(); // temp - fix UI later
            int MainCourses = 0, Breakfasts = 0;

            foreach (Tuple<string, bool> r in Requests) {
                if (r.Item2) MainCourses++;
                else Breakfasts++;
            }

            Result mainCourses = new spoontacularAPI().GetRandomRecipe("", new Settings().Diet, new Settings().GetIngredientsToExclude(), "main course", MainCourses);
            Result breakfasts = new spoontacularAPI().GetRandomRecipe("", new Settings().Diet, new Settings().GetIngredientsToExclude(), "breakfast", Breakfasts);

            SQLiteDBConnection _connection = new SQLiteDBConnection();
            await _connection.DropRecipeTable();
            Recipe[] recipes = UtilFunction.MergeTwoArrays<Recipe>(mainCourses.results, breakfasts.results);
            await _connection.InsertRecipeSet(recipes);
            await Navigation.PopModalAsync(); // pops the page once I'm finished with it
        }
    }
}