using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MealPlannerMobile
{
    public partial class App : Application
    {
        public App()
        {
            DotNetEnv.Env.Load("./Assets/Data/.env"); // Need to fix this later to use .env files

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Repository.SyncfusionKey); //DotNetEnv.Env.GetString("SYNCFUSION_APIKEY"));
            
            InitializeComponent();

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
