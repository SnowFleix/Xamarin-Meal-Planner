using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealPlannerMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewWeeksRecipes : ContentPage
    {
        public struct ViewRecipesModel
        {
            public ICommand CardTappedCommand { get; set; }
            public Recipe[] recipes { get; set; }
        }

        public ViewWeeksRecipes()
        {
            InitializeComponent();
            ViewRecipesModel context = new ViewRecipesModel();
            context.CardTappedCommand = new Command<object>(OnCardTapped);
            context.recipes = Repository.result.results; // TODO: Change to use persistent data

            this.BindingContext = context; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Not fully implemented, need to figure out how to send the tapped recipe as a parameter</remarks>
        public async void OnCardTapped(object sender)
        {
            if (!UtilFunction.IsObjRecipe(sender)) return;
            // TODO: Find out how to get the data from the tapped card
            await Navigation.PushModalAsync(new ViewRecipe((Recipe)sender));
        }
    }
}