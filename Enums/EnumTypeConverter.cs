using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;
 

namespace Enums
{ 
    public  class EnumTypeConverter : EnumConverter
    {
        public EnumTypeConverter(Type enumType) : base(enumType) { }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value != null)
            {
                var enumType = value.GetType();
                if (enumType.IsEnum)
                    return GetDisplayName(value);
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
        public  string GetDisplayName(object enumValue)
        {
            var displayNameAttribute = EnumType.GetField(enumValue.ToString())
                                                                 .GetCustomAttributes(typeof(EnumDisplayNameAttribute), false)
                                                                 .FirstOrDefault() as EnumDisplayNameAttribute;
            if (displayNameAttribute != null)
                return displayNameAttribute.DisplayName;

            return Enum.GetName(EnumType, enumValue);
        }
    }

    public sealed class EnumValueToDecriptionConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            
            Type t = null;
            if (value.GetType().BaseType == typeof(System.Reflection.PropertyInfo))
            {
                t = ((System.Reflection.PropertyInfo)value).PropertyType;
                var attributes = t.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>()
                            .FirstOrDefault();
                return  attributes.Description;
            }
            else if (value.GetType().BaseType == typeof(Enum))
            {
                t = value.GetType();

                EnumTypeConverter etConverter = new EnumTypeConverter(t);
                etConverter.GetDisplayName(value);
                return etConverter.GetDisplayName(value);
            }

            else
            { return null; }
       //  object o=   value.GetType().BaseType;

           

        
          
 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }

   
}
