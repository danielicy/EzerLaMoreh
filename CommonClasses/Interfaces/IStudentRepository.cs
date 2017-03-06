using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IStudentRepository
    {
        /// <summary>
        /// All Students for the class
        /// </summary>
        /// <returns>Enumerable of all class</returns>  
        IEnumerable<Student> GetAllStudents();
    }
}
