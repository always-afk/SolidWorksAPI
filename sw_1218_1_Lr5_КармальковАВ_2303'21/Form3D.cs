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
    public partial class Form3D : Form
    {
        SldWorks swApp;
        ModelDoc2 swModel;
        Point point;
        Painter painter;
        Form f;
        int count;
        public Form3D()
        {
            InitializeComponent();
        }

        public Form3D(Form f)
        {
            this.f = f;
            count = 0;
            InitializeComponent();
        }

        private void buttonDrawAll_Clicked(object sender, EventArgs e)
        {
            painter.DrawAll3D();
        }

        private void Form3D_Load(object sender, EventArgs e)
        {
            if(!Checker.GetSolidWorks3D(swApp, out swModel))
            {
                this.Close();
            }
            
            f.Visible = false;
            point = new Point();

            painter = new Painter(swModel, point, new Sizes3D());
        }

        private void Form3D_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.Visible = true;
        }

        private void buttonDrawByStep(object sender, EventArgs e)
        {
            button1.Enabled = false;
            painter.DrawByStep3D(count);
            count += 1;
            if(count > 4)
            {
                count = 0;
                button1.Enabled = true;
            }
        }
    }
}
