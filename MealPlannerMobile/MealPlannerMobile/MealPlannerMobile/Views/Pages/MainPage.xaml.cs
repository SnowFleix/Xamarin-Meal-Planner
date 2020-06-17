using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MealPlannerMobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void ViewRecipes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ViewWeeksRecipes());
        }

        public async void ViewShoppingList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ShoppingList());
        }
    }
}
