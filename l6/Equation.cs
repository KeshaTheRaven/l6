using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l6
{
    public abstract class Equation
    {
        public abstract double GetValue(double x);
    }

    public class Integrator
    {
        private readonly Equation equation;
        public Integrator(Equation equation)
        {

            if (equation == null)
            {
                throw new ArgumentNullException();
            }
            this.equation = equation;
        }

        public double Integrate(double x1, double x2)
        {

            if (x1 >= x2)
            {
                throw new ArgumentException("Правая граница интегирования должны быть больше левой!");
            }

            int N = 100;

            double h = (x2 - x1) / N;
            double sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum = sum + equation.GetValue(x1 + i * h) * h;
            }
            return sum;
        }
    }
    public class equation : Equation
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;

        public equation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double GetValue(double x)
        {
            return a * x * x + b * x + c;
        }
    }

    public class Cos : Equation
    {
        private readonly double a;
        private readonly double b;

        public Cos(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public override double GetValue(double x)
        {
            return x * x * Math.Cos(x - a) / b;
        }
    }

    public class QuadIntegrator : Integrator
    {
        
        public delegate double GetY(double x);
        GetY y;

        public QuadIntegrator(Equation equation) : base(equation)
        {
            y = equation.GetValue;
        }
        public double Integrate(double x1, double x2)
        {

            int N = 100; 
            double h = (x2 - x1) / N; 
            double integr = 0;
            for (int i = 0; i < N; i++) 
            { 
                integr += y (x1 + i * h) * h; 
            }
            return integr;
        }
    }


}