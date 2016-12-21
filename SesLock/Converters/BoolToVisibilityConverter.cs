using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace SesLock.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        private static Dictionary<bool, Visibility> boolToVisibility = new Dictionary<bool, Visibility>()
                {
                    { false, Visibility.Hidden },
                    { true, Visibility.Visible }
                };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return boolToVisibility[false];
            }
            return boolToVisibility[(bool)value];

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }
            return boolToVisibility.FirstOrDefault(b => b.Value.Equals(value)).Key;
        }
    }
}
