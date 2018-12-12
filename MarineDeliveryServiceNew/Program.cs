using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MarineDeliveryServiceNew
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if (!DEBUG)
            UnityDIBuilder diBuilder = new UnityDIBuilder(new UnityContainer());
            var diContainer = diBuilder.Register();
            ServiceRoutines sr = diContainer.Resolve<ServiceRoutines>();

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MarineDeliveryServiceNew(sr)
            };
            ServiceBase.Run(ServicesToRun);
#else
            UnityDIBuilder diBuilder = new UnityDIBuilder(new UnityContainer());
            var diContainer = diBuilder.Register();
            ServiceRoutines sr = diContainer.Resolve<ServiceRoutines>();

            sr.UpdateOrderNoteAttachment();
#endif
            
        }
    }
}
