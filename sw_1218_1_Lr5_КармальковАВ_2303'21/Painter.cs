﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace sw_1218_1_Lr5_КармальковАВ_2303_21
{
    class Painter
    {
        public ModelDoc2 swModel { get; set; }
        public Point StartPoint { get; set; }
        //public Sizes Sizes { get; set; }

        public Painter (ModelDoc2 model, Point point)
        {
            swModel = model;
            StartPoint = point;
        }

        public void DrawAll()
        {
            double x1 = StartPoint.X;
            double x2 = x1;
            double y1 = StartPoint.Y;
            double y2 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 - Sizes.L2 / 2.0, 3);

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            x1 = x2;
            x2 = GetPointX(Sizes.R1, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1 / 2 - Sizes.L2 / 2)[1];
            y1 = y2;
            y2 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 - Sizes.L2 / 2.0, 3);

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            x1 = GetPointX(Sizes.R1, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1 - ((Sizes.L1 - Sizes.L2) / 2))[1];
            y1 = Math.Round(StartPoint.Y + Sizes.L1 / 2 + Sizes.L2 / 2, 3);
            x2 = StartPoint.X;
            y2 = Math.Round(StartPoint.Y + Sizes.L1 / 2 + Sizes.L2 / 2, 3);

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            x2 = x1;
            y2 = y1;
            x1 = GetPointX(Sizes.R1, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1 / 2 - Sizes.L2 / 2)[1];
            y1 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 - Sizes.L2 / 2.0, 3);


            swModel.SketchManager.CreateArc(StartPoint.X + Sizes.L4, Math.Round(StartPoint.Y + Sizes.L1 / 2, 3), StartPoint.Z, x1, y1, StartPoint.Z, x2, y2, StartPoint.Z, 1);

            x1 = StartPoint.X;
            y1 = Math.Round(StartPoint.Y + Sizes.L1 / 2 + Sizes.L2 / 2, 3);
            x2 = StartPoint.X;
            y2 = StartPoint.Y + Sizes.L1;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            x1 = x2;
            y1 = y2;
            x2 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1)[0];
            y2 = StartPoint.Y + Sizes.L1;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            x1 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1 / 2.0 + Sizes.L2 / 2.0)[1];
            y1 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 + Sizes.L2 / 2.0, 3);
            x2 = Math.Round(StartPoint.X + Sizes.L3, 3);
            y2 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 + Sizes.L2 / 2.0, 3);

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            x2 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1)[0];
            y2 = Math.Round(StartPoint.Y + Sizes.L1, 3);

            swModel.SketchManager.CreateArc(StartPoint.X + Sizes.L4, Math.Round(StartPoint.Y + Sizes.L1 / 2, 3), StartPoint.Z, x1, y1, StartPoint.Z, x2, y2, StartPoint.Z, 1);

            x1 = Math.Round(StartPoint.X + Sizes.L3, 3);
            y1 = Math.Round(StartPoint.Y + Sizes.L8, 3);
            x2 = x1;
            y2 = StartPoint.Y;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            x1 = x2;
            y1 = y2;
            x2 = Math.Round(x2 - Sizes.L5 + Sizes.R3, 3);
            y2 = y1;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            x1 = x2;
            y1 = y2;
            x2 = x1;
            y2 = StartPoint.Y + Sizes.L7;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            x1 = StartPoint.X;
            y1 = StartPoint.Y;
            x2 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, y1)[0];
            y2 = y1;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            x1 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, y1)[1];
            y1 = y2;
            x2 = StartPoint.X + Sizes.L3 - Sizes.L6;
            y2 = y1;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            x2 = x1;
            y1 = y2;
            x1 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, y1)[0];
            y2 = y1;

            swModel.SketchManager.CreateArc(StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Z, x1, y1, StartPoint.Z, x2, y2, StartPoint.Z, 1);
            
            /*
            x1 = StartPoint.X + Sizes.L3 - Sizes.L6;
            y1 = StartPoint.Y;
            x2 = Math.Round(GetTangentXY(Sizes.R3, 60.45, StartPoint.X + Sizes.L3 - Sizes.L5, StartPoint.Y + Sizes.L7, x1, y1)[0] + x1, 6);
            y2 = Math.Round(GetTangentXY(Sizes.R3, 60.45, StartPoint.X + Sizes.L3 - Sizes.L5, StartPoint.Y + Sizes.L7, x1, y1)[1] + y1, 5);
            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
            */

            x1 = x2;
            y1 = y2;
            x2 = StartPoint.X + Sizes.L3 - Sizes.L5 + Sizes.R3;
            y2 = StartPoint.Y + Sizes.L7;

            swModel.SketchManager.CreateArc(StartPoint.X + Sizes.L3 - Sizes.L5, StartPoint.Y + Sizes.L7, StartPoint.Z, x1, y1, StartPoint.Z, x2, y2, StartPoint.Z, -1);

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
            double[] resX = { x - l, x + l };
            return resX;
        }
    }
}
