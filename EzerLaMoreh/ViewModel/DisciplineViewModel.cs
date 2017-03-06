using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EzerLaMoreh.Helpers;
using Models;
using Enums;

namespace EzerLaMoreh.ViewModel
{
    public class DisciplineViewModel : WorkspaceViewModel 
    {
        public DisciplineViewModel(DisciplineClass discip, Student stud)
        {
            if (discip == null)
            {
                throw new ArgumentNullException("DisciplineClass");
            }

           

            this.Model = discip;
            this.Student = stud;

        }

        public DisciplineViewModel()
        {
            this.Model = new DisciplineClass();
            this.Student = new Student();

        }

        DisciplineClass m_Model;

        public DisciplineClass Model
        {
            get { return m_Model; }
            set
            { 
                m_Model = value;
                OnPropertyChanged("Model");
            }
        }

        Student student;

        public Student Student
        {
            get { return student; }
            set { student = value; }
        }

            

    }
}
