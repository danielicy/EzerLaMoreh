using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzerLaMoreh.Helpers;
using EzerLaMoreh.View.add;
using System.Reflection;

 
using System.Collections; 
using System.ComponentModel;
using System.Security;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
 
using EzerLaMoreh.ViewModel;

namespace EzerLaMoreh.View.add
{
    public class AddDialogView<TViewModel> : IModalDialog   where TViewModel : System.Windows.Window  
        {
           public  TViewModel concreteInstance;

            public AddDialogView(TViewModel t)
            {              
                concreteInstance = Activator.CreateInstance<TViewModel>();
                concreteInstance.Owner = App.Current.MainWindow;
                //  concreteInstance.Topmost = true;
              concreteInstance.ShowInTaskbar = false;
              concreteInstance.Closed += new EventHandler(view_Closed);
            }             
           
             
            void IModalDialog.BindViewModel <TViewModel> (TViewModel viewModel)  
            {
                concreteInstance.DataContext = viewModel;
                concreteInstance.Closed += view_Closed;             
            }

            void IModalDialog.ShowDialog()
            {                
                if (concreteInstance != null)
                    concreteInstance.ShowDialog();                
            }           

            void view_Closed(object sender, EventArgs e)
            {
               Type senderType = sender.GetType();

                foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                { 
                    Type t = window.GetType();
                    
                    if (t.Equals(senderType))
                    {
                        window.Close();
                    }
                }
                concreteInstance.Close();
                concreteInstance = null;
            }




            void IModalDialog.CloseDialog()
            {
                if (concreteInstance != null)
                    concreteInstance.Close();
            }
        }     
    }

    //99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999

    //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
    /// <summary>
    /// 
    /// </summary>

    //public class AddClassDialogView : IModalDialog
    //{
    //    NewClassModalDialog clsView;
    //    NewStudentModalDialog stdView;
    //    #region IModalDialog

    //    public AddClassDialogView()
    //    {

    //    }

    //    void IModalDialog.BindViewModel<TViewModel>(TViewModel viewModel)
    //    {

    //        if (typeof(TViewModel).Equals(typeof(AddClassViewModel)))
    //        {
    //            newClassDialog().DataContext = viewModel;
    //        }
    //        else if (typeof(TViewModel).Equals(typeof(AddStudentViewModel)))
    //        {
    //            newStudentDialog().DataContext = viewModel;
    //        }


    //    }

    //    void IModalDialog.ShowDialog()
    //    {
    //        // newClassDialog().ShowDialog();
    //        if (clsView != null)
    //            clsView.ShowDialog();
    //        if (stdView != null)
    //            stdView.ShowDialog();
    //    }

    //    void IModalDialog.Close()
    //    {
    //        throw new NotImplementedException();
    //    }


    //    #endregion

    //    public delegate void Del<T>(T item);

    //    private T NewDialog<T>(T t) where T : new()
    //    {

    //        T nt = new T();

    //        return nt;

    //    }

    //    private NewClassModalDialog newClassDialog()
    //    {
    //        if (clsView == null)
    //        {
    //            //create the view if the view does not exist
    //            clsView = new NewClassModalDialog();
    //            // view.Width = 530;
    //            clsView.Closed += new EventHandler(view_Closed);
    //        }
    //        return clsView;
    //    }

    //    private NewStudentModalDialog newStudentDialog()
    //    {

    //        if (stdView == null)
    //        {
    //            //create the view if the view does not exist
    //            stdView = new NewStudentModalDialog();
    //            // view.Width = 530;
    //            stdView.Closed += new EventHandler(view_Closed);
    //        }
    //        return stdView;
    //    }



    //    void view_Closed(object sender, EventArgs e)
    //    {
    //        clsView = null;
    //    }
    //}    
//}
//OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO