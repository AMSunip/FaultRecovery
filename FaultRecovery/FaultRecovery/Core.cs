using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaultRecovery
{
    class Core
    {

        public static PointXYZ getPoint(String line)
        {
            string str = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", ",");

            string[] sd = str.Split(',');

            PointXYZ point = new PointXYZ();

            point.setX(Convert.ToDouble(sd[0]));
            point.setY(Convert.ToDouble(sd[1]));
            point.setZ(Convert.ToDouble(sd[2]));
            return point;
        }


        public static void getMaxMin(List<PointXYZ> listdata)
        {
            Const.ALTITUDE_MAX = listdata[0].getZ();
            Const.ALTITUDE_MIN = listdata[0].getZ();

            for (int i = 0; i < listdata.Count; i++)
            {
                if (listdata[i].getZ() > Const.ALTITUDE_MAX)
                {
                    Const.ALTITUDE_MAX = listdata[i].getZ();
                }

                if (listdata[i].getZ() < Const.ALTITUDE_MIN)
                {
                    Const.ALTITUDE_MIN = listdata[i].getZ();
                }

            }

            Const.ALTITUDE_DELTA = Const.ALTITUDE_MAX - Const.ALTITUDE_MIN;
        }


        public static void transformLine(List<PointXYZ> listdata,double k,double b)
        {
            Const.listdata_h_kxb.Clear();

            PointXYZ point = null;

            for (int i = 0; i < listdata.Count; i++)
            {
                point = new PointXYZ();
                point.setX(listdata[i].getX());
                point.setY(listdata[i].getY());
                double z = Const.ALTITUDE_MIN + k * (listdata[i].getZ() - Const.ALTITUDE_MIN) + b;
                point.setZ(z);
                Const.listdata_h_kxb.Add(point);
            }
        }


        public static PointXYZ getIntersectPoint(KeyLine line1,KeyLine line2)
        {
            PointXYZ point = new PointXYZ();

            double k1 = line1.getK();
            double b1 = line1.getB();

            double k2 = line2.getK();
            double b2 = line2.getB();

            double x0 = (b2    - b1)    / (k1 - k2);
            double y0 = (k1*b2 - k2*b1) / (k1 - k2);

            point.setX(x0);
            point.setY(y0);

            return point;
        }



    }
}
