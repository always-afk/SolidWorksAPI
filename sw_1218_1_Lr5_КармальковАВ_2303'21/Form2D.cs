using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.Runtime.InteropServices;

namespace sw_1218_1_Lr5_КармальковАВ_2303_21
{
    public partial class Form2D : Form
    {
        SldWorks swApp;
        ModelDoc2 swModel;
        int count;
        Point StartPoint;
        Painter painter;
        Form f;
        public Form2D()
        {
            count = 0;
            StartPoint = new Point(0.01, 0.01, 0);
            InitializeComponent();
        }

        public Form2D(Form f)
        {
            this.f = f;
            count = 0;
            StartPoint = new Point(0.01, 0.01, 0);
            InitializeComponent();
        }

        void buttonDrawAll_Click(object sender, EventArgs e)
        {
            if (Checker.CheckString(textBox1.Text) && Checker.CheckString(textBox2.Text))
            {
                painter.StartPoint.X = double.Parse(textBox1.Text);
                painter.StartPoint.Y = double.Parse(textBox2.Text);
                painter.DrawAll2D();
            }
        }

        private void buttonDrawByStep_Click(object sender, EventArgs e)
        {
            if (Checker.CheckString(textBox1.Text) && Checker.CheckString(textBox2.Text))
            {
                painter.StartPoint.X = double.Parse(textBox1.Text);
                painter.StartPoint.Y = double.Parse(textBox2.Text);
                painter.DrawByStep2D(count);

                if (count >= 15)
                {
                    button1.Enabled = true;
                    count = 0;
                }
                else
                {
                    button1.Enabled = false;
                    count += 1;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Checker.GetSolidworks2D(swApp, swModel))
            {
                this.Close();
            }

            this.f.Visible = false;
            this.painter = new Painter(swModel, StartPoint, new Sizes2D());
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (f is null) { }
            else
            {
                f.Visible = true;
            }
        }
    }
}
