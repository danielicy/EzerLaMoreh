using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RabbisWordClass
    {
        /// <summary>
        /// Gets or sets the Id of this Word
        /// </summary>
        public virtual int WordId { get; set; }

        /// <summary>
        /// Gets or sets the Date of the Word
        /// </summary>
        public virtual DateTime WordDate { get; set; }

        /// <summary>
        /// Gets or sets the content of the Word
        /// </summary>
        public virtual string Word { get; set; }
    }
}
