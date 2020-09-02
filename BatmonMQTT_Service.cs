using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BatmonMQTTwin
{
    public partial class BatmonMQTT_Service : ServiceBase
    {
        Timer timer = new Timer();
        myMQTT MyMQTT = new myMQTT();

        public BatmonMQTT_Service()
        {
            InitializeComponent();

        }

        public void runTest()
        {
            this.OnStart(new string[] { });
        }
        protected override void OnStart(string[] args)
        {
            doLog("service starting");
            String interval = MySettings.get(MySettings.MQTT_SETTINGS.mqtt_interval);
            int iInterval = 0;
            int.TryParse(interval, out iInterval);
            if (iInterval == 0)
            {
                doLog("Setting mqtt_interval does not evaluate to a number: " + interval);
            }
            else
            {

                timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
                timer.Interval = 1000*60*iInterval; //number in milisecinds  
                timer.Enabled = true;
            }
            doPublish();
            doLog("service started");
        }

        protected override void OnStop()
        {
            doLog("service stopped");
            timer.Enabled = false;
        }

        void doPublish()
        {
            String host = MySettings.get(MySettings.MQTT_SETTINGS.mqtt_host);
            String port = MySettings.get(MySettings.MQTT_SETTINGS.mqtt_port);
            String interval = MySettings.get(MySettings.MQTT_SETTINGS.mqtt_interval);
            String topic = MySettings.get(MySettings.MQTT_SETTINGS.mqtt_topic);

            int iPort = 0;
            int.TryParse(port, out iPort);
            if (iPort == 0)
            {
                doLog("Setting mqtt_port does not evaluate to a number: " + port);
            }
            int iInterval = 0;
            int.TryParse(interval, out iInterval);
            if (iInterval == 0)
            {
                doLog("Setting mqtt_interval does not evaluate to a number: " + interval);
            }
            else
            {
                timer.Interval = 1000 * 60 * iInterval; //change the interval
            }

            if (iPort != 0 && iInterval != 0)
            {
                doLog("calling doPublish() from timer");
                MyMQTT.doPublish(host, iPort, topic);
            }
            else
            {

            }
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            doPublish();
        }

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
