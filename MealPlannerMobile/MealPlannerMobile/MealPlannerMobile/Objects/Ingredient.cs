using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerMobile
{
    /// <summary>
    /// A measurement either us or metric
    /// </summary>
    public struct Measurement
    {
        public double amount { get; set; }
        public string unitShort { get; set; }
        public string unitLong { get; set; }
    }

    /// <summary>
    /// The measurements used in the ingredients
    /// </summary>
    public struct Measures
    {
        public Measurement us { get; set; }
        public Measurement metric { get; set; }
    }

    /// <summary>
    /// Base ingredients
    /// </summary>
    public class Ingredient
    {
        public int? id { get; set; } // There was just a random item that had a null ID
        public string aisle { get; set; } 
        public string image { get; set; } 
        public string consistency { get; set; } 
        public string name { get; set; }
        public string original { get; set; } 
        public string originalString { get; set; }
        public string originalName { get; set; } 
        public double amount { get; set; }
        public string unit { get; set; }
        public string[] meta { get; set; } 
        public string[] metaInformation { get; set; } 
        public Measures measures { get; set; }

        /// <summary>
        /// Returns a string of the name amount and unit e.g. - Broccoli 0.75 cups
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("- {0} {1} {2}", name, amount, unit);
        }
    }

    /// <summary>
    /// For some reason the missed ingredients are different to the normal ingredients
    /// perhaps abstract this to iherit?
    /// </summary>
    public class MissedIngredients
    {
        public int? id { get; set; }
        public double amount { get; set; }
        public string unit { get; set; }
        public string unitLong { get; set; }
        public string unitShort { get; set; }
        public string aisle { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string originalString { get; set; }
        public string originalName { get; set; }
        public string[] metaInformation { get; set; }       // 
        public string[] meta { get; set; }
        public string image { get; set; }                   // the url where the image is saved
    }

    
}
