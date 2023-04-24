using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestSystem.Resources.Converters
{
    public class UniformGridColumnsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is null || value is null) return 1;
            int gridWidth = System.Convert.ToInt32(value);
            int itemWidth = System.Convert.ToInt32(parameter);
            int columns = gridWidth < itemWidth ? 1 : (int)Math.Truncate((double)(gridWidth / itemWidth));
            return columns;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
