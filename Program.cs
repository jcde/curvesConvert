using System;

namespace CurvesConvert
{
    class Program
    {
        static int N;
        static double X;
        static double Y;

        static double[] MinCurveMaxX = { 62.1599999999999, 74.5919999999999, 93.2399999999998, 19.9967763210079, 25.0386985557919 };
        static double[] MinCurveCoef0 = { 17.4413436577667, 25.115534867184, 39.243023229975, 9.49922418175925, 14.8933248736184 };
        static double[] MinCurveCoef1 = { -0.025592752222355, -0.0307113026668263, -0.0383891283335347, -0.0521516028738389, -0.0653009386411772 };
        static double[] MinCurveCoef2 = { -0.000866451773100767, -0.000866451773100745, -0.000866451773100696, -0.000366826177379569, -0.00036682617737939 };
        static double[] MinCurveCoef3 = { -1.70918725556843E-05, -1.42432271297372E-05, -1.13945817037901E-05, -0.000468276347221276, -0.000373981792661364 };
        static double[] MaxCurveMaxX = { 77.3070381999998, 92.7684458399998, 115.9605573, 25.7305980154344, 32.2182274295824 };
        static double[] MaxCurveCoef0 = { 28.19386392072, 40.5991640458368, 63.4361938216201, 17.3577457170713, 27.2142799339772 };
        static double[] MaxCurveCoef1 = { -0.0163259738512987, -0.0195911686215564, -0.0244889607769458, -0.101190233899893, -0.126704010823373 };
        static double[] MaxCurveCoef2 = { -0.00139518534991911, -0.00139518534991916, -0.00139518534991915, -0.000363448537743328, -0.000363448537743127 };
        static double[] MaxCurveCoef3 = { -1.2607199881512E-05, -1.05059999012596E-05, -8.40479992100774E-06, -0.000360574439035711, -0.000287967299434668 };

        static void Main(string[] args)
        {
            Console.Write("The curves convert variant 1..5: ");
            try
            {
                N = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Enter x: ");
                X = double.Parse(Console.ReadLine());
                Console.Write("Enter y: ");
                Y = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            bool result = false;
            if (X >= 0 && X < MinCurveMaxX[N])
            {
                if (Y >= MinCurve(X) && Y <= MaxCurve(X))
                    result = true;
            }
            if (X >= MinCurveMaxX[N] && X <= MaxCurveMaxX[N])
            {
                var a = SqrCurveA(MinCurveMaxX[N], MinCurve(MinCurveMaxX[N]), MaxCurveMaxX[N], MaxCurve(MaxCurveMaxX[N]));
                var b = SqrCurveB(MinCurveMaxX[N], MinCurve(MinCurveMaxX[N]), MaxCurveMaxX[N], MaxCurve(MaxCurveMaxX[N]));
                var y = a * X * X + b * X;
                if (Y > y && Y < MaxCurve(X))
                    result = true;
            }

            Console.Write(result ? "Point is inside of the convert" : "Outside the convert");
            Console.WriteLine();
            Console.ReadKey();
        }

        static double MaxCurve(double x)
        {
            return MaxCurveCoef3[N] * x * x * x + MaxCurveCoef2[N] * x * x + MaxCurveCoef1[N] * x + MaxCurveCoef0[N];
        }

        static double MinCurve(double x)
        {
            return MinCurveCoef3[N] * x * x * x + MinCurveCoef2[N] * x * x + MinCurveCoef1[N] * x + MinCurveCoef0[N];
        }

        static double SqrCurveA(double x1, double y1, double x2, double y2)
        {
            return (y1 - (y2 * x1 / x2)) / (x1 * x1 - x2 * x1);
        }
        static double SqrCurveB(double x1, double y1, double x2, double y2)
        {
            return y2 / x2 - SqrCurveA(x1, y1, x2, y2) * x2;
        }

    }
}
