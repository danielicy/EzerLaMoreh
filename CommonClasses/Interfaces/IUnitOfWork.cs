using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace CommonClasses.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Creates a new instance of the specified object type
        /// NOTE: This pattern is used to allow the use of change tracking proxies
        ///       when running against the Entity Framework.
        /// </summary>
        /// <typeparam name="T">The type to create</typeparam>
        /// <returns>The newly created object</returns>
        T CreateObject<T>() where T : class;

        /// <summary>
        /// Registers the addition of a new student
        /// </summary>
        /// <param name="student">The student to add</param>
        /// <exception cref="InvalidOperationException">Thrown if student is already added to UnitOfWork</exception>
        void AddStudent(Student  student);

        /// <summary>
        /// Registers the addition of a new class
        /// </summary>
        /// <param name="class">The class to add</param>
        /// <exception cref="InvalidOperationException">Thrown if class is already added to UnitOfWork</exception>
        void AddClass(Class1  class1);

        void DefaultClass(Class1 class1);

        /// <summary>
        /// Registers the removal of an existing class1
        /// </summary>
        /// <param name="class1">The class1 to remove</param>
        /// <exception cref="InvalidOperationException">Thrown if class1 is not tracked by this UnitOfWork</exception>
        void RemoveClass(Class1 class1);

        /// <summary>
        /// Registers the removal of an existing student
        /// </summary>
        /// <param name="student">The student to remove</param>
        /// <exception cref="InvalidOperationException">Thrown if student is not tracked by this UnitOfWork</exception>
        void RemoveStudent(Student student);

        /// <summary>
        /// start new EzerEntities instance 
        /// </summary>       
        /// <exception cref="InvalidOperationException"></exception>
        void New();

        /// <summary>
        /// opens existing EzerEntities instance 
        /// </summary>       
        /// <exception cref="InvalidOperationException"></exception>
        void Open();

        /// <summary>
        /// saves current EzerEntities instance 
        /// </summary>       
        /// <exception cref="InvalidOperationException"></exception>
        void Save();

        /// <summary>
        /// SavesAs current EzerEntities instance 
        /// </summary>       
        /// <exception cref="InvalidOperationException"></exception>
        void SaveAs(string path);

        void Refresh();

    }
}
