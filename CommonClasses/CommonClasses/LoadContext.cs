using System;
//using EzerLaMorehEntity;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using CommonClasses.Interfaces;


namespace EzerLaMorehEntity
{
    public class LoadContext : Models.ViewModelBase 
    {
        //private IEzerContext e;
      
        //public LoadContext()
        //{

        //    if (File.Exists((string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\EzerLamoreh", "Default Path", null)))
        //    {
        //        try
        //        {
        //            SerializeContext((string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\EzerLamoreh", "Default Path", null));
        //        }
        //        catch
        //        {
        //            NoDefaultFile();
        //        }
        //    }
        //    else
        //    {
        //        NoDefaultFile();                 
        //    }
           
        //}

        //public IEzerContext Context
        //{
        //    get { return e; }
           
        //}

        //private void SerializeContext(string _path)
        //{ 
        //    FileStream readerFileStream = null;
               
        //           BinaryFormatter formatter = new BinaryFormatter();
        //           formatter = new BinaryFormatter();
        //           // Open a FileStream that will write data to file.
        //           readerFileStream = new FileStream(_path, FileMode.Open, FileAccess.Read);

        //           // object o = (EzerEntities)formatter.Deserialize(readerFileStream);

        //           e = (IEzerContext)formatter.Deserialize(readerFileStream);
        //           e.CurrentPath = _path;
        //           readerFileStream.Close();

        //}

        //public  void NoDefaultFile()
        //{
        //    switch (MessageBox.Show("\n" + "לא הוגדר קובץ ברירת מחדל\n" + "לחץ כן לבחירת קובץ קיים  \n" +
        //              "לחץ לא ליצירת קובץ חדש \n" + " או לחץ ביטול ליציאה", "לא קיים קובץ ברירת מחדל",
        //              MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign))
        //    {
        //        case MessageBoxResult.Yes://define and open default file
        //            OpenFile();
        //            break;
        //        case MessageBoxResult.No://create new file
                   
        //            SaveAs();
                     
        //            break;
        //        case MessageBoxResult.Cancel:

        //            break;
        //    }
        //}

        //public void  OpenFile()
        //{
        //    //IEzerContext ez = new EzerEntities();
        //    // Create OpenFileDialog
        //    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

        //    // Set filter for file extension and default file extension
        //    dlg.DefaultExt = ".xdc";
        //    dlg.Filter = "Ezer LaMoreh DataFiles (.xdc)|*.xdc";

        //    // Display OpenFileDialog by calling ShowDialog method
        //    Nullable<bool> result = dlg.ShowDialog();

        //    // Get the selected file name and display in a TextBox
        //    if (result == true)
        //    {
        //        // Open document                            
        //        RegDefaultPath(dlg.FileName);

        //        //this.e = new EzerEntities();
        //        SerializeContext(dlg.FileName);
        //        //   e.CurrentPath = dlg.FileName;
        //    }
        //   // return ez;
        //}

        //public  EzerEntities SaveAs()
        //{
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Filter = "Ezer LaMoreh DataFiles (.xdc)|*.xdc|AllFiles | *.*";
        //    sfd.ShowDialog();
        //    if (sfd.FileName != "")
        //    {
        //        RegDefaultPath(sfd.FileName);
        //        return new EzerEntities(sfd.FileName);

        //    }
        //    else
        //    {
        //        return new EzerEntities();
        //    }
        //}


        //private  void RegDefaultPath(string path)
        //{
        //    switch (MessageBox.Show("האם תרצה להגדיר קובץ זה כברירת מחדל?", path, MessageBoxButton.YesNo))
        //    {
        //        case MessageBoxResult.Yes:
        //            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\EzerLamoreh", "Default Path", path, RegistryValueKind.String);
        //            break;

        //        case MessageBoxResult.No:

        //            break;
        //    }
        //}

       

    }   
}
