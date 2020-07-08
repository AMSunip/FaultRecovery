using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaultRecovery
{
    class FormatManager
    {

        public static String getTimeFormat()
        {
            String result = "";
            DateTime currentTime = new DateTime();
            currentTime = System.DateTime.Now;

            result = currentTime.ToString("yyyyMMddHHmmss");

            return result;
        }

        public static String getSaveName(String fileName)
        {
            String result = "";

            result = fileName.Split('.')[0] + "_" + getTimeFormat() + "." + fileName.Split('.')[1];


            return result;
        }



    }
}
