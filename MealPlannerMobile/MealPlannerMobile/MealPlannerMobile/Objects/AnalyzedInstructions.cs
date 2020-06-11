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

        public override string ToString()
        {
            return String.Format("");
        }
    }
}
