using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Windows.Data;
 

namespace EzerLaMoreh.Helpers
{     

    public class AddConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result="";
            try
            {
                result = (string)values[0] + ", " + (string)values[1];
            }
            catch
            {

            }
            //int result =
            //    Int32.Parse((string)values[0]) + Int32.Parse((string)values[1]);
            return result.ToString();
        }
        public object[] ConvertBack(object value, Type[] targetTypes,
               object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
