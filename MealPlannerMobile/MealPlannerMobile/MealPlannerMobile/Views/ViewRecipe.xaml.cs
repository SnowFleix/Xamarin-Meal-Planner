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
        public ViewRecipe(Recipe recipe)
        {
            InitializeComponent();
            this.BindingContext = recipe;
        }
    }
}