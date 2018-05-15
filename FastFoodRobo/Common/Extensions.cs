using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodRobo.Common
{
    public static class Extensions
    {
        public static string GetDescription(this Enum value)
        {
            var attributes =
                (DescriptionAttribute[])value.GetType().GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
