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
    public partial class Form1 : Form
    {
        SldWorks swApp;
        ModelDoc2 swModel;
        SketchManager swSketchManager;
        SelectionMgr swSelMgr;
        int count;
        Point StartPoint;
        Painter painter;
        public Form1()
        {
            count = 0;
            StartPoint = new Point(0.01, 0.01, 0);
            InitializeComponent();
        }

        void buttonDrawAll_Click(object sender, EventArgs e)
        {
            painter.DrawAll();
        }

        double[] GetTangentXY(double r, double angle, double xc, double yc, double xl, double yl)
        {
            double dist = Math.Sqrt(Math.Pow(xc - xl, 2.0) + Math.Pow(yc - yl, 2.0));
            double l = Math.Sqrt(Math.Pow(dist, 2.0) - Math.Pow(r, 2.0));
            double[] res = { l * Math.Cos(angle * Math.PI / 180), l * Math.Sin(angle * Math.PI / 180) };
            return res;
        }

        double[] GetPointX(double distance, double x, double y, double y1)
        {
            
            double l = Math.Sqrt(Math.Pow(distance, 2.0) - Math.Pow(Math.Abs(y - y1), 2.0));
            double[] resX = { x - l, x + l};
            return resX;
        }


        private Boolean GetSolidworks()
        {
            try
            {
                // Присваиваем переменной ссылку на запущенный solidworks (по названию)
                swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            }
            catch
            {
                // Отображает окно сообщения с заданным текстом
                MessageBox.Show("Не удалось найти запущенный Solidworks!");
                return false;
            }

            if (swApp.ActiveDoc == null)
            {
                // Отображает окно сообщения с заданным текстом
                MessageBox.Show("Надо открыть деталь перед использованием");
                return false;
            }


            // Присваиваем переменной ссылку на открытый активный проект в  SolidWorks
            swModel = (ModelDoc2)swApp.ActiveDoc;

            // Получает ISketchManager объект, который позволяет получить доступ к процедурам эскиза
            swSketchManager = (SketchManager)swModel.SketchManager;

            // Получает ISelectionMgr объект для данного документа, что делает выбранный объект доступным
            swSelMgr = (SelectionMgr)swModel.SelectionManager;


            // Проверка на открытие именно детали в SolidWorks
            if (swModel.GetType() != (int)swDocumentTypes_e.swDocDRAWING)
            {
                string text = "Это работает только на уровне чертежа";
                // Отображает окно сообщения с заданным текстом
                MessageBox.Show(text, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void buttonDrawByStep_Click(object sender, EventArgs e)
        {
            painter.DrawByStep(count);

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

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!GetSolidworks())
            {
                return;
            }

            this.painter = new Painter(swModel, StartPoint);
        }
    }
}
