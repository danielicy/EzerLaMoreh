using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace Models
{
    public class QAClass
    {
        /// <summary>
        /// Gets or sets the Id of this Student
        /// </summary>
        public virtual int StudentId { get; set; }

        /// <summary>
        /// Gets or sets this Student EntryDate
        /// </summary>
        public virtual DateTime EntryDate { get; set; }

        /// <summary>
        /// Gets or sets this Student EntryDate
        /// </summary>
        public virtual QaEvalEnum Participate { get; set; }

        /// <summary>
        /// Gets or sets this Student EntryDate
        /// </summary>
        public virtual QaEvalEnum HomeWork { get; set; }

        /// <summary>
        /// Gets or sets this Student EntryDate
        /// </summary>
        public virtual int Exam { get; set; }

        /// <summary>
        /// Gets or sets this Student EntryDate
        /// </summary>
        public virtual int ExamWeight { get; set; }





    }
}
