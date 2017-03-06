using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace Utilities
{
    public class RegistryClass
    {
        public static void RegDefaultPath(string path)
        {
            switch (MessageBox.Show("האם תרצה להגדיר קובץ זה כברירת מחדל?", path, MessageBoxButton.YesNo))
            {
                case MessageBoxResult.Yes:
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\EzerLamoreh", "Default Path", path, RegistryValueKind.String);
                    break;

                case MessageBoxResult.No:

                    break;
            }
        }

        public static MessageBoxResult NoDefaultFile()
        {
            MessageBoxResult result =new MessageBoxResult();

            switch (MessageBox.Show("\n" + "לא הוגדר קובץ ברירת מחדל\n" + "לחץ כן לבחירת קובץ קיים  \n" +
                      "לחץ לא ליצירת קובץ חדש \n" + " או לחץ ביטול ליציאה", "לא קיים קובץ ברירת מחדל",
                      MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign))
            {
                case MessageBoxResult.Yes://define and open default file
                   
                   // OpenFile();
                   result = MessageBoxResult.Yes;
                    break;
                case MessageBoxResult.No://create new file

                    //SaveAs();
                    result = MessageBoxResult.No;
                    break;
                case MessageBoxResult.Cancel:
                    result = MessageBoxResult.Cancel;
                    break;
            }

            return result;
        }
    }
}
