using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class SubjectContentClass
    {
        /// <summary>
        /// Gets or sets the Id of this Student
        /// </summary>
        public virtual int SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the Id of this Student
        /// </summary>
        public virtual DateTime  sDate { get; set; }

        /// <summary>
        /// Gets or sets the Id of this Student
        /// </summary>
        public virtual string Contetnt { get; set; }
    }
}
