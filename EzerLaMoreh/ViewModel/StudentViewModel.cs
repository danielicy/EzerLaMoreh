using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzerLaMoreh.ViewModel.Helpers;
using Models;
using System.Collections.ObjectModel;
using CommonClasses.Interfaces;
using EzerLaMoreh.Helpers;
using System.Drawing;

namespace EzerLaMoreh.ViewModel
{
    public class StudentViewModel : WorkspaceViewModel  
    {
        public StudentViewModel(Student student)//,  IUnitOfWork unitOfWork)//: base(student)            
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }

         
            this.Model = student;          
        }

        #region Fields

        private Student m_model;

        private DisciplineClass m_discipline;
               
        private bool m_isEdit;

        #endregion

        #region Properties

        public Student Model
        {
            get { return m_model; }
            set { 
                m_model = value;
                OnPropertyChanged("Model");
            }
        }

        public DisciplineClass Discipline
        {
            get { return m_discipline; }
            set { m_discipline = value; }
        }

        public string StudPic
        {
            get
            {
                return Model.pix;
            }
            set
            {
                Model.pix = value;
                OnPropertyChanged("StudPic");
            }
        }
          
        public bool IsEdit
        {
            get { return m_isEdit; }
            set
            {
                if (!m_isEdit && m_isEdit != value)
                    App.unit.Save();
                m_isEdit = value;
                OnPropertyChanged("IsEdit");
                
            }
        }     

        #endregion
    }
}
