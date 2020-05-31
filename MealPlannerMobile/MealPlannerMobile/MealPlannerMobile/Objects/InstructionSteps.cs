using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerMobile
{
    /// <summary>
    /// Ingredients used within the step
    /// </summary>
    public struct StepIngredient
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    /// <summary>
    /// Equiptment used in the step
    /// </summary>
    public struct StepEquiptment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    /// <summary>
    /// How long the step takes
    /// </summary>
    public struct StepLength
    {
        public int number { get; set; }
        public string unit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    class InstructionSteps
    {
        public int number { get; set; }
        public string step { get; set; }
        public StepIngredient[] ingredients { get; set; }
        public StepEquiptment[] equiptment { get; set; }
        public StepLength length { get; set; }
    }
}
