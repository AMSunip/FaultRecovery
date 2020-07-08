using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FaultRecovery
{
    class FileManager
    {

        public static void read(String fileName)
        {
            Const.listdata.Clear();

            StreamReader reader = new StreamReader(fileName,Encoding.GetEncoding("gb2312"));



            // 注意: 文件头前5行需要判断
            String extData = reader.ReadLine();
            string[] extDataList = extData.Split(',');

            extData.Split(',').Count<string>();

            if (extDataList.Count<string>()<3)
            {
                // 说明存在标记: [QTT Version : 29]
                reader.ReadLine();    // XYZ - RGB
                reader.ReadLine();    // Scale : 0.08188700
                reader.ReadLine();    // Projection: WGS 84 / UTM zone 47N
            }
            else
            {
                Const.listdata.Add(Core.getPoint(extData));
            }


            String line = "";
            while ((line = reader.ReadLine())!=null)
            {
                Const.listdata.Add(Core.getPoint(line));
            }

            reader.Close();

        }


        public static void write(List<PointXYZ> listdata,string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);

            for (int i = 0; i < listdata.Count; i++)
            {
                writer.WriteLine(listdata[i].getString());
            }

            writer.Close();

        }
    }


}
