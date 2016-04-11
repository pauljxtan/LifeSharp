using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace LifeSharp.ViewModel
{
    // TODO: Allow user to choose colors
    public class IntToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int integerValue = (int)value;

            if (integerValue == 0) return Colors.White;
            if (integerValue == 1) return Colors.Black;

            throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color colorValue = (Color)value;

            if (colorValue.Equals(Colors.White)) return 0;
            if (colorValue.Equals(Colors.Black)) return 1;

            throw new ArgumentException();
        }
    }
}
