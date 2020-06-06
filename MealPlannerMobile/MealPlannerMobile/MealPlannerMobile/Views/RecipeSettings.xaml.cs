using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Services;

namespace MealPlannerMobile
{
    public partial class RecipeSettings : ContentPage
    {
        // Perhaps move this into something like an .env file?
        readonly string[] APIdiets = { "Gluten Free", "Ketogenic", "Vegetarian", "Lacto-Vegetarian", "Ovo-Vegetarian", "Vegan", "Pescetarian", "Paleo", "Primal", "Whole30" }; 
        readonly string[] intolerances = { "Dairy", "Egg", "Gluten", "Grain", "Peanut", "Seafood", "Sesame", "Shellfish", "Soy", "Sulfite", "Tree Nut", "Wheat" };
        List<string> selected_intolerances = new List<string>();
        List<string> selected_exldIngredients = new List<string>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public RecipeSettings()
        {
            InitializeComponent();
            picker_diets.ItemsSource = APIdiets;
            picker_intolerances.ItemsSource = intolerances;
        }

        /// <summary>
        /// Used to stop the repetition of code, updates the list views when the data changes
        /// </summary>
        private void UpdateListViews()
        {
            lstView_intolerances.ItemsSource = selected_intolerances.ToArray(); // update the itemssource 
            lstView_excldIngredients.ItemsSource = selected_exldIngredients.ToArray();
        }

        /// <summary>
        /// Adds the selected intolerance
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void btnAddIntolerance_click(object source, EventArgs e)
        {
            if(!selected_intolerances.Contains((string)picker_intolerances.SelectedItem))
                selected_intolerances.Add((string)picker_intolerances.SelectedItem);
            UpdateListViews();
        }

        /// <summary>
        /// Handles adding the users inputted ingredients to the exclude list
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void btnAddExcludedIngredient_click(object source, EventArgs e)
        {
            if(!selected_exldIngredients.Contains((string)entry_exldIngredients.Text))
                selected_exldIngredients.Add((string)entry_exldIngredients.Text);
            UpdateListViews();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void btnSubmit_click(object source, EventArgs e)
        {
            // TODO: learn about persistent data in xamarin then implement it here
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Obsolete]
        async void lstView_intolerances_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            await PopupNavigation.PushAsync(new RemoveItemFromListPopup((string)e.Item, selected_intolerances));
            MessagingCenter.Subscribe<RemoveItemFromListPopup>(this, "RemovedItemFromList", (objSender) => {
                selected_intolerances = objSender.RefCollection;
                UpdateListViews();
            });
            MessagingCenter.Unsubscribe<RemoveItemFromListPopup>(this, "RemoveItemFromList");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Need to refactor the code</remarks>
        [Obsolete]
        async void lstView_excldIngredients_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            await PopupNavigation.PushAsync(new RemoveItemFromListPopup((string)e.Item, selected_exldIngredients));
            MessagingCenter.Subscribe<RemoveItemFromListPopup>(this, "RemovedItemFromList", (objSender) => {
                selected_exldIngredients = objSender.RefCollection;
                UpdateListViews();
            });
            MessagingCenter.Unsubscribe<RemoveItemFromListPopup>(this, "RemoveItemFromList");
        }


    }
}