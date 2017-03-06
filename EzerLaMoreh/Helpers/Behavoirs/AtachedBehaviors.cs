using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace EzerLaMoreh.Helpers
{
    public static class AtachedBehaviors
    {
        public static DependencyProperty LoadedCommandProperty = DependencyProperty.RegisterAttached(
           "LoadedCommand", typeof(ICommand), typeof(AtachedBehaviors), new PropertyMetadata(null, OnLoadedCommandChanged));

        public static DependencyProperty SizeChangedCommandProperty = DependencyProperty.RegisterAttached(
          "SizeChangedCommand", typeof(ICommand), typeof(AtachedBehaviors), new PropertyMetadata(null, OnSizeChangedCommandChanged));
       

        private static void OnLoadedCommandChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = depObj as FrameworkElement;
            if (frameworkElement != null && e.NewValue is ICommand)
            {
                frameworkElement.Loaded += (o, args) => { (e.NewValue as ICommand).Execute(null); };
            }
        }

        private static void OnSizeChangedCommandChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = depObj as FrameworkElement;
            if (frameworkElement != null && e.NewValue is ICommand)
            {
                frameworkElement.SizeChanged += (o, args) => { (e.NewValue as ICommand).Execute(null); };               
            }
        }
             

        #region loaded
        public static ICommand GetLoadedCommand(DependencyObject depObj)
        {
            return (ICommand)depObj.GetValue(LoadedCommandProperty);
        }

        public static void SetLoadedCommand(DependencyObject depObj, ICommand value)
        {
            depObj.SetValue(LoadedCommandProperty, value);
        }
        #endregion

        #region sizechanged
        public static ICommand GetSizeChangedCommand(DependencyObject depObj)
        {
            return (ICommand)depObj.GetValue(SizeChangedCommandProperty);
        }

        public static void SetSizeChangedCommand(DependencyObject depObj, ICommand value)
        {
            depObj.SetValue(SizeChangedCommandProperty, value);
        }


        #endregion

       



    }

  
    
     
}
