using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerMobile.Objects
{
    public class ConversionResponse
    {
        public double sourceAmount { get; set; }
        public string sourceUnit { get; set; }
        public double targetAmount { get; set; }
        public string targetUnit { get; set; }
        public string answer { get; set; }
    }
}
