using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerMobile
{
    /// <summary>
    /// 
    /// </summary>
    public class AnalyzedInstructions
    {
        public string name { get; set; }
        public InstructionSteps[] steps { get; set; }

        /// <summary>
        /// Returns the steps into a string list
        /// </summary>
        /// <returns></returns>
        public List<string> ToList()
        {
            return steps.Select(x => string.Format("{0} {1} \n {2}", x.number, x.length.ToString(), x.step)).ToList();
        }
    }
}
