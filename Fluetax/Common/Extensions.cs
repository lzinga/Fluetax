using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Fluetax.Common
{
    internal static class Extensions
    {
        public static string ToCamelCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                str = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(str.ToLower());
                return Char.ToLowerInvariant(str[0]) + str.Substring(1);
            }
            return str;
        }
    }
}
