using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using DataAccess;
using Utlity;
using QueryBase;
namespace MarineDeliveryServiceNew
{
    public class UnityDIBuilder
    {
        private readonly IUnityContainer _container;
        public UnityDIBuilder(IUnityContainer container)
        {
            _container = container;
        }

        public IUnityContainer Register()
        {
            _container.RegisterType<IDataHandler, DapperDataHandler>();
            _container.RegisterType<ILogging, Logging>();
            _container.RegisterType<IQueryFetch, QueryFetch>();
            return _container;
        }
    }
}
