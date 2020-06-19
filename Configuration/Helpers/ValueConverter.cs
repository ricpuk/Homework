using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Helpers
{
    public static class ValueConverter
    {
        public static T ConvertTo<T>(string value)
        {
            return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}
