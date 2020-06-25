using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using SQLite;

using Extensions;

namespace MealPlannerMobile
{
    public partial class App : Application
    {
        private SQLiteAsyncConnection _connection;

        public App()
        {
            DotNetEnv.Env.Load("./Assets/Data/.env"); // Need to fix this later to use .env files

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Repository.SyncfusionKey); //DotNetEnv.Env.GetString("SYNCFUSION_APIKEY"));

            _connection = DependencyService.Get<ISQLiteDB>().GetConnection();

            InitializeComponent();

            MainPage = new HomeTabbedPage();
        }

        protected override async void OnStart()
        {
            #region Adds some test data to the SQLite DB to minimise API calls
            await new SQLiteDBConnection().AddTestData();
            #endregion
        }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }


    }
}
