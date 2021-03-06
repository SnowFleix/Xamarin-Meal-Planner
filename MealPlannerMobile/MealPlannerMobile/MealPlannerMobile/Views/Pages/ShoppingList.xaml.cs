﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using Rg.Plugins.Popup.Services;

using Extensions;

namespace MealPlannerMobile
{
    /// <remarks>
    /// TODO: Refactor the code and make it more readable as well as any abstractions
    /// </remarks>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingList : ContentPage
    {
        private readonly Recipe[] recipes;
        private List<Ingredient> Ingredients = new List<Ingredient>();

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="recipes"></param>
        /// <remarks>should eventually work with the persistent data stored after doing a get plan request, rather than being sent an array</remarks>
        public ShoppingList(/*Recipe[] recipes*/)
        {
            InitializeComponent();

            if (DeviceInfo.Platform == DevicePlatform.Android)
                Padding = new Thickness(0, 15, 0, 0);
            if (DeviceInfo.Platform == DevicePlatform.iOS)
                Padding = new Thickness(0, 35, 0, 0);

            this.recipes = Repository.result.results; // use persistent data instead
            AddIngredientsToList();
            AccumulateIngredients();
            lstView_shoppingItems.ItemsSource = Ingredients;
        }

        /// <summary>
        /// Adds all the ingredients from all the recipes to one large list
        /// </summary>
        public void AddIngredientsToList()
        {
            foreach (Recipe r in recipes)
                Ingredients.AddRange(r.extendedIngredients);
        }

        /// <summary>
        /// Sorts through all the ingredients in the recipes and accumulates their amounts
        /// </summary>
        private void AccumulateIngredients()
        {
            List<Ingredient> tempIngredients = new List<Ingredient>();
            foreach (Ingredient i in Ingredients)
            {
                if (!CheckIfIngredientIsAlreadyInList(i, tempIngredients))
                    tempIngredients.Add(i);
                else if (CheckIfIngredientIsAlreadyInList(i, tempIngredients))                                                                      // the ingredient needs to exist to add the amounts together
                {
                    if (i.unit == GetIngredient(i, tempIngredients).unit)
                            GetIngredient(i, tempIngredients).amount += i.amount;                                                                   // if the units are already the same, don't bother calling the api
                    else
                    {
                        if (!String.IsNullOrWhiteSpace(i.unit) && !String.IsNullOrWhiteSpace(GetIngredient(i, tempIngredients).unit))
                                GetIngredient(i, tempIngredients).amount += UtilFunction.ConvertUnit(GetIngredient(i, tempIngredients).unit, i);    // call the api to convert the units
                        else
                            tempIngredients.Add(i);
                    }
                }
            }
            Ingredients = tempIngredients;
        }

        /// <summary>
        /// Get an ingredient with the same name from a passed list
        /// </summary>
        /// <param name="ingredient">The ingredient to match with</param>
        /// <param name="ingredients">The list of ingredients to search through</param>
        /// <returns></returns>
        private Ingredient GetIngredient(Ingredient ingredient, List<Ingredient> ingredients)
        {
            foreach (Ingredient i in ingredients)
                if (i.name == ingredient.name || i.name == ingredient.name.Remove(ingredient.name.Length - 1))
                    return i;
            return new Ingredient(); // need to return something here
        }

        /// <summary>
        /// Check if the ingredient exists in a passed list
        /// </summary>
        /// <param name="ingredient">The ingredient to check</param>
        /// <param name="ingredients">The list to search through</param>
        /// <returns></returns>
        private bool CheckIfIngredientIsAlreadyInList(Ingredient ingredient, List<Ingredient> ingredients)
        {
            foreach (Ingredient i in ingredients)
                if (i.name == ingredient.name || i.name == ingredient.name.Remove(ingredient.name.Length - 1)) // The idea of || ingredientName - 1 is to stop adding plural versions of the ingredients
                    return true;
            return false;
        }

        /// <summary>
        /// Handles one of the list view items being tapped
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        [Obsolete]
        public async void LstView_ShoppingItems_Tapped(object source, ItemTappedEventArgs e)
        {
            if (!UtilFunction.IsObjIngredient(e.Item)) return; // if e has been set to null, do not process tapped event

            int i; // i for index
            for (i = 0; i < Ingredients.Count; i++)
                if (((Ingredient)e.Item).name == Ingredients[i].name /*&& unit == AllIngredients[i].unit*/)
                    break;

            await PopupNavigation.PushAsync(new AlterIngredientInShoppingList(Ingredients[i], i));
            MessagingCenter.Subscribe<AlterIngredientInShoppingList, Ingredient>(this, "UpdateIngredient", (objSender, args) =>
            {
                // 
                if (args.amount == 0 && Ingredients[objSender.ingredientIndex].name == args.name)
                    Ingredients.RemoveAt(objSender.ingredientIndex);
                else if (Ingredients[objSender.ingredientIndex].name == args.name)
                    Ingredients[objSender.ingredientIndex] = args;
                lstView_shoppingItems.ItemsSource = UtilFunction.ConvertIngredientsToString(Ingredients).ToArray();
            });
            MessagingCenter.Unsubscribe<RemoveItemFromListPopup>(this, "UpdateIngredient");
            lstView_shoppingItems.SelectedItem = null;
        }
    }
}