using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzerLaMoreh.Services
{
    class ServiceProvider
    {
        
            public static IServiceLocator Instance { get; private set; }

            public static void RegisterServiceLocator(IServiceLocator s)
            {
                Instance = s;
            }
         
    }

    interface IServiceLocator
    {
        void Register<TInterface, TImplementation>() where TImplementation : TInterface;

        void Dispose<TInterface, TImplementation>();

        TInterface Get<TInterface>();
    }

  
}
