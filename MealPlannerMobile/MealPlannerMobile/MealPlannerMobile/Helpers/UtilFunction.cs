using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerMobile
{
    public static class UtilFunction
    {
        /// <summary>
        /// 
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
        /// 
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
        /// 
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
    }
}
