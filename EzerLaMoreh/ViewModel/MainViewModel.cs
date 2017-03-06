using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzerLaMoreh.Helpers;
using CommonClasses.Interfaces;
using System.Windows.Input;
using System.Collections.ObjectModel;
using EzerLaMoreh.ViewModel.Helpers;
using System.ComponentModel;
using System.IO;
using System.Threading;
using CommonClasses;
using CommonClasses.CommonClasses;
using EzerLaMoreh.Services;
using Models;


namespace EzerLaMoreh.ViewModel
{
    public class MainViewModel : WorkspaceViewModel 
    {
        IEzerContext context;

        public MainViewModel(IClassRepository classRepository,IEzerContext _context)
         {

            // Action action = new Action(() => LoadClasses());
            // Task t = new Task(() => LoadClasses());
            // t.Start();
            // LimitedConcurrencyLevelTaskScheduler lclt = new LimitedConcurrencyLevelTaskScheduler(2);

            // t.ContinueWith(LoadStudents);

             context = _context;

             LoadClasses(classRepository);
                        
             this.SaveCommand = new DelegateCommand((o) => this.Save());
             this.OpenCommand = new DelegateCommand((o) => this.Open());
             
             Mediator.Register("notifyStudentsWorkSpace", notifyStudentsWorkSpace);


        }

       
        #region Commands
        /// <summary>
        /// Gets the command to save all changes made in the current sessions UnitOfWork
        /// </summary>
        public ICommand SaveCommand { get; private set; }

        /// <summary>
        /// Gets the command to open existing file in the current sessions UnitOfWork
        /// </summary>
        public ICommand OpenCommand { get; private set; }

        /// <summary>
        /// Saves all changes made in the current sessions UnitOfWork
        /// </summary>
        private void Save()
        {
            try
            {
                // this.unitOfWork.Save();
                Thread t = new Thread(new ThreadStart(() => App.unit.Save()));
                t.Start();
                UIServices.SetBusyState();
            }
            catch (FileNotFoundException fex)
            {
                System.Windows.Forms.SaveFileDialog ofd = new System.Windows.Forms.SaveFileDialog();
                ofd.Filter = "Ezer LaMoreh DataFiles (.xdc)|*.xdc";
                ofd.ShowDialog();
                if (ofd.FileName != null)
                {
                    SaveAs(ofd.FileName);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveAs(string path)
        {
            App.unit.SaveAs(path);
        }

        private void Open()
        {
           // this.OpenFile();
          
           
           // LoadClasses();

        }


        #endregion

        #region WorkspaceViewModels
        
        private StudentWorkspaceViewModel studentWorkSpace;

        /// <summary>
        /// Gets the workspace for managing employees of the company
        /// </summary>
        public StudentWorkspaceViewModel StudentWorkSpace
        {
            get { return studentWorkSpace; }
            set
            {
                studentWorkSpace = value;
                OnPropertyChanged("StudentWorkSpace");
            }
        }
        
        private Class1WorkSpaceViewModel classWorkSpace;

        /// <summary>
        /// Gets the workspace for managing departments of the company
        /// </summary>
        public Class1WorkSpaceViewModel ClassWorkSpace
        {
            get { return classWorkSpace; }
            set
            {
                classWorkSpace = value;
                OnPropertyChanged("ClassWorkSpace");
            }
        }
        
        private DisciplineWorkSpaceViewModel disciplineWorkSpace;

        public DisciplineWorkSpaceViewModel DisciplineWorkSpace
        {
            get { return disciplineWorkSpace; }
            set
            { 
                disciplineWorkSpace = value;
                OnPropertyChanged("DisciplineWorkSpace");
            }
        }

        #endregion

        #region Methods

        void notifyStudentsWorkSpace(object args)
        {
            this.DisciplineWorkSpace.CurrentClass = this.StudentWorkSpace.CurrentClass = this.ClassWorkSpace.CurrentClass;
             
            LoadStudents();
        }

        private void LoadClasses(IClassRepository classRepository)
        {
            ObservableCollection<Class1ViewModel> allClasses = new ObservableCollection<Class1ViewModel>();

            if (((UnitOfWork)App.unit).UnderlyingContext.ClassCollection.Count == 0)
            {
                Class1 cls1 = new Class1();
                cls1.ClassID = 1;
                cls1.ClassName = "DefaultClass";               
                cls1.IsCurrent = true;
                cls1.IsDefault = true;
                cls1.StudentColllection = new Collection<Student>();  
                cls1.DisciplineCollection = new Collection<DisciplineClass>();

                Class1ViewModel clsVM = new Class1ViewModel(cls1);
             
                ((UnitOfWork)App.unit).AddClass(cls1);               
            }

            foreach (Models.Class1 cls in   classRepository.GetAllClasses())    // ((UnitOfWork)App.unit).UnderlyingContext.ClassCollection)
            {
                allClasses.Add(new Class1ViewModel(cls));
            }

           
            this.ClassWorkSpace = new Class1WorkSpaceViewModel(allClasses,context);

          LoadStudents();

        }

        private void LoadStudents( )
        {
            ObservableCollection<StudentViewModel> allStudents = new ObservableCollection<StudentViewModel>();
            ObservableCollection<DisciplineViewModel> allDisciplines = new ObservableCollection<DisciplineViewModel>();
            this.DisciplineWorkSpace = new DisciplineWorkSpaceViewModel(allDisciplines);
            
            if (this.ClassWorkSpace.CurrentClass.Model.StudentColllection != null)
            {
                //load existiting stutents
                foreach (Models.Student stud in this.ClassWorkSpace.CurrentClass.Model.StudentColllection)     //_studentrepository.GetAllStudents().Where((o) => o.Class.Equals(ClassWorkSpace.CurrentClass.Model)))
                {
                    allStudents.Add(new StudentViewModel(stud));  
                 
                    allDisciplines.Add(new DisciplineViewModel(disciplineWorkSpace.DispCls(stud.StudentId), stud));
                }
              
            }
            else
            {
                //create new collection
                this.ClassWorkSpace.CurrentClass.Model.StudentColllection = new Collection<Student>();
            }

            this.StudentWorkSpace = new StudentWorkspaceViewModel(allStudents, this.ClassWorkSpace.CurrentClass.Model.DisciplineCollection);
            
            this.DisciplineWorkSpace.CurrentClass =this.StudentWorkSpace.CurrentClass = this.ClassWorkSpace.CurrentClass;
        }
               
        

        #endregion

    }

    // Provides a task scheduler that ensures a maximum concurrency level while  
// running on top of the thread pool. 
    public class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
    {
        // Indicates whether the current thread is processing work items.
        [ThreadStatic]
        private static bool _currentThreadIsProcessingItems;

        // The list of tasks to be executed  
        private readonly LinkedList<Task> _tasks = new LinkedList<Task>(); // protected by lock(_tasks) 

        // The maximum concurrency level allowed by this scheduler.  
        private readonly int _maxDegreeOfParallelism;

        // Indicates whether the scheduler is currently processing work items.  
        private int _delegatesQueuedOrRunning = 0;

        // Creates a new instance with the specified degree of parallelism.  
        public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
        {
            if (maxDegreeOfParallelism < 1) throw new ArgumentOutOfRangeException("maxDegreeOfParallelism");
            _maxDegreeOfParallelism = maxDegreeOfParallelism;
            
        }

        // Queues a task to the scheduler.  
        protected sealed override void QueueTask(Task task)
        {
            // Add the task to the list of tasks to be processed.  If there aren't enough  
            // delegates currently queued or running to process tasks, schedule another.  
            lock (_tasks)
            {
                _tasks.AddLast(task);
                if (_delegatesQueuedOrRunning < _maxDegreeOfParallelism)
                {
                    ++_delegatesQueuedOrRunning;
                    NotifyThreadPoolOfPendingWork();
                }
            }
        }

        // Inform the ThreadPool that there's work to be executed for this scheduler.  
        private void NotifyThreadPoolOfPendingWork()
        {
            ThreadPool.UnsafeQueueUserWorkItem(_ =>
            {
                // Note that the current thread is now processing work items. 
                // This is necessary to enable inlining of tasks into this thread.
                _currentThreadIsProcessingItems = true;
                try
                {
                    // Process all available items in the queue. 
                    while (true)
                    {
                        Task item;
                        lock (_tasks)
                        {
                            // When there are no more items to be processed, 
                            // note that we're done processing, and get out. 
                            if (_tasks.Count == 0)
                            {
                                --_delegatesQueuedOrRunning;
                                break;
                            }

                            // Get the next item from the queue
                            item = _tasks.First.Value;
                            _tasks.RemoveFirst();
                        }

                        // Execute the task we pulled out of the queue 
                        base.TryExecuteTask(item);
                    }
                }
                // We're done processing items on the current thread 
                finally { _currentThreadIsProcessingItems = false; }
            }, null);
        }

        // Attempts to execute the specified task on the current thread.  
        protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // If this thread isn't already processing a task, we don't support inlining 
            if (!_currentThreadIsProcessingItems) return false;

            // If the task was previously queued, remove it from the queue 
            if (taskWasPreviouslyQueued)
                // Try to run the task.  
                if (TryDequeue(task))
                    return base.TryExecuteTask(task);
                else
                    return false;
            else
                return base.TryExecuteTask(task);
        }

        // Attempt to remove a previously scheduled task from the scheduler.  
        protected sealed override bool TryDequeue(Task task)
        {
            lock (_tasks) return _tasks.Remove(task);
        }

        // Gets the maximum concurrency level supported by this scheduler.  
        public sealed override int MaximumConcurrencyLevel { get { return _maxDegreeOfParallelism; } }

        // Gets an enumerable of the tasks currently scheduled on this scheduler.  
        protected sealed override IEnumerable<Task> GetScheduledTasks()
        {
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(_tasks, ref lockTaken);
                if (lockTaken) return _tasks;
                else throw new NotSupportedException();
            }
            finally
            {
                if (lockTaken) Monitor.Exit(_tasks);
            }
        }
    }

}



