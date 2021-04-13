using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace sw_1218_1_Lr5_КармальковАВ_2303_21
{
    public static class Checker
    {
        public static bool GetSolidworks2D(SldWorks swApp, ModelDoc2 swModel)
        {
            try
            {
                // Присваиваем переменной ссылку на запущенный solidworks (по названию)
                swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            }
            catch
            {
                // Отображает окно сообщения с заданным текстом
                return false;
            }

            if (swApp.ActiveDoc == null)
            {
                // Отображает окно сообщения с заданным текстом
                return false;
            }


            // Присваиваем переменной ссылку на открытый активный проект в  SolidWorks
            swModel = (ModelDoc2)swApp.ActiveDoc;

            // Проверка на открытие именно детали в SolidWorks
            if (swModel.GetType() != (int)swDocumentTypes_e.swDocDRAWING)
            {
                return false;
            }

            return true;
        }

        public static bool GetSolidWorks3D(SldWorks swApp, out ModelDoc2 swModel)
        {
            try
            {
                // Присваиваем переменной ссылку на запущенный solidworks (по названию)
                swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            }
            catch
            {
                // Отображает окно сообщения с заданным текстом
                swModel = null;
                return false;
            }

            if (swApp.ActiveDoc == null)
            {
                // Отображает окно сообщения с заданным текстом
                swModel = null;
                return false;
            }


            // Присваиваем переменной ссылку на открытый активный проект в  SolidWorks
            swModel = (ModelDoc2)swApp.ActiveDoc;

            // Проверка на открытие именно детали в SolidWorks
            if (swModel.GetType() != (int)swDocumentTypes_e.swDocPART)
            {
                return false;
            }

            return true;
        }

        public static bool CheckString(String s)
        {
            bool res = false;
            foreach (char e in s)
            {
                if (Char.IsDigit(e))
                {
                    res = true;
                }
                else if (e == ',')
                {
                    res = true;
                }
                else
                {
                    return false;
                }
            }
            return res;
        }
    }
}
