using System;

namespace UP4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите погрешность е");
            double e = CheckDouble();
            double left = 1;
            double right = 1.1;
            double centre = (left + right) * 0.5;
            double res = ChangeDiapason(left, centre, right, e);
            Console.WriteLine("Приближенное значение выражения = " + res);
        }

        public static double ChangeDiapason(double left, double centre, double right, double e)
        {
            double xLeft, xRight, fLeft, fRight;
            bool l = false;
            bool r = false;
            if (Math.Abs(Math.Pow(centre, 5) - centre - 0.2) < e)
                return centre;
            else
            {
                do
                {
                    xLeft = (left + centre) * 0.5;
                    xRight = (centre + right) * 0.5;
                    fLeft = Math.Pow(xLeft, 5) - xLeft - 0.2;
                    fRight = Math.Pow(xRight, 5) - xRight - 0.2;
                    l = CheckDeviation(e, fLeft);
                    r = CheckDeviation(e, fRight);
                    if (l == false && r == false)
                    {
                        if (Math.Abs(fLeft) <= Math.Abs(fRight))
                        {
                            right = centre;
                            centre = (left + right) * 0.5;
                        }
                        else
                        {
                            left = centre;
                            centre = (left + right) * 0.5;
                        }
                    }
                } while (l == false && r == false);
                if (l == true) return xLeft;
                else return xRight;
            }
        }
        public static bool CheckDeviation(double e, double function)
        {
            if (Math.Abs(function) <= e)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static double CheckDouble()
        {
            double e;
            bool ok;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out e);
                if (!ok || e < 0) Console.WriteLine("Некорректный ввод, попробуйте снова");
            } while (!ok || e < 0);
            return e;
        }
    }
}
