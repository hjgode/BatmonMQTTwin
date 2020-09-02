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
            
            utils.doLog("doPublish: created new client");

            mqttClient.ProtocolVersion = MqttProtocolVersion.Version_3_1;
            
            try
            {
                utils.doLog("doPublish: connect()...");
                mqttClient.Connect(Environment.MachineName);
                String json = MyBattery.getBattery();
                utils.doLog("doPublish: publish "+ "android/batteries/" + topic + ", "+ json);
                mqttClient.Publish("android/batteries/" + topic, Encoding.UTF8.GetBytes(json));
                utils.doLog("doPublish: Disconnect()...");
                mqttClient.Disconnect();
                utils.doLog("doPublish: Disconnect()...DONE");
            }
            catch(Exception ex)
            {
                utils.doLog("Exception in doPublish: " + ex.Message);
            }
        }
    }
}
