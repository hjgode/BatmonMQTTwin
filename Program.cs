using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BatmonMQTTwin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                BatmonMQTT_Service test = new BatmonMQTT_Service();
                test.runTest();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] {new BatmonMQTT_Service()};
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
