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

        public static double ArcYByX(double lambda, double mu, double x)
        {
            if (x < 0)
                x = -x;
            if (x > 1 - 1e-6)
                return 0;
            if (lambda < 0)
                return ArcXByY(lambda / (lambda - 1), mu, x / (1 - lambda)) * (1 - lambda);
            if (lambda < 1e-6)
                return Math.Sqrt(1 - x * x);
            if (lambda > 1 - 1e-6)
                return 0;
            if (mu < 1e-6)
                return x < lambda ? (1-lambda) : Math.Sqrt(2 * x * lambda + 1 - 2 * lambda - x * x);

            double H = (1 - lambda);
            double r = (1 - mu) * (1 - lambda);
            double R = (2 * mu + lambda * lambda - 2 * mu * lambda) / (2 * mu * (1 - lambda));
            double p = R * (1 - r) / (R - r);
            return x < p ? Math.Sqrt(R * R - x * x) + H - R : Math.Sqrt(r * r - (x - (1 - r)) * (x - (1 - r)));
        }

        public static double ArcXByY(double lambda, double mu, double y)
        {
            if (y < 0)
                y = -y;
            if (y > 1 - lambda + 1e-6)
                return 0;
            if (lambda < 0)
                return ArcYByX(lambda / (lambda - 1), mu, y / (1 - lambda)) * (1 - lambda);
            if (lambda < 1e-6)
                return Math.Sqrt(1 - y * y);
            if (lambda > 1 - 1e-6)
                return 0;
            if (mu < 1e-6)
                return lambda + Math.Sqrt((1 - lambda) * (1 - lambda) - y * y);

            double H = (1 - lambda);
            double r = (1 - mu) * (1 - lambda);
            double R = (2 * mu + lambda * lambda - 2 * mu * lambda) / (2 * mu * (1 - lambda));
            double py = r * (R - H) / (R - r);
            return y > py ? Math.Sqrt(R * R - (y - H + R) * (y - H + R)) : (1 - r) + Math.Sqrt(r * r - y * y);

        }

        public static void CalcArc(double lambda, double mu, out double psi, out double C, out double c)
        {
            if (lambda < 0)
            {
                double tpsi, tc, tC;
                CalcArc(lambda/(lambda-1), mu, out tpsi, out tC, out tc);
                psi = Math.PI / 2 - tpsi;
                C = tc * (1 - lambda);
                c = tC * (1 - lambda);
                return;
            }

            if (lambda < 1e-6)
            {
                psi = Math.PI / 2;
                C = Math.PI / 2;
                c = 0;
                return;
            }

            if (lambda > 1 - 1e-6)
            {
                psi = 0;
                C = 1;
                c = 0;
                return;
            }

            if (mu < 1e-6)
            {
                C = lambda;
                psi = 0;
                c = Math.PI * (1 - lambda) / 2;
                return;
            }

            psi = Math.Atan
                (2 * (lambda + mu - mu * lambda) * mu * (1 - lambda) /
                 (lambda * (2 * mu + lambda - 2 * mu * lambda)));
            C = psi * (2 * mu + lambda * lambda - 2 * mu * lambda) / (2 * mu * (1 - lambda));
            c = (1 - mu) * (1 - lambda) * (Math.PI / 2 - psi);
            return;
        }
    }
}
