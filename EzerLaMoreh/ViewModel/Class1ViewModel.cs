using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using EzerLaMoreh.Helpers;
using CommonClasses.Interfaces;
using System.Windows.Input;
using EzerLaMoreh.ViewModel.Helpers;

using System.Collections;

namespace EzerLaMoreh.ViewModel
{
    public class Class1ViewModel : WorkspaceViewModel  
    {
         
        /// <summary>
        /// Initializes a new instance of the classViewModel class.
        /// </summary>
        /// <param name="class">The underlying class this ViewModel is to be based on</param>
        public Class1ViewModel(Class1 class1) 
        {
            if (class1 == null)
            {
                throw new ArgumentNullException("class1");
            }
 
            this.Model = class1;

            this.MakeDefaultCommand = new DelegateCommand((o) => this.MakeDefault());           
        }

        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Gets the underlying class this ViewModel is based on
        /// </summary>
        public Class1 Model { get; private set; }                
       
        public ICommand MakeDefaultCommand { get; private set; }

        private void MakeDefault()
        {
            App.unit.DefaultClass(Model);
        }
                 
                
    }
          

}

