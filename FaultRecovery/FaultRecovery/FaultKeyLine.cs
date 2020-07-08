using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaultRecovery
{
    class FaultKeyLine
    {

        private KeyLine  fline;
        private KeyLine  kline1;
        private KeyLine  kline2;

        private PointXYZ keyPoint1;
        private PointXYZ keyPoint2;
        private PointXYZ translationVector;

        public FaultKeyLine(KeyLine fline, KeyLine kline1, KeyLine kline2)
        {
            this.fline  = fline;
            this.kline1 = kline1;
            this.kline2 = kline2;

            CalculateKeyPoint();

            translationVector = CalculateTranslationVector();

        }

        public KeyLine getFLine()
        {
            return this.fline;
        }

        public void setFLine(KeyLine fline)
        {
            this.fline = fline;
        }

        public KeyLine getKLine1()
        {
            return this.kline1;
        }

        public void setKLine(KeyLine kline1)
        {
            this.kline1 = kline1;
        }

        public KeyLine getKLine2()
        {
            return this.kline2;
        }

        public void setKLine2(KeyLine kline2)
        {
            this.kline2 = kline2;
        }

        public PointXYZ getTranslationVector()
        {
            return this.translationVector;
        }

        public void setTranslationVector(PointXYZ translationVector)
        {
            this.translationVector = translationVector;
        }

        public PointXYZ getKeyPoint1()
        {
            return this.keyPoint1;
        }

        public void setKeyPoint1(PointXYZ keyPoint1)
        {
            this.keyPoint1 = keyPoint1;
        }

        public PointXYZ getKeyPoint2()
        {
            return this.keyPoint2;
        }

        public void setKeyPoint2(PointXYZ keyPoint2)
        {
            this.keyPoint2 = keyPoint2;
        }

        public void CalculateKeyPoint()
        {
            this.keyPoint1 = Core.getIntersectPoint(fline, kline1);
            this.keyPoint2 = Core.getIntersectPoint(fline, kline2);
        }

        public PointXYZ CalculateTranslationVector()
        {
            PointXYZ point = new PointXYZ();

            double dx = keyPoint2.getX() - keyPoint1.getX();
            double dy = keyPoint2.getY() - keyPoint1.getY();

            point.setX(dx);
            point.setY(dy);

            return point;
        }


        public double getVectorDistance()
        {
            double result = 0;
            double dx = keyPoint2.getX() - keyPoint1.getX();
            double dy = keyPoint2.getY() - keyPoint1.getY();

            result = Math.Sqrt(dx*dx+dy*dy);

            return result;

        }

        
    }
}
