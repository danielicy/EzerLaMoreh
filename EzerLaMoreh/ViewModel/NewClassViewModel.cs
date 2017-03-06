using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Models;
using CommonClasses.Interfaces;
using EzerLaMoreh.Helpers;
using EzerLaMoreh.ViewModel.Helpers;
using System.Threading;
using System.Collections.ObjectModel;

namespace EzerLaMoreh.ViewModel
{
    public class NewClassViewModel : WorkspaceViewModel
    {
        #region private Properties

        private Class1WorkSpaceViewModel class1WorkSpaceViewModel;

        #endregion

        #region Constructor

        public NewClassViewModel(Class1WorkSpaceViewModel _class1WorkSpaceViewModel)
        {           
          
            class1WorkSpaceViewModel = _class1WorkSpaceViewModel;

            m_Model = new Class1();

            
            this.OKCommand = new DelegateCommand((o) => this.OK());            
        }

        #endregion

        private Class1 m_Model;

        public Class1 Model
        {
            get { 
                return m_Model;
            }
            set {
                m_Model = value;
                OnPropertyChanged("Model");
            }
        }

        #region Commands    
        
        private void OK()
        {
            m_Model.ClassID = this.class1WorkSpaceViewModel.AllClasses.Max(m => m.Model.ClassID + 1);
            m_Model.StudentColllection = new System.Collections.ObjectModel.Collection<Student>();

            App.unit.AddClass(m_Model);            

            Class1ViewModel vm = new Class1ViewModel(m_Model);

            this.class1WorkSpaceViewModel.AllClasses.Add(vm);        //.AllDepartments.Add(vm);

            Thread t = new Thread(new ThreadStart(() => App.unit.Save()));    // class1WorkSpaceViewModel.unitOfWork.Save()));
            t.Start();

            this.CloseCommand.Execute(null);
          

        }

        #endregion

    }
}
