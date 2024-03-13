using System;
using System.Windows.Data;

namespace Minh_C5_Assignment
{
    public class StatusToStringConverter : IValueConverter
    {
        // Chuyển đổi giá trị 0 - Windows Authentication thành false 
        // 1- sẽ trở thành true
        // Dùng cho combobox Authentication và Textbox Username / Pass
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool index = (bool)value;
            if (index == false)
                return "Khoá";
            else if (index == true)
                return "Sử Dụng";
            return string.Empty;
        }

        public object ConvertType(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool index = (bool)value;
            if (index == false)
                return "Trẻ Em";
            else if (index == true)
                return "Người Lớn";
            return string.Empty;
        }

        public object ConvertIsAdmin(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool index = (bool)value;
            if (index == false)
                return "";
            else if (index == true)
                return "Admin";
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
