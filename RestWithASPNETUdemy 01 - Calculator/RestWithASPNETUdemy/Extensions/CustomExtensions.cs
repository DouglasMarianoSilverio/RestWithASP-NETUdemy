using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Extensions
{
    public static class CustomExtensions
    {
        public static Boolean IsNumeric(this String input)
        {
            bool isNumber = double.TryParse(input, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out _);
            return isNumber;
        }
    }
}
