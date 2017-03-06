using System;
using EzerLaMorehEntity;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using CommonClasses.Interfaces;

namespace EzerLaMoreh.Helpers
{
    public class LoadContext : Models.ModelBase 
    {
        private EzerEntities e;
      

        public LoadContext()
        {

            if (File.Exists((string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\EzerLamoreh", "Default Path", null)))
            {
                try
                {
                    SerializeContext((string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\EzerLamoreh", "Default Path", null));
                }
                catch
                {
                    NoDefaultFile();
                }
            }
            else
            {
                NoDefaultFile();                 
            }
           
        }

        public EzerEntities Context
        {
            get { return e; }
           
        }

        private void SerializeContext(string _path)
        { 
            FileStream readerFileStream = null;
               
                   BinaryFormatter formatter = new BinaryFormatter();
                   formatter = new BinaryFormatter();
                   // Open a FileStream that will write data to file.
                   readerFileStream = new FileStream(_path, FileMode.Open, FileAccess.Read);

                   // object o = (EzerEntities)formatter.Deserialize(readerFileStream);

                   e = (EzerEntities)formatter.Deserialize(readerFileStream);
                   e.CurrentPath = _path;
                   readerFileStream.Close();

        }

        public  void NoDefaultFile()
        {
            switch (MessageBox.Show("\n" + "לא הוגדר קובץ ברירת מחדל\n" + "לחץ כן לבחירת קובץ קיים  \n" +
                      "לחץ לא ליצירת קובץ חדש \n" + " או לחץ ביטול ליציאה", "לא קיים קובץ ברירת מחדל",
                      MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign))
            {
                case MessageBoxResult.Yes://define and open default file
                    OpenFile();
                    break;
                case MessageBoxResult.No://create new file
                    SaveAs();
                     
                    break;
                case MessageBoxResult.Cancel:

                    break;
            }
        }

        public void  OpenFile()
        {
            //IEzerContext ez = new EzerEntities();
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".xdc";
            dlg.Filter = "Ezer LaMoreh DataFiles (.xdc)|*.xdc";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document                            
                RegDefaultPath(dlg.FileName);

                //this.e = new EzerEntities();
                SerializeContext(dlg.FileName);
                //   e.CurrentPath = dlg.FileName;
            }
           // return ez;
        }

       

    }   
}
