using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//using static MealPlannerMobile.UtilFunction;

namespace MealPlannerMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewRecipe : ContentPage
    {
        private string IngredientName, IngredientAmount, IngredientUnit;
        public string IngredientTemplate
        {
            get
            {
                return string.Format("{0} {1} {2}", IngredientName, IngredientAmount, IngredientUnit);
            }
        }
        public ViewRecipe(Recipe recipe)
        {
            InitializeComponent();
            this.BindingContext = recipe;
        }
    }
}