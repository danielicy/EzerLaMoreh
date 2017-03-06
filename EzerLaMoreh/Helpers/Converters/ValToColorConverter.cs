using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;

namespace  Converters
{
    [ValueConversion(typeof(Enum), typeof(Brush))]
    public class ValToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            FrameworkElement FrameElem = new FrameworkElement();

            
           
            int i = (int)value;
            //    OkBrush  ,  WarningBrush , AlertBrush
            Brush brush = Brushes.Aqua;
           
            switch (i)
            {
                case 1:
                    brush = (FrameElem.FindResource("AlertBrush") as Brush);
                    break;
                case 2:
                    brush = (FrameElem.FindResource("WarningBrush") as Brush);
                    break;
                case 3:
                    brush = (FrameElem.FindResource("OkBrush") as Brush);
                    break;
            }

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object o = value;

            return o;
        }
    }
}
