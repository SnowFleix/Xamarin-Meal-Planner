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
using MealPlannerMobile.Models;

namespace MealPlannerMobile
{
    public partial class RecipeSettings : ContentPage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public RecipeSettings()
        {
            InitializeComponent();
            this.BindingContext = new SettingPageModel();
            LstView_Intolerances.ItemsSource = SettingPageModel.AppSettings.Intolerances.ToArray();
            lstView_excldIngredients.ItemsSource = SettingPageModel.AppSettings.ExcludedIngredients.ToArray();
            CalorieEntry.Text = SettingPageModel.AppSettings.MaxCalories.ToString();
        }

        /// <summary>
        /// Used to stop the repetition of code, updates the list views when the data changes
        /// </summary>
        /// <remarks>Quick hack because the binding wasn't working</remarks>
        private void UpdateListViews()
        {
            LstView_Intolerances.ItemsSource = SettingPageModel.AppSettings.Intolerances.ToArray();
            lstView_excldIngredients.ItemsSource = SettingPageModel.AppSettings.ExcludedIngredients.ToArray();
        }

        /// <summary>
        /// Adds the selected intolerance
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void btnAddIntolerance_click(object source, EventArgs e)
        {
            if(!SettingPageModel.AppSettings.Intolerances.Contains((string)picker_intolerances.SelectedItem))
                SettingPageModel.AppSettings.Intolerances.Add((string)picker_intolerances.SelectedItem);
            UpdateListViews();
        }

        /// <summary>
        /// Handles adding the users inputted ingredients to the exclude list
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void btnAddExcludedIngredient_click(object source, EventArgs e)
        {
            if(!SettingPageModel.AppSettings.ExcludedIngredients.Contains((string)entry_exldIngredients.Text))
                SettingPageModel.AppSettings.ExcludedIngredients.Add((string)entry_exldIngredients.Text);
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
            await PopupNavigation.PushAsync(new RemoveItemFromListPopup((string)e.Item, SettingPageModel.AppSettings.Intolerances));
            MessagingCenter.Subscribe<RemoveItemFromListPopup>(this, "RemovedItemFromList", (objSender) => {
                SettingPageModel.AppSettings.Intolerances = objSender.RefCollection;
            });
            MessagingCenter.Unsubscribe<RemoveItemFromListPopup>(this, "RemoveItemFromList");
            UpdateListViews();
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
            await PopupNavigation.PushAsync(new RemoveItemFromListPopup((string)e.Item, SettingPageModel.AppSettings.ExcludedIngredients));
            MessagingCenter.Subscribe<RemoveItemFromListPopup>(this, "RemovedItemFromList", (objSender) => {
                SettingPageModel.AppSettings.ExcludedIngredients = objSender.RefCollection;
            });
            MessagingCenter.Unsubscribe<RemoveItemFromListPopup>(this, "RemoveItemFromList");
            UpdateListViews();
        }
    }
}