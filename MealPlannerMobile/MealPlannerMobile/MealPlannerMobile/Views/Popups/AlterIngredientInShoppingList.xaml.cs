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

namespace MealPlannerMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlterIngredientInShoppingList : PopupPage
    {
        public AlterIngredientInShoppingList(Ingredient ingredient)
        {
            if (ingredient == null) ClosePopup(); // if the ingredient is somehow null, just close the popup straight away
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public async void ClosePopup()
        {
            await PopupNavigation.PopAsync();
        }
    }
}