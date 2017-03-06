using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Subject
    {
        /// <summary>
        /// Gets or sets the Id of this Student
        /// </summary>
        public virtual int SubjectId { get; set; }
        
        /// <summary>
        /// Gets or sets this Student first name
        /// </summary>
        public virtual string Name { get; set; }

    }
}
