using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;
using  System.Collections.ObjectModel;
using Models;
using CommonClasses.Interfaces;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using Utilities;
using System.Reflection;
using System.Windows;

namespace EzerLaMorehEntity
{
     [Serializable]
    public class EzerEntities : DCObjectContext, IEzerContext
    {          
        # region Constructors

         public EzerEntities()
         {
             //CurrentPath = Environment.CurrentDirectory + "\\tmp\\tmp.xdc";

             //if (File.Exists(CurrentPath))
             //{
             //    File.Delete(CurrentPath);
             //}
             
             //ClassCollection = new Collection<Class1>();
             //Save(CurrentPath);

              
             //Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\EzerLamoreh", "Default Path", CurrentPath, RegistryValueKind.String);
             //IsTemp = true;

             LoadContext();

         }

         public EzerEntities(string currentPath)
         {
             CurrentPath = currentPath;
             ClassCollection = new Collection<Class1>();

             if (!File.Exists(currentPath))
             {
                 Save(currentPath);
             }
            
         }
                  
         public EzerEntities(bool noDefault)
         {    
         
         }

        #endregion

        #region Private DataMembers
         private string currentPath;
         private ICollection<Class1> _classCollection;
        
         private int _year;
         
         #endregion

         #region Properties
         public ICollection<Class1> ClassCollection
        {
            get
            {
                if ((_classCollection == null))
                {
                    _classCollection = new List<Class1>();
                }
                return _classCollection;
            }
            set
            {
                _classCollection = value;
            }
        }
            
         
         public int Year
         {
             get { return _year; }
             set { _year = value; }
         }
         
         public string CurrentPath
         {
             get { return currentPath; }
             set { currentPath = value; }
         }

         public bool IsTemp { get; set; }

         public bool isCanceled { get; set; }
         #endregion

         #region Methods

          public void LoadContext()
          {

            if (File.Exists((string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\EzerLamoreh", "Default Path", null)))
            {
                try
                {
                    SerializeContext((string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\EzerLamoreh", "Default Path", null));
                }
                catch
                {
                    NoDefaultProxy();
                }
            }
            else
            {
                NoDefaultProxy();
            }
           
        }

          public void OpenFile()
          {              
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
                RegistryClass.RegDefaultPath(dlg.FileName);

                  //this.e = new EzerEntities();
                  SerializeContext(dlg.FileName);
                  //   e.CurrentPath = dlg.FileName;
              }
              // return ez;
          }

         public void Save()
         {
             if (CurrentPath == null || IsTemp)
             {
                 throw new FileNotFoundException("בחר מיקום לשמירת קובץ");
             }
             SaveAs(CurrentPath);
         }
         
         public void Save(string path)
        {
            SaveAs(path);
        }

         public void SaveAs()
         {
             SaveFileDialog sfd = new SaveFileDialog();
             sfd.Filter = "Ezer LaMoreh DataFiles (.xdc)|*.xdc|AllFiles | *.*";
             sfd.ShowDialog();
             if (sfd.FileName != "")
             {
                 
                RegistryClass.RegDefaultPath(sfd.FileName);
                CurrentPath = sfd.FileName;
                 //return new EzerEntities(sfd.FileName);

             }
             else
             {
                // return new EzerEntities();
             }
         }
         
         public void SaveAs(string path)
        {            
            BinaryFormatter formatter = new BinaryFormatter();

           
            // Create a FileStream that will write data to file.
            FileStream writerFileStream;

            try
            {
                writerFileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            }
            catch (IOException iox)
            { 
                writerFileStream = new FileStream(path, FileMode.Append, FileAccess.Write);

            }
        

            // Save our dictionary of friends to file
            formatter.Serialize(writerFileStream, this);

            // Close the writerFileStream when we are done.
            writerFileStream.Close();                         

        }

         public void Refresh()
         {
            
         }

         void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

         private void SerializeContext(string _path)
         {
             FileStream readerFileStream = null;

             BinaryFormatter formatter = new BinaryFormatter();
             formatter = new BinaryFormatter();
             // Open a FileStream that will write data to file.
             readerFileStream = new FileStream(_path, FileMode.Open, FileAccess.Read);
             
             IEzerContext o = (IEzerContext)formatter.Deserialize(readerFileStream);
             
             ReadProperties(o);
    
             readerFileStream.Close();

         }

         private void NoDefaultProxy()
         {
             MessageBoxResult res=RegistryClass.NoDefaultFile();

             if (res == MessageBoxResult.Yes)
             {
                 OpenFile();
             }
             else if (res == MessageBoxResult.No)
             {
                 SaveAs();
             }
             else
             {
                 isCanceled = true;
             }
            
                 
             
         }
        

         /// <summary>
         /// sets all properities in this to serialized values
         /// </summary>
         /// <param name="ezerObject">Serialized IEzerConntext Object</param>
         private void ReadProperties(IEzerContext ezerObject)
         {
             Type type =  ezerObject.GetType();
             PropertyInfo[] info =  type.GetProperties();

             Type thisType = this.GetType();


             foreach (PropertyInfo i in info)
             {
                 PropertyInfo thisProp = thisType.GetProperty(i.Name );

                 thisProp.SetValue(this, i.GetValue(ezerObject,null), null);
             }

            

         }
               
         #endregion

    }
}
