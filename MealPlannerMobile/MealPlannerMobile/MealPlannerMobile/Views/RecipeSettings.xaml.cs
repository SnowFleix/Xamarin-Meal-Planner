using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Rg.Plugins.Popup;

namespace MealPlannerMobile
{
    public partial class RecipeSettings : ContentPage
    {
        string[] APIdiets = { "Gluten Free", "Ketogenic", "Vegetarian", "Lacto-Vegetarian", "Ovo-Vegetarian", "Vegan", "Pescetarian", "Paleo", "Primal", "Whole30" }; // Perhaps move this into something like an .env file?
        string[] intolerances = { "Dairy", "Egg", "Gluten", "Grain", "Peanut", "Seafood", "Sesame", "Shellfish", "Soy", "Sulfite", "Tree Nut", "Wheat" };
        List<string> selected_intolerances = new List<string>();
        ObservableCollection<string> selected_exldIngredients = new ObservableCollection<string>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public RecipeSettings()
        {
            InitializeComponent();
            picker_diets.ItemsSource = APIdiets;
            picker_intolerances.ItemsSource = intolerances;
            lstView_intolerances.ItemsSource = selected_intolerances;
            lstView_excldIngredients.ItemsSource = selected_exldIngredients;
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
            lstView_intolerances.ItemsSource = selected_intolerances.ToArray(); // update the itemssource 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void btnRemoveIntolerance_click(object source, EventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void btnAddExcludedIngredient_click(object source, EventArgs e)
        {
            selected_exldIngredients.Add((string)entry_exldIngredients.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void btnRemoveExcludedIngredient_click(object source, EventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void btnSubmit_click(object source, EventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lstView_intolerances_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lstView_excldIngredients_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event

        }
    }
}