using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Extensions;

namespace MealPlannerMobile.Models
{
    class RecipeModel
    {
        public Ingredient[] Ingredients { get; }
        public Step[] Steps { get; }
        public string ImageURL { get; }
        public string RecipeName { get; }
        public string PricePerServing { get; }
        public string PrepTime { get; }

        public class Step
        {
            public int Number { get; set; }
            public string Time { get; set; }
            public string StepText { get; set; }
        }

        public RecipeModel(Recipe recipe)
        {
            ImageURL = recipe.image;
            RecipeName = recipe.title;
            PrepTime = Convertion.ToReadableTime(recipe.readyInMinutes);
            PricePerServing = string.Format("${0} per serving", Math.Round((recipe.pricePerServing / 100), 2));
            Steps = SortThroughSteps(recipe.analyzedInstructions[0].steps);
            Ingredients = recipe.extendedIngredients;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="steps"></param>
        /// <returns></returns>
        private Step[] SortThroughSteps(InstructionSteps[] steps)
        {
            List<Step> totalSteps = new List<Step>();
            foreach (InstructionSteps instruction in steps)
            {
                totalSteps.Add(new Step
                {
                    Number = instruction.number,
                    Time = instruction.length.ToString(),
                    StepText = instruction.step
                });
            }
            return totalSteps.ToArray();
        }
    }
}
