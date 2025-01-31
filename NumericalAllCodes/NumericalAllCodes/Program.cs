﻿using System;

namespace NumericalAllCodes
{
    class Program
    {
        static double accurecy = 0.001;
        static int loop = 10000;

        static double func(double x)
        {
            return x * x * x - x * x + 2;
        }

        static double derivFunc(double x)
        {
            return 3 * x * x - 2 * x;
        }
        static void IntervalChecker(double a, double b)
        {
            if (func(a) * func(b) >= 0)
            {
                Console.WriteLine("Worng interval");
            }
        }


       
        //bisection
        static void bisection(double a,double b)
        {
            IntervalChecker( a, b);
            double c = a;
            while ((b - a) >= accurecy)
            {
                c = (a + b) / 2;

                if (func(c) == 0.0)
                    break;

                else if (func(c) * func(a) < 0)
                    b = c;
                else
                    a = c;
            }
            Console.WriteLine("Root Using Bisection Method is : " + c);
        }

        //regulaFalsi
        static void regulaFalsi(double a, double b)
        {
            IntervalChecker(a, b);
            double c = a;

            for (int i = 0; i < loop; i++)
            {
                c = (a * func(b) - b * func(a))
                    / (func(b) - func(a));
                if (func(c) == 0)
                    break;
                else if (func(c) * func(a) < 0)
                    b = c;
                else
                    a = c;
            }
            Console.WriteLine("Root Using regulaFalsi Method is : " + c);
        }
        // newtonRaphson
        static void newtonRaphson(double x)
        {
            double h = func(x) / derivFunc(x);
            while (Math.Abs(h) >= accurecy)
            {
                h = func(x) / derivFunc(x);
                x = x - h;
            }
            Console.WriteLine("Root Using NewtonRaphson Method is : " + x);
        }

        //main program
        public static void Main()
        {
            double a=-2, b=3;
            bisection(a, b);
            regulaFalsi(a, b);

            double xstart = -1.5;
            newtonRaphson(xstart);
           
            //a = Convert.ToDouble(Console.ReadLine());
        }
    }
}
