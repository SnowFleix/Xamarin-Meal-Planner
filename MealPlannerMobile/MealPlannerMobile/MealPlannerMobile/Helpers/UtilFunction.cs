﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MealPlannerMobile;
using Xamarin.Forms;

namespace Extensions
{
    public static class Convertion
    {
        /// <summary>
        /// Converts an object to a boolean
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ToBoolean(object obj) { return Convert.ToBoolean(obj); }
        /// <summary>
        /// Converts an object to an int32
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt(object obj) { return Convert.ToInt32(obj); }
        /// <summary>
        /// Converts any object to a string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj) { return Convert.ToString(obj); }
        /// <summary>
        /// Converts a list of string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(List<string> obj) { string retS = ""; foreach(string str in obj) retS += str + ", "; return retS.Truncate(retS.Length - 2); }
        /// <summary>
        /// Converts an object to a double
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDouble(object obj) { return Convert.ToDouble(obj); }
        /// <summary>
        /// Converts all the ingredients in an array to a list of strings
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<string> ToList(Ingredient[] obj) { return obj.Select(x => x.ToString()).ToList(); }
        /// <summary>
        /// Converts all objects in an array to a list of strings
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<string> ToList(object[] obj) { return obj.Select(x => new string(x.ToString().ToCharArray())).ToList(); }
        /// <summary>
        /// Returns the time from mins to a readable amount to directly output to the user
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ToReadableTime(int time)
        {
            if (time == 0) return ""; // If the time is 0 then the step takes no time
            int hours = 0;
            int mins = time % 60;
            if (time != mins)
                hours = time / 60;
            if (hours == 0)
                return string.Format("Ready in {0} minutes", mins);
            return string.Format("Ready in {0} hours and {1} minutes", hours, mins);
        }
        /// <summary>
        /// Converts a Recipe to a RecipeData class ready to insert into the database
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public static RecipeData ToRecipeData(Recipe recipe) { return new RecipeData { SpoonacularRecipeID = (int)recipe.id }; }
        /// <summary>
        /// Gets all the recipe ids from the recipe table
        /// </summary>
        /// <param name="recipes"></param>
        /// <returns></returns>
        public static List<int> GetIdsFromRecipeData(RecipeData[] recipes) { return recipes.Select(x => x.SpoonacularRecipeID).ToList(); }
        /// <summary>
        /// Uses substring to truncate a string to the passed length
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }

    public static class UtilFunction
    {
        /// <summary>
        /// Converts an object to a string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ParameterToString(object obj)
        {
            if (obj is DateTime)
                return ((DateTime)obj).ToString();
            else if (obj is List<string>)
                return String.Join(",", (obj as List<string>).ToArray());
            else
                return Convert.ToString(obj);
        }
        /// <summary>
        /// Tries to convert the object to a double, if it can't catch the error
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsObjNumber(object obj)
        {
            try
            {
                Convert.ToDouble(obj);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Splits a string into an array using .Split
        /// </summary>
        /// <param name="originalStr"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static string[] ParseString(string originalStr, char splitChar)
        {
            return originalStr.Split(splitChar);
        }
        /// <summary>
        /// Convert the list of sorted ingredients to a list of strings that can be used as an item source
        /// </summary>
        /// <returns></returns>
        public static List<string> ConvertIngredientsToString(List<Ingredient> AllIngredients)
        {
            List<string> retLst = new List<string>();
            foreach (Ingredient i in AllIngredients)
            {
                Ingredient temp = NormaliseAmount(i);
                retLst.Add(temp.name + " " + Math.Round(temp.amount, 2) + " " + temp.unit);
            }
            retLst.Sort();
            return retLst;
        }
        /// <summary>
        /// Sorts the amount into a more readable amounts so there are no '320 garlic cloves'
        /// </summary>
        /// <param name="ingredient">The ingredient to normalise the amount</param>
        /// <returns></returns>
        public static Ingredient NormaliseAmount(Ingredient ingredient)
        {
            if (ingredient.amount < 20) return ingredient;

            else if (ingredient.unit == "oz")
            {
                ingredient.amount = ConvertUnit("g", ingredient);
                ingredient.unit = "g";
            }

            else if (ingredient.unit == "tablespoon" || ingredient.unit == "tablespoons" || ingredient.unit == "tbsp" || ingredient.unit == "Tbsp")
            {
                if (ingredient.amount < 10) return ingredient;
                ingredient.amount = ConvertUnit("ml", ingredient);
                ingredient.unit = "ml";
            }

            else if (ingredient.unit == "clove" && ingredient.amount > 12)
            {
                ingredient.amount /= 11;
                ingredient.unit = "";
            }

            if (ingredient.amount > 1000)
            {
                if (ingredient.unit == "g")
                {
                    ingredient.amount /= 1000;
                    ingredient.unit = "kg";
                }
                else if (ingredient.unit == "ml")
                {
                    ingredient.amount /= 1000;
                    ingredient.unit = "l";
                }
            }

            return ingredient;
        }
        /// <summary>
        /// Uses the sponaculat api to convert the amount from one unit to another
        /// </summary>
        /// <param name="unit">The target unit, the unit to be converted to</param>
        /// <param name="ingredient">The ingredient that needs to be converted</param>
        /// <returns></returns>
        public static double ConvertUnit(string unit, Ingredient ingredient)
        {
            return new spoontacularAPI().ConvertAmount(ingredient.name, ingredient.amount, ingredient.unit, unit);
        }
        /// <summary>
        /// Tries to convert an object to an ingredient, if it can't, returns false
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsObjIngredient(object obj)
        {
            try
            {
                string name = ((Ingredient)obj).name;
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Tries to cast an object to a recipe, if not it will return false
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsObjRecipe(object obj)
        {
            try
            {
                string title = ((Recipe)obj).title;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Returns a recipe using the ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Recipe GetRecipeFromID(int ID)
        {
            return new spoontacularAPI().GetRecipeFromID(ID);
        }
        /// <summary>
        /// Returns an array of recipes from a list of RecipeIDs
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static Recipe[] GetRecipesFromID(List<int> RecipeID) { return RecipeID.Select(x => GetRecipeFromID(x)).ToArray(); }
        /// <summary>
        /// Merges any two arrays together of the same type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static T[] MergeTwoArrays<T>(T[] array1, T[] array2)
        {
            int array1OriginalLength = array1.Length;
            Array.Resize<T>(ref array1, array1OriginalLength + array2.Length);
            Array.Copy(array2, 0, array1, array1OriginalLength, array2.Length);
            return array1;
        }
        //List<Recipe> retLst = new List<Recipe>();
            //foreach (int i in RecipeID)
            //    retLst.Add(new spoontacularAPI().GetRecipeFromID(i));
            //return retLst.ToArray();
        
    }
}
