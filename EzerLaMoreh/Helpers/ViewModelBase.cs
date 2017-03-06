using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using EzerLaMoreh.ViewModel.Helpers;
using EzerLaMoreh.CustomUser_Controls.ViewModels;
using EzerLaMorehEntity;
using System.Diagnostics;

namespace EzerLaMoreh.Helpers
{

    public abstract class WorkspaceViewModel   : Models.ViewModelBase        //Models.ModelBase  
    {
        public ICommand CloseCommand { get; set; }

        public ICommand OKCommand { get; protected set; }              

        public ICommand BrowsePicCommand { get; protected set; }

        public ICommand EditPicCommand { get; protected set; }
    }
    //public abstract class ViewModelBase : INotifyPropertyChanged          //Models.ModelBase  
    //{
    //    /// <summary>
    //    /// Raised when a property on this object has a new value
    //    /// </summary>
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    /// <summary>
    //    /// Raises this ViewModels PropertyChanged event
    //    /// </summary>
    //    /// <param name="propertyName">Name of the property that has a new value</param>
    //    protected virtual void OnPropertyChanged(string propertyName)
    //    {
    //        this.VerifyPropertyName(propertyName);

    //        this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    //    }

    //    /// <summary>
    //    /// Raises this ViewModels PropertyChanged event
    //    /// </summary>
    //    /// <param name="e">Arguments detailing the change</param>
    //    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    //    {
    //        var handler = this.PropertyChanged;
    //        if (handler != null)
    //        {
    //            handler(this, e);
    //        }
    //    }

    //    #region Debugging Aides

    //    /// <summary>
    //    /// Warns the developer if this object does not have
    //    /// a public property with the specified name. This 
    //    /// method does not exist in a Release build.
    //    /// </summary>
    //    [Conditional("DEBUG")]
    //    [DebuggerStepThrough]
    //    public void VerifyPropertyName(string propertyName)
    //    {
    //        // Verify that the property name matches a real,  
    //        // public, instance property on this object.
    //        if (TypeDescriptor.GetProperties(this)[propertyName] == null)
    //        {
    //            string msg = "Invalid property name: " + propertyName;

    //            if (this.ThrowOnInvalidPropertyName)
    //                throw new Exception(msg);
    //            else
    //                Debug.Fail(msg);
    //        }
    //    }

    //    /// <summary>
    //    /// Returns whether an exception is thrown, or if a Debug.Fail() is used
    //    /// when an invalid property name is passed to the VerifyPropertyName method.
    //    /// The default value is false, but subclasses used by unit tests might 
    //    /// override this property's getter to return true.
    //    /// </summary>
    //    protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

    //    #endregion // Debugging Aides

    //    public ICommand CloseCommand { get;  set; }

    //    public ICommand OKCommand { get; protected set; }

    //    public ICommand BrowsePicCommand { get; protected set; }

    //    public ICommand EditPicCommand { get; protected set; }
                      
    //}

   

    
}
