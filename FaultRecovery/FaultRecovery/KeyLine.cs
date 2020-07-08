using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaultRecovery
{
    class KeyLine
    {
        private double   k;
        private double   b;

        private  PointXYZ point1;
        private  PointXYZ point2;

        public KeyLine(PointXYZ point1, PointXYZ point2)
        {
            this.point1 = point1;
            this.point2 = point2;
            getKB();
        }


        public void getKB()
        {
            double x1 = point1.getX();
            double y1 = point1.getY();

            double x2 = point2.getX();
            double y2 = point2.getY();

            k = (y2 - y1) / (x2 - x1);
            b = (x1 * y2 - x2 * y1) / (x1 - x2);
        }

        public double getK()
        {
            return this.k;
        }

        public void setK(double k)
        {
            this.k = k;
        }

        public double getB()
        {
            return this.b;
        }

        public void setB(double b)
        {
            this.b = b;
        }

        public PointXYZ getCenterPoint()
        {
            PointXYZ centerPoint = new PointXYZ();
            double centerX = (point1.getX() + point2.getX()) / 2;
            double centerY = (point1.getY() + point2.getY()) / 2;
            double centerZ = (point1.getZ() + point2.getZ()) / 2;
            centerPoint.setValue("CenterPoint",centerX,centerY,centerZ);
            return centerPoint;
        }

            
    }
}
