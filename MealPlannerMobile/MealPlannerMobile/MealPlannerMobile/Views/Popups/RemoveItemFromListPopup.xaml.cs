using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealPlannerMobile
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemoveItemFromListPopup : PopupPage
    {
        string selectedItem;

        public RemoveItemFromListPopup(string item)
        {
            this.selectedItem = item;
            InitializeComponent();
        }
    }
}