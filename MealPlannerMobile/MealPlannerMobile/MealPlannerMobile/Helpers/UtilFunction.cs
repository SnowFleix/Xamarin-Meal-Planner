using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerMobile
{
    public static class UtilFunction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ParameterToString(object obj)
        {
            if (obj is DateTime)
                return ((DateTime)obj).ToString();
            else if (obj is List<string>)
                return String.Join(",", (obj as List<string>).ToArray());
            else
                return Convert.ToString(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsObjNumber(object obj)
        {
            try
            {
                Convert.ToDouble(obj);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalStr"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static string[] ParseString(string originalStr, char splitChar)
        {
            return originalStr.Split(splitChar);
        }
    }
}
