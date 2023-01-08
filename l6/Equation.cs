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
                sum += equation.GetValue(x1 + i * h) * h;
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

    public class Trap : Integrator
    {
        public Trap(Equation equation) : base(equation)
        {

            if (equation == null)
            {
                throw new ArgumentNullException();
            }

        }

        public double Integrate(Equation equation, double x1, double x2, int N = 100)
        {
            if (equation == null)
            {
                throw new ArgumentNullException();
            }
            if (x1 >= x2)
            {
                throw new ArgumentException("Правая граница должна быть больше левой!");
            }
            double h = (x2 - x1) / N;
            double sum = 0;
            double sumf = ((equation.GetValue(x1 * h) + equation.GetValue(x2 * h))) / 2;


            for (int i = 1; i < N; i++)
            {

                var r = equation.GetValue(x1 + i * h);
                sum += (Double.IsNaN(r) ? 0 : r);
            }
            return h * (sum + sumf);

        }
    }

    public class Simpson : Integrator
    {
        public Simpson(Equation equation) : base(equation)
        {
            if (equation == null)
            {
                throw new ArgumentNullException();
            }
        }
        public double Integrate(double x1, double x2, Equation equation)
        {
            int N = 100; //Количество шагов
            double h = (x2 - x1) / N; //Ширинa шага
            double integralSum = 0;
            double x = x1 + h;
            while (x < x2)
            {
                integralSum += 4 * equation.GetValue(x);
                x += h;
                if (x >= x2)
                    break;
                integralSum += 2 * equation.GetValue(x);
                x += h;
            }
            integralSum = (h / 3) * (integralSum + equation.GetValue(x1) + equation.GetValue(x2));
            return integralSum;
        }


    }
}
    

  


