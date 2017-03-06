using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace Models
{
    [Serializable]
    public class Class1 :ViewModelBase 
    {
        private   ICollection<DisciplineClass> m_disciplineCollection;

        

        public virtual string ClassName { get; set; }

        public virtual int ClassID { get; set; }

      
        public virtual string TeacherName { get; set; }

        public virtual string Year { get; set; }

        public virtual bool IsDefault { get; set; }

        public virtual bool IsCurrent { get; set; }

        /// <summary>
        /// Gets or sets the students that belong to this class
        /// Adding or removing will fixup the department property on the affected employee
        /// </summary>
        public virtual ICollection<Student> StudentColllection { get; set; }
        

        /// <summary>
        /// Gets or sets the Discipline data that belong to this class
        /// Adding or removing will fixup the department property on the affected employee
        /// </summary>
        public ICollection<DisciplineClass> DisciplineCollection
        {
            get { return m_disciplineCollection; }
            set { m_disciplineCollection = value;
            OnPropertyChanged("DisciplineCollection");
            }
        }
      //  public virtual ICollection<DisciplineClass> DisciplineCollection { get; set; }
        

        /// <summary>
        /// Gets or sets the subjects data that belong to this class
        /// Adding or removing will fixup the department property on the affected employee
        /// </summary>
        public virtual ICollection<QAClass> QAColllection { get; set; }
        




        //public virtual StudentCollection    StudentColl 
        //{
        //    get { return this.sutds; }
        //    set { this.sutds = value; }
        //}


       

    }
}
