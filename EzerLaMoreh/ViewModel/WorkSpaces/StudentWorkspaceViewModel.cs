using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzerLaMoreh.ViewModel.Helpers;
using CommonClasses.Interfaces;
using Models;
using System.Windows.Input;
using System.Threading;
using EzerLaMoreh.View.add;
using System.Windows;
using System.Reflection;
using EzerLaMoreh.CustomUser_Controls.ViewModels; 
using System.Collections.ObjectModel;
using EzerLaMoreh.Helpers;
using Enums;


namespace EzerLaMoreh.ViewModel
{

    public class StudentWorkspaceViewModel : WorkspaceViewModel
    {
       public EditPicViewModel epVm;

      
            
        /// <summary>
        /// Initializes a new instance of the StudentWorkspaceViewModel class.
        /// </summary>
        /// <param name="employees">Employees to be managed</param>
        /// <param name="departmentLookup">The departments to be used for lookups</param>
        /// <param name="unitOfWork">UnitOfWork for managing changes</param>
       public StudentWorkspaceViewModel(ObservableCollection<StudentViewModel> students, ICollection<DisciplineClass> _allDiscipCollection)
        {
            if (students == null)
            {
                throw new ArgumentNullException("student");
            }
 
            this.AllStudents = students;
            
            this.CurrentStudent = students.Count > 0 ? students[0] : null;

            this.AllStudents.CollectionChanged += CollectionChanged;
        
           


            this.allDiscipCollection = _allDiscipCollection;
            if (CurrentStudent != null)
            {
                this.CurrentStudent.PropertyChanged += CurrentStudent_PropertyChanged;
            }              

            this.AddStudentCommand = new DelegateCommand((o) => this.AddStudent());
            this.DeleteStudentCommand = new DelegateCommand((o) => this.DeleteCurrentStudent(), (o) => this.CurrentStudent != null);
            this.EditStudentCommand = new DelegateCommand((o) => this.EditStudent());
            this.BrowsePicCommand = new DelegateCommand((o) => this.BrowsePic());
            this.EditPicCommand = new DelegateCommand((o) => this.EditPic());

            SelectedPropCollection = new ObservableCollection<KeyValuePair<DateTime, double>>();
             
            SelectedPropertyInfo = typeof(DisciplineClass).GetProperty("SocialBehave");
           SelectedPeriod = PeriodEnum.lastWeek;
        }

        #region   Fields
         
        private Class1ViewModel currentClass;

        private StudentViewModel currentStudent;
        
        private ICollection<DisciplineClass> allDiscipCollection;

        private DateTime m_dateStart;

        private DateTime m_dateEnd;

        private PeriodEnum selectedPeriod;

        //private PresenceTotEnum m_avgPresence;

        //private AttitudeTotEnum m_avgSoc;

        //private AttitudeTotEnum m_avgAtt;

        //private ArrivalTotEnum m_avgArr;

        private ObservableCollection<KeyValuePair<DateTime, double>> m_selectedPropArray;
         
        private System.Reflection.PropertyInfo m_selectedProperty;

        private object rows;

      
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets all students whithin the company
        /// </summary>
        public ObservableCollection<StudentViewModel> AllStudents 
        { 
            get; private set;
        }         

        /// <summary>
        /// Gets or sets the student currently selected in this workspace
        /// </summary>
        public StudentViewModel CurrentStudent
        {
            get
            {
                return this.currentStudent;
            }

            set
            {
                this.currentStudent = value;
                CalculateDiscipline();
                this.OnPropertyChanged("CurrentStudent");
                
                if (CurrentStudent != null)
                {
                    CurrentStudent.IsEdit = false;
                }                
            }
        }
     
        public Class1ViewModel CurrentClass
        {
            get { return currentClass; }
            set
            {
                currentClass = value;
                this.OnPropertyChanged("CurrentClass");                
            }
        }

        /// <summary>
        ///start date for evaluation calculations
        /// </summary>
        public DateTime DateStart
        {
            get { return m_dateStart; }
            set { m_dateStart = value;
            CalculateDiscipline();
            OnPropertyChanged("DateStart");
            }
        }
        
        /// <summary>
        /// start date for evaluation calculations
        /// </summary>
        public DateTime DateEnd
        {
            get { return m_dateEnd; }
            set 
            { 
                m_dateEnd = value;
                CalculateDiscipline();
                OnPropertyChanged("DateEnd");
            }
        }
                  
        public PeriodEnum SelectedPeriod
        {
            get { return selectedPeriod; }
            set
            {
                selectedPeriod = value;   
                PeriodChanged();
                this.OnPropertyChanged("SelectedPeriod");               
            }
        }

        #region Behave Averages

        //public PresenceTotEnum AvgPresence
        //{
        //    get { return m_avgPresence; }
        //    set
        //    {
        //        m_avgPresence = value;
        //        OnPropertyChanged("AvgPresence");
        //    }
        //}

        //public ArrivalTotEnum AvgArr
        //{
        //    get { return m_avgArr; }
        //    set
        //    {
        //        m_avgArr = value;
        //        OnPropertyChanged("AvgArr");
        //    }
        //}

        //public AttitudeTotEnum AvgSoc
        //{
        //    get { return m_avgSoc; }
        //    set { m_avgSoc = value;
        //    OnPropertyChanged("AvgSoc");
        //    }
        //}

        //public AttitudeTotEnum AvgAtt
        //{
        //    get { return m_avgAtt; }
        //    set { m_avgAtt = value; }
        //}

        private ObservableCollection<KeyValuePair<string, Enum>> m_averageCollection;

        public ObservableCollection<KeyValuePair<string, Enum>> AverageCollection
        {
            get { return m_averageCollection; }
            set
            {
                m_averageCollection = value;
                OnPropertyChanged("AverageCollection");
            }
        }

        public ObservableCollection<KeyValuePair<DateTime, double>> SelectedPropCollection
        {
            get { return m_selectedPropArray; }
            set
            {
                m_selectedPropArray = value;
                OnPropertyChanged("SelectedPropCollection");
            }
        }

        public System.Reflection.PropertyInfo SelectedPropertyInfo
        {
            get { return m_selectedProperty; }
            set { 
                m_selectedProperty = value;
                OnPropertyChanged("SelectedPropertyInfo");
            }
        }

        public object Rows
        {
            get { return rows; }
            set { 
                rows = value;                
                SelectPropertyChange(value);
                OnPropertyChanged("Rows");
            }
        }

       
        #endregion

        #endregion

        #region Methods

        private void CurrentStudent_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            App.unit.Save();
          //  throw new NotImplementedException();
        }

        private void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            object obj=e;
            if (e.OldItems != null && e.OldItems.Contains(this.CurrentStudent))
                {
                    this.CurrentStudent = null;
                }
            
        }
              
        private void PeriodChanged()
        {            
            DateEnd = DateTime.Today;

            switch (SelectedPeriod)
            {
                case PeriodEnum.lastWeek:
                    DateStart = DateTime.Today.AddDays(-7);
                    break;
                case PeriodEnum.lastMonth:
                    DateStart = DateTime.Today.AddDays(-30);
                    break;
                case PeriodEnum.currentHalf:

                    break;
                case PeriodEnum.previosHalf:

                    break;
                case PeriodEnum.customPeriod:

                    break;
                 default:

                    break;

            }
            CalculateDiscipline();
        }

        private void SelectPropertyChange(object  val)
        {
            if (val == null)
                return;

            KeyValuePair<string, Enum> selObj = (KeyValuePair<string, Enum>)val;
             switch (selObj.Key)
             {
                 case "נוכחות":
                     SelectedPropertyInfo = typeof(DisciplineClass).GetProperty("Presence");
                     break;
                 case "הגעה בזמן":
                     SelectedPropertyInfo = typeof(DisciplineClass).GetProperty("Arrival");
                     break;
                 case "יחס ללימודים":
                     SelectedPropertyInfo = typeof(DisciplineClass).GetProperty("Attitude");
                     break;
                 case "יחס לחברים":
                     SelectedPropertyInfo = typeof(DisciplineClass).GetProperty("SocialBehave");
                     break;
             }
             CalculateDiscipline();
        }

        #region Calculation Methods

        private int CalcTot(double val)
        {
            int tot;

            if (val > 0 && val <= 1.5)
            {
                tot = 4;// ArrivalTotEnum.alwaysLate;
            }
            else if (val > 1.5 && val <= 2.2)
            {
                tot = 3;// ArrivalTotEnum.oftenLate;
            }
            else if (val > 2.2 && val <= 2.85)
            {
                tot = 2;// ArrivalTotEnum.oftenOnTime;
            }
            else if (val > 2.85)
            {
                tot = 1;// ArrivalTotEnum.alwaysOnTime;
            }
            else
            {
                tot = 0;// ArrivalTotEnum.noData;
            }


            return tot;
        }

        private void CalculateDiscipline()
        {
            if (allDiscipCollection == null)
                return;

           
            IEnumerable<DisciplineClass> currentDiscipColl = allDiscipCollection.Where(d => d.StudentId == CurrentStudent.Model.StudentId &&
                d.EntryDate >= DateStart && d.EntryDate <= DateEnd);

            string[] commentsArray = (allDiscipCollection != null) ? new string[allDiscipCollection.Count] : null;


            Models.DisciplineClass[] selectedParamArray = currentDiscipColl.ToArray();

           // SelectedPropertyInfo = typeof(DisciplineClass).GetProperty("SocialBehave");
            
            int idx = 0;
            SelectedPropCollection = new ObservableCollection<KeyValuePair<DateTime, double>>();
            foreach (DisciplineClass dispC in selectedParamArray)
            {
                int val = (int)SelectedPropertyInfo.GetValue(dispC, null);
                if(val>0)
                SelectedPropCollection.Add(new KeyValuePair<DateTime, double>(dispC.EntryDate, val));                
                idx++;
            }  

            AverageCollection = new ObservableCollection<KeyValuePair<string, Enum>>();

            if (currentDiscipColl.Count() > 0)
            {
                AverageCollection.Add(new KeyValuePair<string, Enum>("נוכחות", (PresenceTotEnum)CalcTot(currentDiscipColl.Average(avg => (int)avg.Presence))));         
                AverageCollection.Add(new KeyValuePair<string, Enum>("הגעה בזמן",(ArrivalTotEnum)CalcTot(currentDiscipColl.Average(avg => (int)avg.Arrival))));
                AverageCollection.Add(new KeyValuePair<string, Enum>("יחס ללימודים", (AttitudeTotEnum)CalcTot(currentDiscipColl.Average(avg => (int)avg.Attitude))));
                AverageCollection.Add(new KeyValuePair<string, Enum>("יחס לחברים", (AttitudeTotEnum)CalcTot(currentDiscipColl.Average(avg => (int)avg.SocialBehave))));
                              
            }
        }

        #endregion

        #endregion
        
        #region Commands

        /// <summary>
        /// Gets the command for adding a new employee
        /// </summary>
        public ICommand AddStudentCommand { get; private set; }

        /// <summary>
        /// Gets the command for deleting the current employee
        /// </summary>
        public ICommand DeleteStudentCommand { get; private set; }

        public ICommand EditStudentCommand { get; private set; }
            
        private void BrowsePic()
        {
            CurrentStudent.StudPic = PixFuncs.BrowsePic();
        }

        private void EditPic()
        {
            CurrentStudent.StudPic = PixFuncs.EditPic(CurrentStudent, out epVm);
        }
                      
        /// <summary>
        /// Handles addition a new employee to the workspace and model
        /// </summary>
        private void AddStudent()
        {
            EzerLaMoreh.Services.ServiceProvider.Instance.Register<IModalDialog, AddDialogView<NewStudentModalDialog>>();
              
            IModalDialog dialog = Services.ServiceProvider.Instance.Get<IModalDialog>();

            NewStudentViewModel newStudentVM = new NewStudentViewModel(this);

            newStudentVM.CloseCommand = new DelegateCommand((o) => dialog.CloseDialog());

            dialog.BindViewModel(newStudentVM);

            dialog.ShowDialog();
            Mediator.NotifyColleagues("notifyStudentsWorkSpace", CurrentClass);
            
        }     

        /// <summary>
        /// Handles deletion of the current employee
        /// </summary>
        private void DeleteCurrentStudent()
        {
            if (MessageBoxResult.OK ==
          MessageBox.Show("האם אתה בטוח שברצונך למחוק את " + this.CurrentStudent.Model.FirstName + " " +
          this.CurrentStudent.Model.LastName, "רק מוודא", MessageBoxButton.OKCancel, MessageBoxImage.Question))
            {
                string picPath;
                picPath = (string)this.CurrentStudent.Model.pix;

                App.unit.RemoveStudent(this.CurrentStudent.Model);

                this.AllStudents.Remove(this.CurrentStudent);

                this.CurrentStudent = null;
                App.unit.Save();

                PixFuncs.DeletePic(picPath);                           
            }
        }

        private void EditStudent()
        {
            CurrentStudent.IsEdit = !CurrentStudent.IsEdit;           
        }
       
        #endregion
    }

}
