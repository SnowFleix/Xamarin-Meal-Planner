using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;

using Extensions;

namespace MealPlannerMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlterIngredientInShoppingList : PopupPage
    {
        private Ingredient ingredient;
        public readonly int ingredientIndex;
        public AlterIngredientInShoppingList(Ingredient ingredient, int index)
        {
            if (ingredient == null) ClosePopup(); // if the ingredient is somehow null, just close the popup straight away
            this.ingredient = ingredient;
            this.ingredientIndex = index;
            InitializeComponent();
            TitleLabel.Text = String.Format("Alter {0}?", ingredient.name);
            UnitLabel.Text = ingredient.unit;
            EntryAmount.Text = ingredient.amount.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public async void ClosePopup()
        {
            await PopupNavigation.PopAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ReturnIngredient()
        {
            MessagingCenter.Send<AlterIngredientInShoppingList, Ingredient>(this, "UpdateIngredient", ingredient); // 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void BtnUpdate_Clicked(object source, EventArgs e)
        {
            if(UtilFunction.IsObjNumber(EntryAmount.Text))
                ingredient.amount = Convert.ToDouble(EntryAmount.Text);
            ReturnIngredient();
            ClosePopup();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void BtnDelete_Clicked(object source, EventArgs e)
        {
            ingredient.amount = 0;
            ReturnIngredient();
            ClosePopup();
        }
    }
}