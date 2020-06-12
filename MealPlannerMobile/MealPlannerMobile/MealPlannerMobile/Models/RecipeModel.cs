using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Extensions;

namespace MealPlannerMobile.Models
{
    class RecipeModel
    {
        public List<string> FormattedIngredients { get; }
        public List<string> FormattedSteps { get; }
        public string ImageURL { get; }
        public string RecipeName { get; }
        public string PricePerServing { get; }
        public string PrepTime { get; }
        public RecipeModel(Recipe recipe)
        {
            ImageURL = recipe.image;
            RecipeName = recipe.title;
            PrepTime = Convertion.ToReadableTime(recipe.readyInMinutes);
            PricePerServing = string.Format("${0} per serving", Math.Round((recipe.pricePerServing / 100), 2));
            FormattedIngredients = Convertion.ToList(recipe.extendedIngredients);
            FormattedSteps = recipe.analyzedInstructions[0].ToList();
        }
    }
}
