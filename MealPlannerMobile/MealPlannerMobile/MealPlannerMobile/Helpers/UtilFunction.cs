using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerMobile
{
    static class UtilFunction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string ParameterToString(object obj)
        {
            if (obj is DateTime)
                return ((DateTime)obj).ToString();
            else if (obj is List<string>)
                return String.Join(",", (obj as List<string>).ToArray());
            else
                return Convert.ToString(obj);
        }
    }
}
