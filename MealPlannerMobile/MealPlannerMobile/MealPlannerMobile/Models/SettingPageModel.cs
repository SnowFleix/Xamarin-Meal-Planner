using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace MealPlannerMobile
{
    public class SettingPageModel
    {
        public string[] APIDiets { 
            get {
                return new string[] { "Gluten Free", "Ketogenic", "Vegetarian", "Lacto-Vegetarian", "Ovo-Vegetarian", "Vegan", "Pescetarian", "Paleo", "Primal", "Whole30" };
            } 
        }
        public string[] Intolerances
        {
            get
            {
                return new string[] { "Dairy", "Egg", "Gluten", "Grain", "Peanut", "Seafood", "Sesame", "Shellfish", "Soy", "Sulfite", "Tree Nut", "Wheat" };
            }
        }
        public static Settings AppSettings { get; set; }

        public SettingPageModel()
        {
            AppSettings = new Settings();
        }
    }
}
