using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The use of these classes are for deserialising the JSON sent from the spoonacular API and making it easy to acess the data sent while stil
/// being readable
/// </summary>
namespace MealPlannerMobile
{
    /// <summary>
    /// 
    /// </summary>
    class Result
    {
        public Recipe[] results { get; set; }    // Items represents the recipes found
        public int offset { get; set; }         //
        public int number { get; set; }         // 
        public int totalResults { get; set; }   //
    }
}
