using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AnouncmentClass
    {
        /// <summary>
        /// Gets or sets the Id of this Anouncment
        /// </summary>
        public virtual int AnounceId { get; set; }

        /// <summary>
        /// Gets or sets the Date of the Anouncment
        /// </summary>
        public virtual DateTime AnounceDate { get; set; }

        /// <summary>
        /// Gets or sets the Title of the Anouncment
        /// </summary>
        public virtual string Title { get; set; }
        
        /// <summary>
        /// Gets or sets the content of the Anouncment
        /// </summary>
        public virtual string Anouncment  { get; set; }
    }
}
