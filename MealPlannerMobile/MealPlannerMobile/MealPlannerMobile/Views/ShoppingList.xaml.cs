using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MealPlannerMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingList : ContentPage
    {
        public ShoppingList()
        {
            InitializeComponent();

            if (DeviceInfo.Platform == DevicePlatform.Android)
                Padding = new Thickness(0, 15, 0, 0);
            if (DeviceInfo.Platform == DevicePlatform.iOS)
                Padding = new Thickness(0, 35, 0, 0);
            
        }
    }
}