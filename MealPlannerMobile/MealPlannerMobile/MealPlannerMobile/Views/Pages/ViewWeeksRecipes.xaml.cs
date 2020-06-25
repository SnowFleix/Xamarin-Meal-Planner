using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;
using Syncfusion.XForms.Cards;

namespace MealPlannerMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewWeeksRecipes : ContentPage
    {
        ViewRecipesModel context = new ViewRecipesModel();
        public struct ViewRecipesModel
        {
            public ICommand CardTappedCommand { get; set; }
            public Recipe[] recipes { get; set; }
        }

        public ViewWeeksRecipes()
        {
            InitializeComponent();
            context.CardTappedCommand = new Command<object>(OnCardTapped);
        }

        /// <summary>
        /// When the page appears load all the data for the cards
        /// </summary>
        protected override void OnAppearing()
        {
            this.BindingContext = new SQLiteDBConnection().GetRecipes();
        }

        /// <summary>
        /// Handles the tapping of the card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Not fully implemented, need to figure out how to send the tapped recipe as a parameter</remarks>
        public async void OnCardTapped(object sender)
        {
            // If the sender is somehow null return instantly and do nothing
            if (sender == null) return;
            // I dob't like this but it's how they said to use the tapped event
            SfCardView cardView = (sender as TappedEventArgs).Parameter as SfCardView;
            var recipe = cardView.BindingContext as Recipe;
            if (!UtilFunction.IsObjRecipe(recipe)) return;
            await Navigation.PushModalAsync(new ViewRecipe(recipe));
        }
    }
}