using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EzerLaMoreh.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EzerLaMoreh.ViewModel.Helpers;
using System.Windows;
using Models;

namespace EzerLaMoreh.ViewModel
{
    public class DisciplineWorkSpaceViewModel : WorkspaceViewModel
    {
        public DisciplineWorkSpaceViewModel(ObservableCollection<DisciplineViewModel> disciplineCollection)
        {
            if (disciplineCollection == null)
            {
                throw new ArgumentNullException("disciplineCollection");
            }

            this.AllDisciplines = disciplineCollection;


            EntryDate = DateTime.Today;

            DateFrom =DateTime.Today - TimeSpan.FromDays(30.0);

            DateTo = DateTime.Today;

            
         //   this.CurrentDiscipline = disciplineCollection.Count > 0 ? disciplineCollection[0] : new DisciplineViewModel();

          //  this.CurrentDiscipline.Model.EntryDate = DateTime.Today;

            this.RegisterDisciplineCommand = new DelegateCommand((o) => this.RegisterDiscipline());

            this.AllDisciplines.CollectionChanged += CollectionChanged;

            FilterDates();

            //if (CurrentDiscipline != null)
            //{
            //    this.CurrentDiscipline.PropertyChanged += CurrentDiscipline_PropertyChanged;
            //}  


           // CurrentClass.Model.DisciplineCollection

              //   StudentId  EntryDate   Presence   Arrival  Attitude   SocialBehave   Comments 
        }
        
        #region Private Fields

        private ObservableCollection<DisciplineViewModel> m_allDisciplines;

        private Class1ViewModel currentClass;

        //private StudentViewModel currentStudent;

        private DisciplineViewModel currentDiscipline;

        private DateTime m_entryDate;

        private DateTime m_DateFrom; 
        
        private DateTime m_DateTo;

        private ICollection<DisciplineClass> m_totalDisipCollection;
                           

        #endregion

        #region Public Properties

        public ObservableCollection<DisciplineViewModel> AllDisciplines
        {
            get { return m_allDisciplines; }
            set 
            { 
                m_allDisciplines = value;
                OnPropertyChanged("AllDisciplines");
            }
        }
                
        public DisciplineViewModel CurrentDiscipline
        {
            get
            {
                return this.currentDiscipline;
            }

            set
            {
                this.currentDiscipline = value;
                this.OnPropertyChanged("CurrentDiscipline");
                //if (CurrentDiscipline != null)
                //{
                //    CurrentDiscipline.IsEdit = false;
                //}

            }
        }

        public Class1ViewModel CurrentClass
        {
            get { return currentClass; }
            set
            {
                currentClass = value;
                this.OnPropertyChanged("CurrentClass");
                FilterDates();// TotalDisipCollection = CurrentClass.Model.DisciplineCollection;
            }
        }

        public ICollection<DisciplineClass> TotalDisipCollection
        {
            get { return m_totalDisipCollection; }
            set {
                m_totalDisipCollection =  value;
                this.OnPropertyChanged("TotalDisipCollection");
            }
        }
                
        public DateTime EntryDate
        {
            get { return m_entryDate; }
            set 
            { 
                m_entryDate = value;
                LoadCurrentDateDisciplines(m_entryDate);
                OnPropertyChanged("EntryDate");
            }
        }

        public DateTime DateFrom
        {
            get { return m_DateFrom; }
            set { 
                m_DateFrom = value;
                this.OnPropertyChanged("DateFrom");
                FilterDates();
            }
        }

        public DateTime DateTo
        {
            get { return m_DateTo; }
            set 
            { 
                m_DateTo = value; 
                this.OnPropertyChanged("DateTo");
                FilterDates();
            }
        }
                 
        #endregion
        
        #region Commands

        public ICommand RegisterDisciplineCommand { get; private set; }

        private void RegisterDiscipline()
        {
            //when no discipline data existss
            if (CurrentClass.Model.DisciplineCollection == null)
            {
                CurrentClass.Model.DisciplineCollection = new Collection<DisciplineClass>();
            }

            //date data exists
            if(CurrentClass.Model.DisciplineCollection.ToList().Exists(c => c.EntryDate ==  this.EntryDate))
            {               
                MessageBoxResult mbr = MessageBox.Show("האם תרצה לדרוס את הנתנונים הקיימים?", "כבר הוזנו נתונים עבור תאריך זה", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (mbr == MessageBoxResult.Yes)
                {
                    DisciplineClass[] tempCollection = new DisciplineClass[CurrentClass.Model.DisciplineCollection.Count];
                    CurrentClass.Model.DisciplineCollection.CopyTo(tempCollection,0);

                    foreach (Models.DisciplineClass dp in tempCollection)
                    {
                       if   ((dp.EntryDate == this.EntryDate ))
                       {
                           CurrentClass.Model.DisciplineCollection.Remove(dp);
                       }
                    }
                }
                else if(mbr == MessageBoxResult.No)
                { 
                    return;
                }                 
            }

            ResetDisciplines();

            TotalDisipCollection = TotalDisipCollection;
         
            App.unit.Save();

        }

        private void ResetDisciplines()
        {
            foreach (DisciplineViewModel dcVM in AllDisciplines)
            {
                dcVM.Model.EntryDate = this.EntryDate;
                CurrentClass.Model.DisciplineCollection.Add(dcVM.Model);

                dcVM.Model = DispCls(dcVM.Model.StudentId);

            }
        }      

        #endregion
       
        #region Methods
 
        public DisciplineClass DispCls(int studId)
        {
            DisciplineClass dc = new DisciplineClass();
            dc.StudentId = studId;
            dc.Presence = Enums.PresenceEnum.present;
            dc.Arrival = Enums.ArrivalEnum.onTime;
            dc.Attitude = Enums.AttitudeEnum.excellent;
            dc.SocialBehave = Enums.AttitudeEnum.excellent;
            dc.Comments = "";

            return dc;
        }

        private void FilterDates()
        {
          //  IEnumerable<DisciplineClass> dates new  IEnumerable<DisciplineClass>();

           // dates = TotalDisipCollection.Where(d => d.EntryDate > DateFrom && d.EntryDate < DateTo );
            if (CurrentClass != null)
                TotalDisipCollection = CurrentClass.Model.DisciplineCollection.Where(d => d.EntryDate >= DateFrom && d.EntryDate <= DateTo).ToList();
           
        }

        //private void CurrentDiscipline_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    App.unit.Save();
        //    //  throw new NotImplementedException();
        //}

        private void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            object obj = e;
            if (e.OldItems != null && e.OldItems.Contains(this.CurrentDiscipline))
            {
                this.CurrentDiscipline = null;
            }

        }

        private void LoadCurrentDateDisciplines(DateTime selDate)
        {
            try
            {
                foreach (DisciplineViewModel dispVM in AllDisciplines)
                {
                    dispVM.Model = TotalDisipCollection.Where(dc => dc.EntryDate == selDate && dc.StudentId == dispVM.Model.StudentId).First();
                }
            }
            catch
            {
                ResetDisciplines();
            }

            OnPropertyChanged("AllDisciplines");
        }

        #endregion
    }
}
