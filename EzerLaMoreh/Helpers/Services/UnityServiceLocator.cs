using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace EzerLaMoreh.Services
{
    class UnityServiceLocator : IServiceLocator
    {
        private UnityContainer container;

        public UnityServiceLocator()
        {
            container = new UnityContainer();
        }

        void IServiceLocator.Register<TInterface, TImplementation>()
        {
            container.RegisterType<TInterface, TImplementation>();
        }

        void IServiceLocator.Dispose<TInterface, TImplementation>()
        {
            container.Dispose();
        }




        TInterface IServiceLocator.Get<TInterface>()
        {
            return container.Resolve<TInterface>();
        }
    }
}