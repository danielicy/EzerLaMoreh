using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using CommonClasses.Interfaces;
using CommonClasses.CommonClasses;
using EzerLaMorehEntity;
using CommonClasses;

using EzerLaMoreh.View;
using EzerLaMoreh.ViewModel;
using Utilities;
using EzerLaMoreh.Services;
using EzerLaMoreh.Helpers;
using EzerLaMoreh.Extras;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Globalization;
using System.Windows.Markup;



namespace EzerLaMoreh
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {                      

        public static  IUnitOfWork unit;

        private IEzerContext context;
         
        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("he-IL");


            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), 
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag)));
           

            //CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name); 
            //ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            
            //Thread.CurrentThread.CurrentCulture = ci; 
           
            CheckLicense checkLicense = new CheckLicense();

            if (checkLicense.Check())
            {

            }
            else
            {
                MessageBox.Show("אין לך רשיון בתוקף", "התוכנית תיסגר", MessageBoxButton.OK, MessageBoxImage.Error,
                    MessageBoxResult.OK,MessageBoxOptions.None);
                Shutdown();
                return;
            }
          

            base.OnStartup(e);

            //initialize all the services needed for dependency injection
            //we use the unity framework for dependency injection, but you can choose others
            ServiceProvider.RegisterServiceLocator(new UnityServiceLocator());



            this.context = new EzerEntities();

            if (this.context.isCanceled)
                this.OnExit(null);
          
           // LoadContext  LC = new LoadContext();

            IClassRepository departmentRepository = new Class1Repository (this.context);

            unit = new UnitOfWork(context);


            MainViewModel main = new MainViewModel(departmentRepository,context );
            
            MainView window = new View.MainView { DataContext = main };
            window.Show();
            

        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            this.Shutdown();
           
            
        }

      
    }
}
