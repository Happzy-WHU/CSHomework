using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static double th1;
        static double th2;
        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawGayleyTree(10, 200, 310, 100, -Math.PI / 2);
            th1 = double.Parse(textBox1.Text);
            th2 = double.Parse(textBox2.Text);
        }
        private Graphics graphics;
        double per1 = 0.6;
        double per2 = 0.7;
        void drawGayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            Random example = new Random();
            double number = example.Next(0, 5);
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * Math.Cos(th)+number;
            double y2 = y0 + leng * Math.Sin(th)+number;
            drawLine(x0, y0, x1, y1);
            drawLine(x0, y0, x2, y2);
            drawGayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawGayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
        }
        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
