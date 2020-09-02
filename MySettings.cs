using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatmonMQTTwin
{
    class MySettings
    {
        String mqtt_host;
        String mqtt_port;
        String mqtt_interval;
        String mqtt_topic;

        public static String get(MQTT_SETTINGS mQTT_SETTINGS)
        {
            String setting = "";
            switch (mQTT_SETTINGS)
            {
                case MQTT_SETTINGS.mqtt_host:
                    setting = Settings1.Default.mqtt_host;
                    break;
                case MQTT_SETTINGS.mqtt_port:
                    setting = Settings1.Default.mqtt_port;
                    break;
                case MQTT_SETTINGS.mqtt_interval:
                    setting = Settings1.Default.mqtt_interval;
                    break;
                case MQTT_SETTINGS.mqtt_topic:
                    setting = Settings1.Default.mqtt_topic;
                    break;
            }
            return setting;

        }
        public enum MQTT_SETTINGS
        {
            mqtt_host,
            mqtt_port,
            mqtt_interval,
            mqtt_topic,
        }
    }
}
