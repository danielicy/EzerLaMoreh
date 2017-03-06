using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzerLaMoreh.ViewModel;
using EzerLaMoreh.Helpers;
using CommonClasses.Interfaces;
using System.Windows.Input;
using EzerLaMoreh.ViewModel.Helpers;
using Models;
using Microsoft.Win32;
using System.Drawing;
using System.Windows;
using EzerLaMoreh.CustomUser_Controls;
using Utilities;
using System.Windows.Documents;
using System.IO;
using EzerLaMoreh.CustomUser_Controls.ViewModels;
using System.ComponentModel;

namespace EzerLaMoreh.ViewModel
{
    public class NewStudentViewModel : WorkspaceViewModel, IDataErrorInfo
    {  
        public NewStudentViewModel(StudentWorkspaceViewModel _studentWorkspaceViewModel )    //StudentWorkspaceViewModel _studentWorkspaceViewModel)
        {            
            studentWorkspaceViewModel = _studentWorkspaceViewModel;             

            m_Model = new Student();

           m_Model.StudentId = (studentWorkspaceViewModel.AllStudents.Count>0) ? (studentWorkspaceViewModel.AllStudents.Max<StudentViewModel>(o => o.Model.StudentId) + 1) : 1;
           
            StudPic = @"F:\MyProjects\EzerLaMoreh\EzerLaMorehX\EzerLaMoreh\Resources\Images\User Accounts alt.png";
            m_Model.BirthDay = DateTime.Today;
            m_Model.ClassID = studentWorkspaceViewModel.CurrentClass.Model.ClassID;
            //Path = Environment.CurrentDirectory + "\\pix\\" + studentWorkspaceViewModel.CurrentClass.Model.ClassName + "\\";
            //FileName = m_Model.FirstName + m_Model.LastName + ".jpg";
           
            this.BrowsePicCommand = new DelegateCommand((o) => this.BrowsePic());   
           
            this.EditPicCommand = new DelegateCommand((o) => this.EditPic());          

            this.OKCommand = new DelegateCommand((o) => this.OK()); 
        }
 
        #region  Properties

        #region private Properties

        private Student m_Model; 
              
        private string origPic;
         
        #endregion

        #region public Properties

        public Student Model
        {
            get { return m_Model; }
            set {
                m_Model = value;
                OnPropertyChanged("Model");

            }
        }
                
        public string StudPic
        {
            get {
                return m_Model.pix; 
            }
            set {
                m_Model.pix = value;
                OnPropertyChanged("StudPic");
            }
        }
                  
        public EditPicViewModel epVm;
        
        public StudentWorkspaceViewModel studentWorkspaceViewModel;         
       
        public System.Windows.Controls.TextBlock tblkClippingRectangle
        { get; set; }

        
        #endregion

        #endregion

        #region Commands

        
        private void BrowsePic()
        { 

            origPic = StudPic = PixFuncs.BrowsePic();
        }

        private void EditPic()
        {             
            this.StudPic = PixFuncs.EditPic(this, out epVm);
        }
        
        private void OK()
        {

            if (!CheckID(m_Model.TZ))
                return;

            string OriginPath;

            if (epVm != null && epVm.picPath != "")
            {
                OriginPath = epVm.picPath;
            }
            else
            {
                OriginPath = m_Model.pix;
            }

            string path = Environment.CurrentDirectory + "\\pix\\" + studentWorkspaceViewModel.CurrentClass.Model.ClassName + "\\";
           string fileName = m_Model.FirstName + m_Model.LastName + ".jpg";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            bool overWrite = false;
            if (File.Exists(path + fileName))
            {
                overWrite = (MessageBoxResult.OK == MessageBox.Show("קובץ בשם זה כבר קיים\n" + "לחץ כן כדי להחליפו\n" + "או לחץ לא לביטול", "קובץ כבר קיים",
                    MessageBoxButton.OKCancel, MessageBoxImage.Exclamation));

            }
            else
            {
                File.Copy(OriginPath, path + fileName, overWrite);
            }

            m_Model.pix = path + fileName;
            
            App.unit.AddStudent(m_Model);

           

            StudentViewModel vm = new StudentViewModel(m_Model);

            this.studentWorkspaceViewModel.AllStudents.Add(vm);
           
            if (epVm != null)
            {
                epVm.picPath = "";
            }
            
            App.unit.Save();
           
            this.studentWorkspaceViewModel.CurrentStudent = vm;
            CloseCommand.Execute(null);          
        }
            
        private void Close()
        {

        }
        #endregion

        private bool CheckID(string id)
        {
            
            if (id ==null || id == "0" || id =="" || id.Length != 9  )
            {
               
                MessageBox.Show("מס' ת.ז. אינו חוקי");
                return false;
            }
            return true;
        }


        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { return (m_Model as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                string error = null;

                if (columnName == "CustomerType")
                {
                    // The IsCompany property of the Customer class 
                    // is Boolean, so it has no concept of being in
                    // an "unselected" state.  The CustomerViewModel
                    // class handles this mapping and validation.
                    error = this.ValidateCustomerType();
                }
                else
                {
                    error = (m_Model as IDataErrorInfo)[columnName];
                }

                // Dirty the commands registered with CommandManager,
                // such as our Save command, so that they are queried
                // to see if they can execute now.
                CommandManager.InvalidateRequerySuggested();

                return error;
            }
        }

        string ValidateCustomerType()
        {
            //if (this.CustomerType == Strings.CustomerViewModel_CustomerTypeOption_Company ||
            //   this.CustomerType == Strings.CustomerViewModel_CustomerTypeOption_Person)
            //    return null;

            //return Strings.CustomerViewModel_Error_MissingCustomerType;
            return "ErrorEventArgs";
        }

        #endregion
    }
}
