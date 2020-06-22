using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealPlannerMobile
{
    public class Settings : Application
    {
        private const string DietKey = "Diet";
        private const string MaxCaloriesKey = "MaxCalories";
        private const string IntolerancesKey = "Intolerances";
        private const string ExcludedIngredientsKey = "ExcludedIngredients";

        public Settings()
        {
            if (!Properties.ContainsKey(IntolerancesKey))
                Properties[IntolerancesKey] = new List<string>();
            if (!Properties.ContainsKey(ExcludedIngredientsKey))
                Properties[ExcludedIngredientsKey] = new List<string>();
        }

        /// <summary>
        /// Used to store the user selected diet
        /// </summary>
        public string Diet
        {
            get
            {
                if (Properties.ContainsKey(DietKey))
                    Properties[DietKey].ToString();
                return "";
            }
            set
            {
                Properties[DietKey] = value;
            }
        }

        /// <summary>
        /// Used to store the user selected max calories per meal
        /// </summary>
        public int MaxCalories
        {
            get
            {
                if (Properties.ContainsKey(MaxCaloriesKey))
                    return Convert.ToInt32(Properties[MaxCaloriesKey]);
                return -1;
            }
            set
            {
                Properties[MaxCaloriesKey] = value;
            }
        }

        /// <summary>
        /// Used to store all the intolerences the user inputs
        /// </summary>
        public List<string> Intolerances
        {
            get
            {
                if (Properties.ContainsKey(IntolerancesKey))
                    return (List<string>)Properties[IntolerancesKey];
                return new List<string>();
            }
            set
            {
                Properties[IntolerancesKey] = value;
            }
        }

        /// <summary>
        /// Used to store all the ingredients the user doesn't want
        /// </summary>
        public List<string> ExcludedIngredients
        {
            get
            {
                if (Properties.ContainsKey(ExcludedIngredientsKey))
                    return (List<string>)Properties[ExcludedIngredientsKey];
                return new List<string>();
            }
            set
            {
                Properties[ExcludedIngredientsKey] = value;
            }
        }
    }
}
