using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaultRecovery
{
    class Parameter
    {
         

            //断层线坐标
            public static double fline_ps_x;
            public static double fline_ps_y;
            public static double fline_ps_z;
            public static double fline_pe_x;
            public static double fline_pe_y;
            public static double fline_pe_z;

            //地貌标识线1坐标
            public static double kline1_ps_x;
            public static double kline1_ps_y;
            public static double kline1_ps_z;
            public static double kline1_pe_x;
            public static double kline1_pe_y;
            public static double kline1_pe_z;

            //地貌标识线2坐标
            public static double kline2_ps_x;
            public static double kline2_ps_y;
            public static double kline2_ps_z;
            public static double kline2_pe_x;
            public static double kline2_pe_y;
            public static double kline2_pe_z;

            //矩形区域角点坐标(不需要高程坐标)
            public static double area_left_top_x;
            public static double area_left_top_y;

            public static double area_left_bottom_x;
            public static double area_left_bottom_y;

            public static double area_right_top_x;
            public static double area_right_top_y;

            public static double area_right_bottom_x;
            public static double area_right_bottom_y;


            //断层线点
            public static PointXYZ FAULT_LINE_POINT_START;
            public static PointXYZ FAULT_LINE_POINT_END;

            //地貌标识线1点
            public static PointXYZ KEY_LINE1_POINT_START;
            public static PointXYZ KEY_LINE1_POINT_END;

            //地貌标识线2点
            public static PointXYZ KEY_LINE2_POINT_START;
            public static PointXYZ KEY_LINE2_POINT_END;

            //矩形区域角点
            public static PointXYZ AREA_LEFT_TOP;
            public static PointXYZ AREA_LEFT_BOTTOM;
            public static PointXYZ AREA_RIGHT_TOP;
            public static PointXYZ AREA_RIGHT_BOTTOM;

            //由关键点构造关键线
            public static KeyLine FAULT_LINE;
            public static KeyLine KEY_LINE1;
            public static KeyLine KEY_LINE2;

            public static void setParameter()
            {              
                input();
                setValue();
                initKeyLine();
            }

            
            //用户输入核心参数
            public static void input()
            {
                inputFaultLinePoint();
                inputKeyLine1Point();
                inputKeyLine2Point();
                inputAreaDiagnalPoint();

            }

            public static void setValue()
            {
                FAULT_LINE_POINT_START = new PointXYZ(fline_ps_x, fline_ps_y, fline_ps_z);
                FAULT_LINE_POINT_END   = new PointXYZ(fline_pe_x, fline_pe_y, fline_pe_z);
                KEY_LINE1_POINT_START  = new PointXYZ(kline1_ps_x, kline1_ps_y, kline1_ps_z);
                KEY_LINE1_POINT_END    = new PointXYZ(kline1_pe_x, kline1_pe_y, kline1_pe_z);
                KEY_LINE2_POINT_START  = new PointXYZ(kline2_ps_x, kline2_ps_y, kline2_ps_z);
                KEY_LINE2_POINT_END    = new PointXYZ(kline2_pe_x, kline2_pe_y, kline2_pe_z);
            }

            
            public static void initKeyLine()
            {
                FAULT_LINE = new KeyLine(FAULT_LINE_POINT_START, FAULT_LINE_POINT_END);
                KEY_LINE1  = new KeyLine(KEY_LINE1_POINT_START,  KEY_LINE1_POINT_END);
                KEY_LINE2  = new KeyLine(KEY_LINE2_POINT_START,  KEY_LINE2_POINT_END);
            }


            public static void inputFaultLinePoint()
            {
                //输入断层线起点坐标
                fline_ps_x = 489735.624;
                fline_ps_y = 4058345.990;
                fline_ps_z = 3236.852;

                //输入断层线终点坐标
                fline_pe_x = 489742.397;
                fline_pe_y = 4058329.533;
                fline_pe_z = 3236.7;
            }


            public static void inputKeyLine1Point()
            {
                //输入地貌标识线1的起点坐标
                kline1_ps_x = 489637.278;
                kline1_ps_y = 4058409.619;
                kline1_ps_z = 3240.245;

                //输入地貌标识线1的终点坐标
                kline1_pe_x = 489667.219;
                kline1_pe_y = 4058461.761;
                kline1_pe_z = 3236.75;
            }

            public static void inputKeyLine2Point()
            {
                //输入地貌标识线2的起点坐标
                kline2_ps_x = 489695.198;
                kline2_ps_y = 4058443.451;
                kline2_ps_z = 3235.82;

                //输入地貌标识线2的终点坐标
                kline2_pe_x = 489710.358;
                kline2_pe_y = 4058460.613;
                kline2_pe_z = 3234.139;
            }

            public static void inputAreaDiagnalPoint()
            {
                //输入一组对角角点坐标
                double adp_x1 = 489625.638;
                double adp_y1 = 4058483.001;
                double adp_x2 = 489758.613;
                double adp_y2 = 4058378.559;

                getRectanglePoint(adp_x1, adp_y1, adp_x2, adp_y2);
            }

            public static void getRectanglePoint(double adp_x1, double adp_y1, double adp_x2, double adp_y2)
            {
                double minX = 0;
                double maxX = 0;
                double minY = 0;
                double maxY = 0;

                if (adp_x1 < adp_x2)
                {
                    minX = adp_x1;
                    maxX = adp_x2;
                }
                else
                {
                    minX = adp_x2;
                    maxX = adp_x1;
                }

                if (adp_y1 < adp_y2)
                {
                    minY = adp_y1;
                    maxY = adp_y2;
                }
                else
                {
                    minY = adp_y2;
                    maxY = adp_y1;
                }

                AREA_LEFT_TOP     = new PointXYZ(minX,maxY);
                AREA_LEFT_BOTTOM  = new PointXYZ(minX, minY);
                AREA_RIGHT_TOP    = new PointXYZ(maxX, maxY);
                AREA_RIGHT_BOTTOM = new PointXYZ(maxX, minY);
            }          

    }
}
