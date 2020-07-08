using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace FaultRecovery
{
    class Const
    {

        public static double ALTITUDE_MAX   = 0;
        public static double ALTITUDE_MIN   = 0;
        public static double ALTITUDE_DELTA = 0;

        public static List<PointXYZ> listdata             = new List<PointXYZ>();
        public static List<PointXYZ> listdata_h_kxb       = new List<PointXYZ>();
        public static List<PointXYZ> listdata_translation = new List<PointXYZ>();
        public static List<PointXYZ> listdata_cut         = new List<PointXYZ>();

        public static FaultKeyLine   FK_LINE              = null;

        public static PointXYZ       area_point1          = null;
        public static PointXYZ       area_point2          = null;


        // 按位移恢复
        public static KeyLine        fline                = null;
        public static double         distance_recovery    = 0;

    }
}
