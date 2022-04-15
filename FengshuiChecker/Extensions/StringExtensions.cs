using System;
using System.Collections.Generic;
using System.Linq;

namespace FengshuiChecker.Console.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extract numeric from string
        /// </summary>
        public static String GetNumeric(this string data)
        {
            if (data == null || "".Equals(data))
            {
                return "";
            }

            string num = "";
            List<char> numChar = data.Where(c => char.IsDigit(c)).Select(c => c).ToList();
            num = string.Join(string.Empty, numChar);
            return num;
        }
    }
}
