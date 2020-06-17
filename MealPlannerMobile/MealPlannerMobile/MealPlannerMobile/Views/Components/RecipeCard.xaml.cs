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
    public partial class RecipeCard : StackLayout
    {
        public RecipeCard()
        {
            InitializeComponent();
        }

        public void NewRecipeClicked(object source, EventArgs e)
        {

        }
    }
}