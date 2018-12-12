using System.Diagnostics;
using System.ServiceProcess;
using Unity;
using System.Threading;
using System;
using System.Configuration;

namespace MarineDeliveryServiceNew
{
    public partial class MarineDeliveryServiceNew : ServiceBase
    {
        private int running;

       private readonly ServiceRoutines  serviceRoutines ;
        public MarineDeliveryServiceNew(ServiceRoutines routines)
        {
            InitializeComponent();
            this.serviceRoutines = routines;
        }

        protected override void OnStart(string[] args)
        {
            runThread();
        }

        protected override void OnStop()
        {
        }

        public void runThread()
        {
            if (Interlocked.CompareExchange(ref running, 1, 0) == 0)
            {
                Thread t = new Thread
                (
                    () =>
                    {
                        try
                        {
                            new Thread(new ThreadStart(ThreadProc)).Start();
                        }
                        catch
                        {
                            //Without the catch any exceptions will be unhandled
                            //(Maybe that's what you want, maybe not*)
                        }
                        finally
                        {
                            //Regardless of exceptions, we need this to happen:
                            running = 0;
                        }
                    }
                );
                t.IsBackground = true;
                t.Name = "myThread";
                t.Start();
            }
            else
            {
                //Logging.WriteLog("Previous Process is already running...", EventLogEntryType.Error);
            }

        }

        public void ThreadProc()
        {
            TimeSpan timeOutInt = TimeSpan.FromMinutes((double)Convert.ToInt32(ConfigurationManager.AppSettings["Interval"]));
            while (true)
            {
                serviceRoutines.ExecuteRoutines();
                Thread.Sleep(timeOutInt);
            }
        }
    }
}
