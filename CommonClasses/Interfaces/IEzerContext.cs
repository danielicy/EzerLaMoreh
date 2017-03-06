using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace CommonClasses.Interfaces
{
    public interface IEzerContext : IDisposable 
    {
        string CurrentPath { set; get; }

        bool isCanceled { set; get; }

        ICollection<Class1> ClassCollection { set; get; }

      //  ICollection<Student> StudentCollection { set; get; }
       
        int Year { set; get; }

        /// <summary>
        /// Creates a new instance of the specified object type
        /// NOTE: This pattern is used to allow the use of change tracking proxies
        ///       when running against the Entity Framework.
        /// </summary>
        /// <typeparam name="T">The type to create</typeparam>
        /// <returns>The newly created object</returns>
        T CreateObject<T>() where T : class;

        void Save();

        void SaveAs(string path);

    }
}
