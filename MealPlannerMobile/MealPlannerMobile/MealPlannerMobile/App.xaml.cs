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
            await _connection.CreateTableAsync<Recipe>();
            await _connection.DropTableAsync<RecipeData>();

            // justs adds a bunch of random data to the table to show it as an example
            if ((await _connection.Table<Recipe>().ToListAsync()).Count == 0)
            {
                await _connection.InsertAsync(Repository.result.results[0]);
                await _connection.InsertAsync(Repository.result.results[0]);
                await _connection.InsertAsync(Repository.result.results[0]);
                await _connection.InsertAsync(Repository.result.results[0]);
                await _connection.InsertAsync(Repository.result.results[0]);
                await _connection.InsertAsync(Repository.result.results[0]);
                await _connection.InsertAsync(Repository.result.results[0]);
                await _connection.InsertAsync(Repository.result.results[0]);
                await _connection.InsertAsync(Repository.result.results[0]);
                await _connection.InsertAsync(Repository.result.results[0]);
            }
        }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }


    }
}
