using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sw_1218_1_Lr5_КармальковАВ_2303_21
{
    public class Sizes
    {
        public double L1 { get; }
        public double L2 { get; }
        public double L3 { get; }
        public double L4 { get; }
        public double L5 { get; }
        public double L6 { get; }
        public double L7 { get; }
        public double L8 { get; }

        public double R1 { get; }
        public double R2 { get; }
        public double R3 { get; }

        public Sizes()
        {
             L1 = 0.04;
             L2 = 0.02;
             L3 = 0.1;
             L4 = 0.03;
             L5 = 0.015;
             L6 = 0.035;
             L7 = 0.015;
             L8 = 0.03;

             R1 = 0.015;
             R2 = 0.025;
             R3 = 0.01;
        }
    

        public Sizes(double l1, double l2, double l3, double l4, double l5, double l6, double l7, double l8, double r1, double r2, double r3)
        {
            L1 = l1;
            L2 = l2;
            L3 = l3;
            L4 = l4;
            L5 = l5;
            L6 = l6;
            L7 = l7;
            L8 = l8;

            R1 = r1;
            R2 = r2;
            R3 = r3;
        }
        
    }
}
