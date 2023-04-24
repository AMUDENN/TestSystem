using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestSystem.Resources.Converters
{
    public class ShortStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is null || value is null) return value;
            int count = System.Convert.ToInt32(parameter);
            string str = (string)value;
            if (str.Length < count) return str;
            return str.Substring(0, count) + "...";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
