using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaylayTree
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double x0 = 0;
        double y0 = 0;    //绘制起点

        int n=0;       //递归深度

        double length=0;    //主干长度

        double rper = 0;     //左右长度比
        double lper = 0;

        double rth = 0;       //左右角度
        double lth = 0;

        Color PenColor;       //绘制颜色

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
                graphics = this.panel1.CreateGraphics();
            graphics.Clear(Color.White);    //用白色清除

            x0 = panel1.Width / 2;
            y0 = panel1.Height;      //树由panel中间底部开始画
            try
            {
                n = int.Parse(textDepth.Text);
                length = double.Parse(textLength.Text);
                rper = double.Parse(textBoxRPer.Text);
                lper = double.Parse(textBoxLPer.Text);
            }
            catch
            {
                MessageBox.Show("输入错误！请检查输入数据后重新输入！","输入错误");
            }
            rth = (trackBarRTh.Value) * Math.PI / 180;
             lth = (trackBarLTh.Value) * Math.PI / 180;
            
            drawCaylayTree(n, x0, y0, length, -Math.PI / 2);
        }

   

        void drawCaylayTree(int n,double x0,double y0,double length,double th)
        {
            if (n == 0)
                return;
            double x1 = x0 + length * Math.Cos(th);
            double y1 = y0 + length * Math.Sin(th);
            Pen pen = new Pen(PenColor);

            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);

            drawCaylayTree(n - 1, x1, y1, rper * length, th + rth);
            drawCaylayTree(n - 1, x1, y1, lper * length, th - lth);

        }

        private void trackBarRPer_Scroll(object sender, EventArgs e)
        {
            rperValue.Text = trackBarRTh.Value.ToString();    //lable显示滚条数据
        }

        private void trackBarLPer_Scroll(object sender, EventArgs e)
        {
            lperValue.Text = trackBarLTh.Value.ToString();       //lable显示滚条数据
        }

        private void buttonPenColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDia = new ColorDialog();

            if (colorDia.ShowDialog() == DialogResult.OK)
            {
               
                PenColor = colorDia.Color;    //从颜色选择器中选择画笔颜色
                buttonPenColor.BackColor = PenColor;    //选中的颜色即为按钮背景颜色
            }
        }
    }
}
