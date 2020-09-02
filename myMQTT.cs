using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace BatmonMQTTwin
{
    class myMQTT
    {
        MqttClient mqttClient = null;

        public void doPublish(String host, int iPort, String topic)
        {
            mqttClient = new MqttClient(host, iPort, false, uPLibrary.Networking.M2Mqtt.MqttSslProtocols.None, null, null);
            BatmonMQTT_Service.doLog("doPublish: created new client");

            mqttClient.ProtocolVersion = MqttProtocolVersion.Version_3_1;
            
            try
            {
                BatmonMQTT_Service.doLog("doPublish: connect()...");
                mqttClient.Connect(Environment.MachineName);
                String json = MyBattery.getBattery();
                BatmonMQTT_Service.doLog("doPublish: publish "+ "/android/batteries/" + topic + ", "+ json);
                mqttClient.Publish("/android/batteries/" + topic, Encoding.UTF8.GetBytes(json));
                BatmonMQTT_Service.doLog("doPublish: Disconnect()...");
                mqttClient.Disconnect();
                BatmonMQTT_Service.doLog("doPublish: Disconnect()...DONE");
            }
            catch(Exception ex)
            {
                BatmonMQTT_Service.doLog("Exception in doPublish: " + ex.Message);
            }
        }
    }
}
