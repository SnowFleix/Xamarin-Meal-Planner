using MealPlannerMobile.Models;
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
    public partial class ViewRecipe : ContentPage
    {
        public ViewRecipe(Recipe recipe)
        {
            InitializeComponent();
            this.BindingContext = new RecipeModel(recipe);
            // Stops the huge amount of white space at the bottom of the list view
            this.ListView_Ingredients.HeightRequest = (22 * recipe.extendedIngredients.Length);
        }
    }
}