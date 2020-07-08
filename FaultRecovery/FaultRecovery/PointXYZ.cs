using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaultRecovery
{
    class PointXYZ
    {
        private string name;
        private double x;
        private double y;
        private double z;


        public PointXYZ()
        {
            name = "";
            x = 0;
            y = 0;
            z = 0;
        }

        public PointXYZ(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public PointXYZ(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public PointXYZ(string name, double x, double y, double z)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.z = z;
        }


        public string getName()
        {
            return this.name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public double getX()
        {
            return this.x;
        }

        public void setX(double x)
        {
            this.x = x;
        }

        public double getY()
        {
            return this.y;
        }

        public void setY(double y)
        {
            this.y = y;
        }


        public double getZ()
        {
            return this.z;
        }

        public void setZ(double z)
        {
            this.z = z;
        }

        public void setValue()
        {
            name = "";
            x = 0;
            y = 0;
            z = 0;
        }

        public void setValue(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void setValue(string name, double x, double y, double z)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public string getString()
        {
            string result = "";

            result = Convert.ToString(x) + "," + Convert.ToString(y) + "," + Convert.ToString(z);

            return result;
        }

    }
}
