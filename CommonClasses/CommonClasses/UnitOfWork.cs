using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using CommonClasses.Interfaces;
using Models;
using System.IO;
using CommonClasses.CommonClasses;



namespace CommonClasses
{
    public class UnitOfWork : IUnitOfWork 
    { 
        
        /// <summary>
        /// The underlying context tracking changes
        /// </summary>
        private IEzerContext underlyingContext;

        public IEzerContext UnderlyingContext
        {
            get { return underlyingContext; }
            set { underlyingContext = value; }
        }

        public UnitOfWork(IEzerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.underlyingContext = context;

        }
        
        public T CreateObject<T>() where T : class
        {
            return this.underlyingContext.CreateObject<T>();
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }

            

            //var cl = from c in this.underlyingContext.ClassCollection
            //            where c.IsCurrent
            //            select c;
          
            foreach (Class1 class1 in this.underlyingContext.ClassCollection)
            {
                if(class1.IsCurrent)
                  class1.StudentColllection.Add(student);
            }
        
           
        
        }

        public void AddClass(Class1 class1)
        {
            this.underlyingContext.ClassCollection.Add(class1);
        }

        public void DefaultClass(Class1 class1)
        {
            foreach (Class1 c in underlyingContext.ClassCollection)
            {
                c.IsDefault = false;
                if (c == class1)
                    c.IsDefault = true;
            }
           
        }

        public void RemoveClass(Class1 class1)
        {
               
           // _studentrepository.GetAllStudents().Where((o) => o.Class.Equals(ClassWorkSpace.CurrentClass.Model)))
            class1.StudentColllection.Clear();
            //foreach (Student s in class1.StudentColllection)
            //{
            //    if (s.ClassID.Equals(class1.ClassID))
            //    {
            //        class1.StudentColllection.Remove(s);
            //    }
            //}
            
            this.underlyingContext.ClassCollection.Remove(class1);
           
        }

        public void RemoveStudent(Student student)
        {
            //this.underlyingContext.StudentCollection.Remove(student);
            foreach (Class1 c in this.underlyingContext.ClassCollection)
            {
                if (c.IsCurrent)
                {
                    c.StudentColllection.Remove(student);
                }
            }
        }

        public void New()
        {
           // underlyingContext.ClassCollection = new List<Class1>();
        }

        public void Open()
        {
           
        }

        public void Save()
        {
            try
            {
                underlyingContext.Save();
               
            }
            catch (FileNotFoundException  ex)
            {
               // throw new FileNotFoundException();
               
            }

        }

        public void SaveAs(string path)
        {
            underlyingContext.SaveAs(path);
        }

        public void Refresh()
        {
           // this.UnderlyingContext.ClassCollection
        }
        
    }
}
