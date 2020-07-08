using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaultRecovery
{
    class KeyRectangle
    {

        private double minX;
        private double minY;
        private double maxX;
        private double maxY;

        public KeyRectangle()
        {
            this.minX = 0;
            this.minY = 0;
            this.maxX = 0;
            this.maxY = 0;
        }

        public KeyRectangle(double minX, double minY, double maxX, double maxY)
        {
            this.minX = minX;
            this.minY = minY;
            this.maxX = maxX;
            this.maxY = maxY;
        }

        public KeyRectangle(PointXYZ point1,PointXYZ point2)
        {
            setArea(point1, point2);
        }

        public double getMinX()
        {
            return this.minX;
        }

        public void setMinX(double minX)
        {
            this.minX = minX;
        }

        public double getMinY()
        {
            return this.minY;
        }

        public void setMinY(double minY)
        {
            this.minY = minY;
        }

        public double getMaxX()
        {
            return this.maxX;
        }

        public void setMaxX(double maxX)
        {
            this.maxX = maxX;
        }

        public double getMaxY()
        {
            return this.maxY;
        }

        public void setMaxY(double maxY)
        {
            this.maxY = maxY;
        }


        //通过矩形对角线上的一对点确定裁剪区域范围
        public void setArea(PointXYZ point1,PointXYZ point2)
        {
            double x1 = point1.getX();
            double y1 = point1.getY();

            double x2 = point2.getX();
            double y2 = point2.getY();


            if (x1 < x2)
            {
                minX = x1;
                maxX = x2;
            }
            else
            {
                minX = x2;
                maxX = x1;
            }

            if (y1 < y2)
            {
                minY = y1;
                maxY = y2;
            }
            else
            {
                minY = y2;
                maxY = y1;
            }

        }

        public bool isInKeyRectangle(PointXYZ point)
        {
            bool result = false;

            double x = point.getX();
            double y = point.getY();

            if((x>=minX)&&(x<=maxX)&&(y>=minY)&&(y<maxY))
            {
                result = true;
            }

            return result;

        }



    }
}
