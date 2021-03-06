﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Foundation;
using MealPlannerMobile.iOS;
using SQLite;
using UIKit;

using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteDB))]
namespace MealPlannerMobile.iOS
{
    class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}