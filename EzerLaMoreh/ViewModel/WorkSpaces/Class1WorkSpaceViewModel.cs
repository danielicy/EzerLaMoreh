using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzerLaMoreh.Helpers;
using EzerLaMoreh.ViewModel;
using CommonClasses.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EzerLaMoreh.ViewModel.Helpers;
using Models;
using EzerLaMoreh.View.add;
using System.Windows;


namespace EzerLaMoreh.ViewModel
{
    public class Class1WorkSpaceViewModel : WorkspaceViewModel 
    {
        

        private Class1ViewModel currentClass;

        private IEzerContext context;

        public Class1WorkSpaceViewModel(ObservableCollection<Class1ViewModel> classes, IEzerContext _context)//, IUnitOfWork unitOfWork )
        {
            if (classes == null)
            {
                throw new ArgumentNullException("departments");
            }

            context = _context;
            
            this.AllClasses = classes;
            this.AllClasses.CollectionChanged += CollectionChanged; 

            var current = from c in this.AllClasses
                          where c.Model.IsDefault == true
                          select c;
            foreach (Class1ViewModel cv in current)
            {
                this.CurrentClass = cv;
            }

            if (this.AllClasses.Count > 0)
            {
                if (this.CurrentClass == null)
                {
                    this.CurrentClass = this.AllClasses[0];
                }
            }
            else
            {
                
            }

            this.addClass1Command = new DelegateCommand((o) => this.AddClass());
            this.DeleteClassCommand  = new DelegateCommand((o) => this.DeleteClass());
            
        }

        private void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null && e.OldItems.Contains(this.CurrentClass))
            {
                if (this.AllClasses.IndexOf(this.CurrentClass) > 0)
                {
                    this.CurrentClass = this.AllClasses[this.AllClasses.IndexOf(this.CurrentClass) - 1];
                }
                else
                {
                    this.CurrentClass = this.AllClasses[0];
                }
            }
        }
                             

        /// <summary>
        /// Gets all departments whithin the company
        /// </summary>
        public ObservableCollection<Class1ViewModel> AllClasses { 
            get; 
            private set;
        }

        /// <summary>
        /// Gets or sets the deprtment currently selected in the workspace
        /// </summary>
        public Class1ViewModel  CurrentClass
        {
            get
            {
                return this.currentClass;
            }

            set
            {
                this.currentClass = value;
                Mediator.NotifyColleagues("notifyStudentsWorkSpace", currentClass);
               // Mediator.NotifyColleagues("notifyDisciplineWorkSpace", currentClass);
                this.OnPropertyChanged("CurrentClass");
                NotifyCurrentClass();             
               
            }
        }

        private void NotifyCurrentClass()
        {
            foreach (Class1ViewModel cl in AllClasses)
            {
                cl.Model.IsCurrent = false;
                if(cl.Model.ClassID==CurrentClass.Model.ClassID)
                    cl.Model.IsCurrent=true;
            }
        }

        #region Commands

        /// <summary>
        /// Gets the command to add a new class
        /// </summary>
        public ICommand addClass1Command { get; private set; }

        /// <summary>
        /// Adds NewClass
        /// </summary>
        private void AddClass()
        {
            EzerLaMoreh.Services.ServiceProvider.Instance.Register<IModalDialog, AddDialogView<NewClassModalDialog>>();
            IModalDialog dialog = Services.ServiceProvider.Instance.Get<IModalDialog>();
            NewClassViewModel newClassDialogVM = new NewClassViewModel(this);

            newClassDialogVM.CloseCommand = new DelegateCommand((o) => dialog.CloseDialog());

            dialog.BindViewModel(newClassDialogVM);
            dialog.ShowDialog();
        }
        
        //
          /// <summary>
        /// Gets the command to delete an existing class  
        /// </summary>
        public ICommand DeleteClassCommand { get; private set; }
               
        /// <summary>
        /// Adds NewClass
        /// </summary>
        private void DeleteClass()
        {
            if (MessageBoxResult.OK == MessageBox.Show("האם אתה בטוח שברצונך למחוק את " +
                this.CurrentClass.Model.ClassName , "רק מוודא", MessageBoxButton.OKCancel, MessageBoxImage.Question))
            {
                 
               App.unit.RemoveClass(this.CurrentClass.Model);
                 this.AllClasses.Remove(this.CurrentClass);                
             
                 App.unit.Save();
            }
        
        }

        #endregion

    }
    

   
}
