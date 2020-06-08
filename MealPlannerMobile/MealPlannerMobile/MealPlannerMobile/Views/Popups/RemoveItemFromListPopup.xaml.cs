using Rg.Plugins.Popup.Pages;
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
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemoveItemFromListPopup : PopupPage
    {
        public string SelectedItem { get; set; }

        public List<string> RefCollection;

        public RemoveItemFromListPopup(string item, List<string> collection)
        {
            InitializeComponent();

            TitleLabel.Text = String.Format("Would you like to remove {0} from the list?", item);
            
            this.SelectedItem = item;
            this.RefCollection = collection;
        }

        public async void Button_Yes_Clicked(object source, EventArgs e)
        {
            RefCollection.Remove(SelectedItem);
            MessagingCenter.Send<RemoveItemFromListPopup>(this, "RemovedItemFromList"); // 
            await PopupNavigation.PopAsync();
        }

        public async void Button_No_Clicked(object source, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}