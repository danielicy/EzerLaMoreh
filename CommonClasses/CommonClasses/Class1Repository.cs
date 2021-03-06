﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonClasses.Interfaces;
using Models;


namespace CommonClasses.CommonClasses
{
    public class Class1Repository :IClassRepository 
    {
        private ICollection<Class1> objectSet;

        public Class1Repository(IEzerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.objectSet = context.ClassCollection;
        }

        public IEnumerable<Class1> GetAllClasses()
        {
            // NOTE: Some points considered during implementation of data access methods:
            //    -  ToList is used to ensure any data access related exceptions are thrown
            //       during execution of this method rather than when the data is enumerated.
            //    -  Returning IEnumerable rather than IQueryable ensures the repository has full control
            //       over how data is retrieved from the store, returning IQueryable would allow consumers
            //       to add additional operators and affect the query sent to the store.
            return this.objectSet.ToList();
        }
    }
}

