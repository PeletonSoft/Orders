using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorniceGraph.Logic
{
    public static class MathEx
    {
        public static double Si(double x) => 
            Math.Abs(x) < 0.01 ? 1 - x * x / 6 * (1 + x * x / 120) : Math.Sin(x) / x;
    }
}
