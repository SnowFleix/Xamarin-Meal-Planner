using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace MealPlannerMobile
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }

    #region Tables
    public class RecipeData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int SpoonacularRecipeID { get; set; }
    }
    #endregion
}
