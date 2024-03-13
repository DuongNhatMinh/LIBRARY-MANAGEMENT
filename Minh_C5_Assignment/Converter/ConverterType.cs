using System;
using System.Windows.Data;

namespace Minh_C5_Assignment
{
    class ConverterType : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool index = (bool)value;
            if (index == false)
                return "Trẻ Em";
            else if (index == true)
                return "Người Lớn";
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
