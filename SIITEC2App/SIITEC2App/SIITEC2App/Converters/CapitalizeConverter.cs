using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace SIITEC2App.Converters
{
    class CapitalizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }

            string result = ((string)value).ToLower();
            result = Regex.Replace((string)value, @"\b(\w)", m => m.Value.ToUpper());
            result = Regex.Replace(result, @"(\s(de|del|la|las|los|en|y|para|el))\b", m => m.Value.ToLower(), RegexOptions.IgnoreCase);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
