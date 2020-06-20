using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealPlannerMobile
{
    public partial class App : Application
    {
        private const string DietKey = "Diet";
        private const string MaxCaloriesKey = "MaxCalories";
        private const string IntolerancesKey = "Intolerances";
        private const string ExcludedIngredientsKey = "ExcludedIngredients";
        public App()
        {
            DotNetEnv.Env.Load(); // Need to fix this later to use .env files

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Repository.SyncfusionKey); //DotNetEnv.Env.GetString("SYNCFUSION_APIKEY"));
            
            InitializeComponent();

            //Result apiResult = new spoontacularAPI().GetRandomRecipe("", "", "", "main course", 28);
            //Result apiResult = new Repository().result;
            MainPage = new HomeTabbedPage();
        }

        protected override void OnStart()
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }

        
    }
}
