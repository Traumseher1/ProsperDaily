using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperDaily.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var isIncome = ((Label)parameter).Text;
            var amount = (decimal)value;

            if (isIncome == "True")
            {
                return Colors.DarkViolet;
            }
            else
            {
                return Colors.DarkRed;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
