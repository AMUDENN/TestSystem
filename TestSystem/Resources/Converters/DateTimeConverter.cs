using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestSystem.Resources.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return value;
            DateTime dt = (DateTime)value;
            return dt.ToString("dd.MM.yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
