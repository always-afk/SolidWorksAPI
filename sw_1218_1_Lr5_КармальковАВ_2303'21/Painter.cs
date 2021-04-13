using System;
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
        double x1, x2 , y1, y2;

        public ModelDoc2 swModel { get; set; }
        public Point StartPoint { get; set; }
        public Sizes2D Sizes { get; set; }

        private Sizes3D Sizes3D { get; set; }

        public Painter (ModelDoc2 model, Point point, Sizes2D sizes)
        {
            swModel = model;
            StartPoint = point;
            Sizes = sizes;
        }
        public Painter(ModelDoc2 model, Point point, Sizes3D sizes)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            swModel = model;
            StartPoint = point;
            Sizes3D = sizes;
        }

        public void DrawAll2D()
        {
            //1
            x1 = StartPoint.X;
            x2 = x1;
            y1 = StartPoint.Y;
            y2 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 - Sizes.L2 / 2.0, 3);

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            //2
            x1 = x2;
            x2 = GetPointX(Sizes.R1, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1 / 2 - Sizes.L2 / 2)[1];
            y1 = y2;
            y2 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 - Sizes.L2 / 2.0, 3);

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            //3
            x1 = GetPointX(Sizes.R1, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1 - ((Sizes.L1 - Sizes.L2) / 2))[1];
            y1 = Math.Round(StartPoint.Y + Sizes.L1 / 2 + Sizes.L2 / 2, 3);
            x2 = StartPoint.X;
            y2 = Math.Round(StartPoint.Y + Sizes.L1 / 2 + Sizes.L2 / 2, 3);

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            //4
            x2 = x1;
            y2 = y1;
            x1 = GetPointX(Sizes.R1, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1 / 2 - Sizes.L2 / 2)[1];
            y1 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 - Sizes.L2 / 2.0, 3);

            swModel.SketchManager.CreateArc(StartPoint.X + Sizes.L4, Math.Round(StartPoint.Y + Sizes.L1 / 2, 3), StartPoint.Z, x1, y1, StartPoint.Z, x2, y2, StartPoint.Z, 1);

            //5
            x1 = StartPoint.X;
            y1 = Math.Round(StartPoint.Y + Sizes.L1 / 2 + Sizes.L2 / 2, 3);
            x2 = StartPoint.X;
            y2 = StartPoint.Y + Sizes.L1;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            //6
            x1 = x2;
            y1 = y2;
            x2 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1)[0];
            y2 = StartPoint.Y + Sizes.L1;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            //7
            x1 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1 / 2.0 + Sizes.L2 / 2.0)[1];
            y1 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 + Sizes.L2 / 2.0, 3);
            x2 = Math.Round(StartPoint.X + Sizes.L3, 3);
            y2 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 + Sizes.L2 / 2.0, 3);

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            //8
            x2 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1)[0];
            y2 = Math.Round(StartPoint.Y + Sizes.L1, 3);

            swModel.SketchManager.CreateArc(StartPoint.X + Sizes.L4, Math.Round(StartPoint.Y + Sizes.L1 / 2, 3), StartPoint.Z, x1, y1, StartPoint.Z, x2, y2, StartPoint.Z, 1);

            //9
            x1 = Math.Round(StartPoint.X + Sizes.L3, 3);
            y1 = Math.Round(StartPoint.Y + Sizes.L8, 3);
            x2 = x1;
            y2 = StartPoint.Y;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            //10
            x1 = x2;
            y1 = y2;
            x2 = Math.Round(x2 - Sizes.L5 + Sizes.R3, 3);
            y2 = y1;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            //11
            x1 = x2;
            y1 = y2;
            x2 = x1;
            y2 = StartPoint.Y + Sizes.L7;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            //12
            x1 = StartPoint.X;
            y1 = StartPoint.Y;
            x2 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, y1)[0];
            y2 = y1;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            //13
            x1 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, y1)[1];
            y1 = y2;
            x2 = StartPoint.X + Sizes.L3 - Sizes.L6;
            y2 = y1;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);

            //14
            x2 = x1;
            y1 = y2;
            x1 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, y1)[0];
            y2 = y1;

            swModel.SketchManager.CreateArc(StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Z, x1, y1, StartPoint.Z, x2, y2, StartPoint.Z, 1);

            //15
            x1 = GetTangentXY(Sizes.R3, 60.45, StartPoint.X + Sizes.L3 - Sizes.L5, StartPoint.Y + Sizes.L7, StartPoint.X + Sizes.L3 - Sizes.L6, StartPoint.Y)[0] + StartPoint.X + Sizes.L3 - Sizes.L6;
            y1 = GetTangentXY(Sizes.R3, 60.45, StartPoint.X + Sizes.L3 - Sizes.L5, StartPoint.Y + Sizes.L7, StartPoint.X + Sizes.L3 - Sizes.L6, StartPoint.Y)[1] + StartPoint.Y;
            x2 = StartPoint.X + Sizes.L3 - Sizes.L5 + Sizes.R3;
            y2 = StartPoint.Y + Sizes.L7;

            swModel.SketchManager.CreateArc(StartPoint.X + Sizes.L3 - Sizes.L5, StartPoint.Y + Sizes.L7, StartPoint.Z, x2, y2, StartPoint.Z, x1, y1, StartPoint.Z, 1);

            //16
            x1 = StartPoint.X + Sizes.L3 - Sizes.L6;
            y1 = StartPoint.Y;
            x2 = GetTangentXY(Sizes.R3, 60.45, StartPoint.X + Sizes.L3 - Sizes.L5, StartPoint.Y + Sizes.L7, x1, y1)[0] + x1;
            y2 = GetTangentXY(Sizes.R3, 60.45, StartPoint.X + Sizes.L3 - Sizes.L5, StartPoint.Y + Sizes.L7, x1, y1)[1] + y1;

            swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
        }

        public void DrawByStep2D(int count)
        {
            switch (count)
            {
                case 0:
                    x1 = StartPoint.X;
                    x2 = x1;
                    y1 = StartPoint.Y;
                    y2 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 - Sizes.L2 / 2.0, 3);

                    swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
                    break;
                case 1:
                    x1 = x2;
                    x2 = GetPointX(Sizes.R1, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1 / 2 - Sizes.L2 / 2)[1];
                    y1 = y2;
                    y2 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 - Sizes.L2 / 2.0, 3);

                    swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
                    break;
                case 2:
                    x1 = GetPointX(Sizes.R1, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1 - ((Sizes.L1 - Sizes.L2) / 2))[1];
                    y1 = Math.Round(StartPoint.Y + Sizes.L1 / 2 + Sizes.L2 / 2, 3);
                    x2 = StartPoint.X;
                    y2 = Math.Round(StartPoint.Y + Sizes.L1 / 2 + Sizes.L2 / 2, 3);

                    swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
                    break;
                case 3:
                    x2 = x1;
                    y2 = y1;
                    x1 = GetPointX(Sizes.R1, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1 / 2 - Sizes.L2 / 2)[1];
                    y1 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 - Sizes.L2 / 2.0, 3);

                    swModel.SketchManager.CreateArc(StartPoint.X + Sizes.L4, Math.Round(StartPoint.Y + Sizes.L1 / 2, 3), StartPoint.Z, x1, y1, StartPoint.Z, x2, y2, StartPoint.Z, 1);
                    break;
                case 4:
                    x1 = StartPoint.X;
                    y1 = Math.Round(StartPoint.Y + Sizes.L1 / 2 + Sizes.L2 / 2, 3);
                    x2 = StartPoint.X;
                    y2 = StartPoint.Y + Sizes.L1;

                    swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
                    break;
                case 5:
                    x1 = x2;
                    y1 = y2;
                    x2 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1)[0];
                    y2 = StartPoint.Y + Sizes.L1;

                    swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
                    break;
                case 6:
                    x1 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1 / 2.0 + Sizes.L2 / 2.0)[1];
                    y1 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 + Sizes.L2 / 2.0, 3);
                    x2 = Math.Round(StartPoint.X + Sizes.L3, 3);
                    y2 = Math.Round(StartPoint.Y + Sizes.L1 / 2.0 + Sizes.L2 / 2.0, 3);

                    swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
                    break;
                case 7:
                    x2 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Y + Sizes.L1)[0];
                    y2 = Math.Round(StartPoint.Y + Sizes.L1, 3);

                    swModel.SketchManager.CreateArc(StartPoint.X + Sizes.L4, Math.Round(StartPoint.Y + Sizes.L1 / 2, 3), StartPoint.Z, x1, y1, StartPoint.Z, x2, y2, StartPoint.Z, 1);
                    break;
                case 8:
                    x1 = Math.Round(StartPoint.X + Sizes.L3, 3);
                    y1 = Math.Round(StartPoint.Y + Sizes.L8, 3);
                    x2 = x1;
                    y2 = StartPoint.Y;

                    swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
                    break;
                case 9:
                    x1 = x2;
                    y1 = y2;
                    x2 = Math.Round(x2 - Sizes.L5 + Sizes.R3, 3);
                    y2 = y1;

                    swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
                    break;
                case 10:
                    x1 = x2;
                    y1 = y2;
                    x2 = x1;
                    y2 = StartPoint.Y + Sizes.L7;

                    swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
                    break;
                case 11:
                    x1 = StartPoint.X;
                    y1 = StartPoint.Y;
                    x2 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, y1)[0];
                    y2 = y1;

                    swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
                    break;
                case 12:
                    x1 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, y1)[1];
                    y1 = y2;
                    x2 = StartPoint.X + Sizes.L3 - Sizes.L6;
                    y2 = y1;

                    swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
                    break;
                case 13:
                    x2 = x1;
                    y1 = y2;
                    x1 = GetPointX(Sizes.R2, StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, y1)[0];
                    y2 = y1;

                    swModel.SketchManager.CreateArc(StartPoint.X + Sizes.L4, StartPoint.Y + Sizes.L1 / 2, StartPoint.Z, x1, y1, StartPoint.Z, x2, y2, StartPoint.Z, 1);
                    break;
                case 14:
                    x1 = GetTangentXY(Sizes.R3, 60.45, StartPoint.X + Sizes.L3 - Sizes.L5, StartPoint.Y + Sizes.L7, StartPoint.X + Sizes.L3 - Sizes.L6, StartPoint.Y)[0] + StartPoint.X + Sizes.L3 - Sizes.L6;
                    y1 = GetTangentXY(Sizes.R3, 60.45, StartPoint.X + Sizes.L3 - Sizes.L5, StartPoint.Y + Sizes.L7, StartPoint.X + Sizes.L3 - Sizes.L6, StartPoint.Y)[1] + StartPoint.Y;
                    x2 = StartPoint.X + Sizes.L3 - Sizes.L5 + Sizes.R3;
                    y2 = StartPoint.Y + Sizes.L7;

                    swModel.SketchManager.CreateArc(StartPoint.X + Sizes.L3 - Sizes.L5, StartPoint.Y + Sizes.L7, StartPoint.Z, x2, y2, StartPoint.Z, x1, y1, StartPoint.Z, 1);
                    break;
                case 15:
                    x1 = StartPoint.X + Sizes.L3 - Sizes.L6;
                    y1 = StartPoint.Y;
                    x2 = GetTangentXY(Sizes.R3, 60.45, StartPoint.X + Sizes.L3 - Sizes.L5, StartPoint.Y + Sizes.L7, x1, y1)[0] + x1;
                    y2 = GetTangentXY(Sizes.R3, 60.45, StartPoint.X + Sizes.L3 - Sizes.L5, StartPoint.Y + Sizes.L7, x1, y1)[1] + y1;

                    swModel.SketchManager.CreateLine(x1, y1, StartPoint.Z, x2, y2, StartPoint.Z);
                    break;
            }
        }

        public void DrawAll3D()
        {
            //1
            swModel.Extension.SelectByID2("Front", "PLANE", StartPoint.X, StartPoint.Y, StartPoint.Z, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.SketchManager.CreateCenterRectangle(StartPoint.X, StartPoint.Y, StartPoint.Z, StartPoint.X + Sizes3D.L1 / 2, StartPoint.Y + Sizes3D.L2 / 2, StartPoint.Z);
            swModel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, Sizes3D.L3, 0.01, false, false, false, false, 0, 0,
                false, false, false, false, true, true, true, 0, 0, false);

            //2
            swModel.Extension.SelectByID2("Front", "PLANE", StartPoint.X, StartPoint.Y, StartPoint.Z, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.SketchManager.CreateCenterRectangle(StartPoint.X + (Sizes3D.L1 - Sizes3D.L3) / 2, StartPoint.Y, StartPoint.Z, StartPoint.X + Sizes3D.L1 / 2, StartPoint.Y + Sizes3D.L4 / 2, StartPoint.Z);
            swModel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, Sizes3D.L6, 0.01, false, false, false, false, 0, 0,
                false, false, false, false, true, true, true, 0, 0, false);

            //3
            swModel.Extension.SelectByID2("Right", "PLANE", StartPoint.X + Sizes3D.L1 / 2, StartPoint.Y, StartPoint.Z, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.SketchManager.CreateLine(StartPoint.X + Sizes3D.R1, StartPoint.Y, StartPoint.Z + Sizes3D.L6, StartPoint.X - Sizes3D.R1, StartPoint.Y, StartPoint.Z + Sizes3D.L6);
            swModel.SketchManager.CreateArc(StartPoint.X, StartPoint.Y, StartPoint.Z + Sizes3D.L6, StartPoint.X + Sizes3D.R1, StartPoint.Y, StartPoint.Z + Sizes3D.L6, StartPoint.X - Sizes3D.R1, StartPoint.Y, StartPoint.Z + Sizes3D.L6, 0);

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
