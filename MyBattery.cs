using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BatmonMQTTwin
{
    class MyBattery
    {
        public static String getBattery()
        {
            String s = "";
            BatteryChargeStatus status = SystemInformation.PowerStatus.BatteryChargeStatus;
            float level = SystemInformation.PowerStatus.BatteryLifePercent;
            DateTime dateTime = DateTime.Now;
            String timestamp = dateTime.ToString("dd.MM.yyyy hh:mm");
            String chargeStatus = status == BatteryChargeStatus.Charging ? "charging" : "discharging";
            BatteryInfo batteryInfo = new BatteryInfo(chargeStatus, level, timestamp); 
            return getJson(batteryInfo);
        }

        public class BatteryInfo
        {
            public String status = "discharging";
            public int level = 0;
            public String datetime = "";
            public BatteryInfo(String _status, float _level, String timestamp)
            {
                status = _status;
                level = (int)_level;
                datetime = timestamp;
            }

        }
        static String getJson(BatteryInfo info)
        {
            {
                /*
                "level": 100,
                "status": "charging",
                "datetime": "24.08.2020 16:44"
                */
}
            String json = Newtonsoft.Json.JsonConvert.SerializeObject(info);
            return json;
        }
    }
}
