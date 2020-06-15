using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerMobile.Models
{
    class HomePageModel
    {
        public string RecipeImage { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="recipe"></param>
        public HomePageModel(Recipe recipe)
        {
            RecipeImage = recipe.image;
        }
    }
}
