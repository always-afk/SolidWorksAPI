using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sw_1218_1_Lr5_КармальковАВ_2303_21
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void button2D_Click(object sender, EventArgs e)
        {
            Form2D f = new Form2D(this);
            f.Show();
        }

        private void button3D_Clicked(object sender, EventArgs e)
        {
            Form3D f = new Form3D(this);
            f.Show();
        }
    }
}
