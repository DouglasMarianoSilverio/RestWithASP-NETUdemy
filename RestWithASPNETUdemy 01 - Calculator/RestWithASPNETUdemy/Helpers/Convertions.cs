using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Helpers
{
    public static class Convertions
    {
        public static decimal ConvertToDecimal(string value)
        {
            decimal decimalValue;

            if (decimal.TryParse(value, out decimalValue)) ;

            return decimalValue;
        }
    }
}
