using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses.Interfaces
{
    using System.Collections.Generic;
    using Models;
    public interface IClassRepository
    {
        /// <summary>
        /// All Classes for the currentfile
        /// </summary>
        /// <returns>Enumerable of all classes</returns>
        IEnumerable<Class1> GetAllClasses();
    }
}
