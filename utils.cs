using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatmonMQTTwin
{
    class utils
    {
        public static void doLog(String msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
            /*
            // Create the source, if it does not already exist.
            String source = "BatmonMQTT";
            if (!EventLog.SourceExists(source))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource(source, Environment.MachineName);
                System.Diagnostics.Debug.WriteLine("CreatedEventSource");
                System.Diagnostics.Debug.WriteLine("Exiting, execute the application a second time to use the source.");
                // The source is created.  Exit the application to allow it to be registered.
                return;
            }
            EventLog eventLog = new EventLog();
            eventLog.Source = source;
            eventLog.WriteEntry(msg);
            */
        }
    }
}
