using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerMobile
{
    class Recipe
    {
        public bool vegetarian { get; set; }
        public bool vegan { get; set; }
        public bool glutenFree { get; set; }
        public bool dairyFree { get; set; }
        public bool veryHealthy { get; set; }
        public bool cheap { get; set; } 
        public bool veryPopular { get; set; } 
        public bool sustainable { get; set; } 
        public int weightWatcherSmartPoints { get; set; } 
        public string gaps { get; set; } 
        public bool lowFodmap { get; set; } 
        public int aggregateLikes { get; set; } 
        public double spoonacularScore { get; set; } 
        public double healthScore { get; set; } 
        public string creditsText { get; set; }
        public string sourceName { get; set; } 
        public double pricePerServing { get; set; }
        public Ingredient[] extendedIngredients { get; set; }
        public int? id { get; set; } // There was just a random item that had a null ID
        public string title { get; set; } 
        public int readyInMinutes { get; set; } 
        public int servings { get; set; } 
        public string sourceUrl { get; set; } 
        public string image { get; set; } 
        public string imageType { get; set; } 
        public string summary { get; set; } 
        public string[] cuisines { get; set; }
        public string[] dishTypes { get; set; }
        public string[] diets { get; set; } 
        public string[] occasions { get; set; }
        public object winePairing { get; set; } // change from object to whatever is being sent later
        public AnalyzedInstructions[] analyzedInstructions { get; set; }
        public int usedIngredientCount { get; set; }
        public int missedIngredientCount { get; set; }
        public MissedIngredients[] missedIngredients { get; set; } 
        public int likes { get; set; }
        public object[] usedIngredients { get; set; } 
        public object[] unusedIngredients { get; set; }
    }
}
