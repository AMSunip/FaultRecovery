using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaultRecovery
{
    public partial class Form1 : Form
    {

        // public string fileName;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (!isValidInput1())
            {
                MessageBox.Show("Please check the input!", "Notification");
                return;
            }
            // 初始化
            init();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox21.Text = openFileDialog2.FileName;
            }

        }


        private void button5_Click(object sender, EventArgs e)
        {
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (!isValidInput2())
            {
                MessageBox.Show("Please check the input!", "Notification");
                return;
            }
            // 初始化
            init2();
        }


        private bool isValidInput1()
        {
            bool result = true;

            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") ||
               (textBox5.Text == "") || (textBox6.Text == "") || (textBox7.Text == "") || (textBox8.Text == "") ||
                (textBox9.Text == "") || (textBox10.Text == "") || (textBox11.Text == "") || (textBox12.Text == "") ||
                 (textBox13.Text == "") || (textBox14.Text == "") || (textBox15.Text == "") || (textBox16.Text == "") ||
                  (textBox17.Text == "") || (textBox18.Text == "") || (textBox19.Text == "") || (textBox20.Text == ""))
            {
                result = false;
            }


            return result;
        }

        private bool isValidInput2()
        {
            bool result = true;

            if ((textBox21.Text == "") || (textBox22.Text == "") || (textBox23.Text == "") || (textBox24.Text == "") ||
               (textBox25.Text == "") || (textBox26.Text == "") || (textBox27.Text == "") || (textBox28.Text == "") ||
                (textBox29.Text == ""))
            {
                result = false;
            }


            return result;
        }


        private void init()
        {
            string fileName = textBox1.Text;
            string fileSaveName = FormatManager.getSaveName(textBox20.Text);

            FileManager.read(fileName);
            Console.WriteLine("1.文件读取完成；");
            Console.WriteLine();

            Core.getMaxMin(Const.listdata);
            Console.WriteLine("2.已获取高程最值；");

            Console.WriteLine("地形点总数:" + Const.listdata.Count);
            Console.WriteLine("高程最大值:" + Const.ALTITUDE_MAX);
            Console.WriteLine("高程最小值:" + Const.ALTITUDE_MIN);
            Console.WriteLine("区域的高差:" + Const.ALTITUDE_DELTA);
            Console.WriteLine();

            initKeyPoint();

            translation();

            Console.WriteLine("3.已完成平移变换;");
            Console.WriteLine();

            //setArea();
            // cut(Const.area_point1,Const.area_point2);
            //Console.WriteLine("4.已按照指定区域裁剪;");
            Console.WriteLine();
            

            FileManager.write(Const.listdata_translation, fileSaveName);
            Console.WriteLine("5.已将点云结果写入文件。");
            Console.WriteLine();

            Console.ReadLine();

            MessageBox.Show("Succeed!" + "\n" +"Output Path: "+ fileSaveName+"\n"+ "Recovery Distance: " + Convert.ToString(Const.distance_recovery), "Notification!");

        }


        private void init2()
        {
            string fileName = textBox21.Text;
            string fileSaveName = FormatManager.getSaveName(textBox29.Text);

            FileManager.read(fileName);
            Console.WriteLine("1.文件读取完成；");
            Console.WriteLine();

            Core.getMaxMin(Const.listdata);
            Console.WriteLine("2.已获取高程最值；");

            Console.WriteLine("地形点总数:" + Const.listdata.Count);
            Console.WriteLine("高程最大值:" + Const.ALTITUDE_MAX);
            Console.WriteLine("高程最小值:" + Const.ALTITUDE_MIN);
            Console.WriteLine("区域的高差:" + Const.ALTITUDE_DELTA);
            Console.WriteLine();

            initKeyPoint2();

            translation2();

            Console.WriteLine("3.已完成平移变换;");
            Console.WriteLine();

            //setArea();
            // cut(Const.area_point1,Const.area_point2);
            //Console.WriteLine("4.已按照指定区域裁剪;");
            Console.WriteLine();


            FileManager.write(Const.listdata_translation, fileSaveName);
            Console.WriteLine("5.已将点云结果写入文件。");
            Console.WriteLine();

            Console.ReadLine();

            MessageBox.Show("Succeed!" + "\n" + "Output Path: " + fileSaveName, "Notification!");

        }


        private void initKeyPoint()
        {
            // 断裂线
            double x1 = Convert.ToDouble(textBox2.Text);
            double y1 = Convert.ToDouble(textBox3.Text);
            double z1 = Convert.ToDouble(textBox4.Text);

            double x2 = Convert.ToDouble(textBox5.Text);
            double y2 = Convert.ToDouble(textBox6.Text);
            double z2 = Convert.ToDouble(textBox7.Text);

            // 特征线 1
            double x3 = Convert.ToDouble(textBox8.Text);
            double y3 = Convert.ToDouble(textBox9.Text);
            double z3 = Convert.ToDouble(textBox10.Text);

            double x4 = Convert.ToDouble(textBox11.Text);
            double y4 = Convert.ToDouble(textBox12.Text);
            double z4 = Convert.ToDouble(textBox13.Text);

            // 特征线 2
            double x5 = Convert.ToDouble(textBox14.Text);
            double y5 = Convert.ToDouble(textBox15.Text);
            double z5 = Convert.ToDouble(textBox16.Text);

            double x6 = Convert.ToDouble(textBox17.Text);
            double y6 = Convert.ToDouble(textBox18.Text);
            double z6 = Convert.ToDouble(textBox19.Text);

            // 断裂线
            PointXYZ point1 = new PointXYZ(x1, y1, 0);
            PointXYZ point2 = new PointXYZ(x2, y2, 0);

            // 标志线 1
            PointXYZ point3 = new PointXYZ(x3, y3, 0);
            PointXYZ point4 = new PointXYZ(x4, y4, 0);

            // 标志线 2
            PointXYZ point5 = new PointXYZ(x5, y5, 0);
            PointXYZ point6 = new PointXYZ(x6 ,y6, 0);


            KeyLine fline = new KeyLine(point1, point2);
            KeyLine kline1 = new KeyLine(point3, point4);
            KeyLine kline2 = new KeyLine(point5, point6);
           
            Const.FK_LINE = new FaultKeyLine(fline, kline1, kline2);

            Console.WriteLine(Convert.ToString(Const.FK_LINE.getTranslationVector().getX() + ":" + Const.FK_LINE.getTranslationVector().getY() + ":" + Const.FK_LINE.getVectorDistance()));

        }

        private void initKeyPoint2()
        {
            // 断裂线
            double x1 = Convert.ToDouble(textBox22.Text);
            double y1 = Convert.ToDouble(textBox23.Text);
            double z1 = Convert.ToDouble(textBox24.Text);

            double x2 = Convert.ToDouble(textBox25.Text);
            double y2 = Convert.ToDouble(textBox26.Text);
            double z2 = Convert.ToDouble(textBox27.Text);

            double distance = Convert.ToDouble(textBox28.Text);

            distance = -distance;    // 距离直接反向。
                                     // 假设断裂线水平, 下盘固定不同, 移动上盘位置。
                                     // 符号: + , 表示上盘向右移动
                                     // 符号: - , 表示上盘向左移动

            // 断裂线
            PointXYZ point1 = new PointXYZ(x1, y1, 0);
            PointXYZ point2 = new PointXYZ(x2, y2, 0);

            Const.fline = new KeyLine(point1, point2);
            Const.distance_recovery = distance;
        }


        private static void translation()
        {
            Const.listdata_translation.Clear();

            PointXYZ point = null;

            double dx = Const.FK_LINE.getTranslationVector().getX();
            double dy = Const.FK_LINE.getTranslationVector().getY();

            // AM20191025  - 注意: 这里的dx和dy可能存在取反的情况
            if(isReverse())
            {
                dx = -dx;
                dy = -dy;
            }

            Const.distance_recovery = Math.Sqrt(dx * dx + dy * dy);

            double k = Const.FK_LINE.getFLine().getK();
            double b = Const.FK_LINE.getFLine().getB();
            double tx = 0;
            double ty = 0;
            double tz = 0;

            double nx = 0;
            double ny = 0;

            for (int i = 0; i < Const.listdata.Count; i++)
            {

                tx = Const.listdata[i].getX();
                ty = Const.listdata[i].getY();
                tz = Const.listdata[i].getZ();

                //沿着断层进行区域分割，断层下盘不变，上盘移动

                if (k * tx + b - ty > 0)
                {
                    //断层上盘
                    point = new PointXYZ();

                    //按照平移向量进行水平移动
                    nx = tx + dx;
                    ny = ty + dy;

                    point.setX(nx);
                    point.setY(ny);
                    point.setZ(tz);

                    Const.listdata_translation.Add(point);

                }
                else
                {
                    //断层下盘不进行变换
                    Const.listdata_translation.Add(Const.listdata[i]);
                }

            }
        }


        private static void translation2()
        {
            Const.listdata_translation.Clear();

            PointXYZ point = null;

            // double dx = Const.FK_LINE.getTranslationVector().getX();
            // double dy = Const.FK_LINE.getTranslationVector().getY();

            
            double k = Const.fline.getK();
            double b = Const.fline.getB();

            // 这里需要求dx和dy
            double ds = Const.distance_recovery;
            double dx = ds * 1 / Math.Sqrt(1 + k * k);
            double dy = ds * k / Math.Sqrt(1 + k * k);


            double tx = 0;
            double ty = 0;
            double tz = 0;

            double nx = 0;
            double ny = 0;

            for (int i = 0; i < Const.listdata.Count; i++)
            {

                tx = Const.listdata[i].getX();
                ty = Const.listdata[i].getY();
                tz = Const.listdata[i].getZ();

                //沿着断层进行区域分割，断层下部分不变，上部分移动

                if (k * tx + b - ty < 0)    // 这里修改了符号
                {
                    //断层上部分
                    point = new PointXYZ();

                    //按照平移向量进行水平移动
                    nx = tx - dx;    // 这里修改了符号: [+]变[-]
                    ny = ty - dy;    // 这里修改了符号: [+]变[-]

                    point.setX(nx);
                    point.setY(ny);
                    point.setZ(tz);

                    Const.listdata_translation.Add(point);

                }
                else
                {
                    //断层下盘不进行变换
                    Const.listdata_translation.Add(Const.listdata[i]);
                }

            }

        }


        public static void setArea()
        {
            Const.area_point1 = new PointXYZ();
            Const.area_point1.setX(489625.638);
            Const.area_point1.setY(4058483.001);
            Const.area_point1.setZ(3237.192);

            Const.area_point2 = new PointXYZ();
            Const.area_point2.setX(489758.613);
            Const.area_point2.setY(4058378.559);
            Const.area_point2.setZ(3234.151);
        }


        private static void cut()
        {
            Const.listdata_cut.Clear();

            KeyRectangle rectangle = new KeyRectangle();

            for (int i = 0; i < Const.listdata_translation.Count; i++)
            {
                if (rectangle.isInKeyRectangle(Const.listdata_translation[i]))
                {
                    Const.listdata_cut.Add(Const.listdata_translation[i]);
                }
            }

        }


        private static void cut(PointXYZ point1, PointXYZ point2)
        {
            Const.listdata_cut.Clear();

            KeyRectangle rectangle = new KeyRectangle(point1, point2);

            for (int i = 0; i < Const.listdata_translation.Count; i++)
            {
                if (rectangle.isInKeyRectangle(Const.listdata_translation[i]))
                {
                    Const.listdata_cut.Add(Const.listdata_translation[i]);
                }
            }

        }


        private static bool isReverse()
        {
            // 情况1: 左下右上
            // false

            // 情况2: 左上右下
            // true
            PointXYZ centerPoint1 = Const.FK_LINE.getKLine1().getCenterPoint();
            PointXYZ centerPoint2 = Const.FK_LINE.getKLine2().getCenterPoint();

            double x1 = centerPoint1.getX();
            double y1 = centerPoint1.getY();
            double z1 = centerPoint1.getZ();    // not used here
            double x2 = centerPoint2.getX();
            double y2 = centerPoint2.getY();
            double z2 = centerPoint2.getZ();    // not used here
            
            double k = Const.FK_LINE.getFLine().getK();
            double b = Const.FK_LINE.getFLine().getB();

            if((y1 > k * x1 + b) && (y2 < k * x2 + b))    // 左上右下判断限定
            {
                return true;
            }

            return false;
        }
      
    }
}
