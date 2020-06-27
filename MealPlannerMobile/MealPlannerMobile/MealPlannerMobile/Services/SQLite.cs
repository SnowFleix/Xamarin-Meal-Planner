using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using Xamarin.Forms;
using Extensions;
using System.Threading.Tasks;

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

    #region Common SQLite Functions
    public class SQLiteDBConnection
    {
        private SQLiteAsyncConnection _connection;

        /// <summary>
        /// Default constructor that connects to the database
        /// </summary>
        public SQLiteDBConnection()
        {
            _connection = DependencyService.Get<ISQLiteDB>().GetConnection();
        }
        /// <summary>
        /// Gets all the recipes the user has saved in their database
        /// </summary>
        /// <returns></returns>
        public async Task<Recipe[]> GetRecipes()
        {
            var recipes = await _connection.Table<RecipeData>().ToListAsync();

            return UtilFunction.GetRecipesFromID(Convertion.GetIdsFromRecipeData(recipes.ToArray()));
        }
        /// <summary>
        /// Inserts a recipe into the database
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public async Task<bool> InsertRecipe(Recipe recipe)
        {
            await _connection.InsertAsync(Convertion.ToRecipeData(recipe));
            return true;
        }
        /// <summary>
        /// Inserts an array of recipes
        /// </summary>
        /// <param name="recipes"></param>
        /// <returns></returns>
        public async Task<bool> InsertRecipeSet(Recipe[] recipes)
        {
            await _connection.InsertAllAsync(recipes);
            return true;
        }
        /// <summary>
        /// Deletes the passed recipe from the table
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        /// <remarks>Needs to be changed so that it actually deletes the right recipe</remarks>
        public async Task<bool> DeleteRecipe(Recipe recipe) 
        {
            await _connection.DeleteAsync<RecipeData>(recipe.id);
            return true;
        }
        /// <summary>
        /// Drops the entire RecipeData table from the database 
        /// </summary>
        /// <returns></returns>
        /// <remarks>It won't let me use a generic method to delete table of type T</remarks>
        public async Task<bool> DropRecipeTable() // it won't let me use a generic method so
        {
            await _connection.DropTableAsync<RecipeData>();
            return true;
        }
        #region Test Code
        /// <summary>
        /// Simple function to add 
        /// </summary>
        /// <remarks>Test code to ttry and reduce the amount of calls to the API</remarks>
        public async Task<bool> AddTestData()
        {
            if ((await _connection.Table<RecipeData>().ToListAsync()).Count == 0)
            {
                await _connection.InsertAsync(Convertion.ToRecipeData(Repository.result.results[0]));
                await _connection.InsertAsync(Convertion.ToRecipeData(Repository.result.results[0]));
                await _connection.InsertAsync(Convertion.ToRecipeData(Repository.result.results[0]));
                await _connection.InsertAsync(Convertion.ToRecipeData(Repository.result.results[0]));
                await _connection.InsertAsync(Convertion.ToRecipeData(Repository.result.results[0]));
                await _connection.InsertAsync(Convertion.ToRecipeData(Repository.result.results[0]));
                await _connection.InsertAsync(Convertion.ToRecipeData(Repository.result.results[0]));
                await _connection.InsertAsync(Convertion.ToRecipeData(Repository.result.results[0]));
                await _connection.InsertAsync(Convertion.ToRecipeData(Repository.result.results[0]));
                await _connection.InsertAsync(Convertion.ToRecipeData(Repository.result.results[0]));
            }
            return true;
        }
        #endregion
    }
    #endregion
}
