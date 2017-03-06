using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using EzerLaMoreh.CustomUser_Controls;
using EzerLaMoreh.CustomUser_Controls.ViewModels;
using EzerLaMoreh.ViewModel.Helpers;
using System.Windows;
using System.Reflection;
using System.ComponentModel;


namespace EzerLaMoreh.Helpers
{
    public static class PixFuncs
    {
        public static string BrowsePic()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Image Files (*.bmp, *.jpg, *.png ,*.gif)|*.bmp;*.jpg;*.png;*.gif";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                return dlg.FileName;

            }
            else
                return "";
        }

        public static string EditPic( object sender, out EditPicViewModel epVm)
        {
            EditPicWindow editpicWin = new EditPicWindow();

            epVm = new EditPicViewModel(sender, editpicWin);
            editpicWin.DataContext = epVm;

            epVm.CloseCommand = new DelegateCommand((o) => editpicWin.Close());
          
            editpicWin.Show();
            return epVm.StudPic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="wait">bool definition true if continue sender thread
        /// false if wait for thread to finish</param>
        /// <returns></returns>
        public static void DeletePic(string path )
        {                       
                (new System.Threading.Thread(() =>
                {
                    while (true)
                    {
                       
                        try
                        {
                            System.IO.File.Delete(path);
                            MessageBox.Show("Picture Removed");
                            break;
                        }
                        catch
                        {
                            GC.Collect();                            
                        }
                    }
                })).Start();            

           
        }

    }

        
   
}
