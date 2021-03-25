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
        public Form1()
        {
            InitializeComponent();
        }

        void buttonDrawAll_Click(object sender, EventArgs e)
        {
            if (!GetSolidworks())
            {
                return;
            }

            swModel.SketchManager.CreateLine(0.01, 0.01, 0, 0.01, 0.02, 0);
            swModel.SketchManager.CreateLine(0.01, 0.04, 0, 0.01, 0.05, 0);
            swModel.SketchManager.CreateLine(0.01, 0.02, 0, 0.04, 0.02, 0);
            swModel.SketchManager.CreateLine(0.01, 0.04, 0, 0.04, 0.04, 0);
            swModel.SketchManager.CreateLine(0.04, 0.02, 0, GetPointX(0.015, 0.04, 0.03, 0.02)[1], 0.02, 0);
            swModel.SketchManager.CreateLine(0.04, 0.04, 0, GetPointX(0.015, 0.04, 0.03, 0.04)[1], 0.04, 0);
            swModel.SketchManager.CreateArc(0.04, 0.03, 0, GetPointX(0.015, 0.04, 0.03, 0.02)[1], 0.02, 0, GetPointX(0.015, 0.04, 0.03, 0.04)[1], 0.04, 0, 1);
            swModel.SketchManager.CreateLine(0.01, 0.05, 0, GetPointX(0.025, 0.04, 0.03, 0.05)[0], 0.05, 0);
            swModel.SketchManager.CreateArc(0.04, 0.03, 0, GetPointX(0.025, 0.04, 0.03, 0.05)[0], 0.05, 0, GetPointX(0.025, 0.04, 0.03, 0.04)[1], 0.04, 0, 1);
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
    }
}
