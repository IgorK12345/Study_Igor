using System;

namespace Study.LabWork1.Features.Task1
{

    public class Complex
    {

        public double Real { get; set; }
        public double Imagine { get; set; }

        /// <summary>
        /// Конструктор комплексного числа
        /// </summary>
        public Complex(double real = 0, double imagine = 0)
        {
            Real = real;
            Imagine = imagine;
        }    

        /// <summary>
        /// Сложение комплексных чисел
        /// </summary>
        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Imagine + b.Imagine);
        }

        /// <summary>
        /// Вычитание комплексных чисел
        /// </summary>
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Imagine - b.Imagine);
        }

        /// <summary>
        /// Умножение комплексных чисел
        /// </summary>
        public static Complex operator *(Complex a, Complex b)
        {
            double real = a.Real * b.Real - a.Imagine * b.Imagine;
            double imagine = a.Real * b.Imagine + a.Imagine * b.Real;
            return new Complex(real, imagine);
        }

        /// <summary>
        /// Деление комплексных чисел
        /// </summary>
        public static Complex operator /(Complex a, Complex b)
        {
            double denominator = b.Real * b.Real + b.Imagine * b.Imagine;
            if (Math.Abs(denominator) < 1e-10)
                throw new DivideByZeroException("Деление на ноль. Знаменатель равен нулю.");

            double real = (a.Real * b.Real + a.Imagine * b.Imagine) / denominator;
            double imagine = (a.Imagine * b.Real - a.Real * b.Imagine) / denominator;
            return new Complex(real, imagine);
        }


        /// <summary>
        /// Проверка на равенство двух комплексных чисел
        /// </summary>
        public static bool operator ==(Complex a, Complex b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a is null || b is null)
                return false;

            const double epsilon = 1e-10;
            return Math.Abs(a.Real - b.Real) < epsilon &&
                   Math.Abs(a.Imagine - b.Imagine) < epsilon;
        }

        /// <summary>
        /// Проверка на неравенство двух комплексных чисел
        /// </summary>
        public static bool operator !=(Complex a, Complex b)
        {
            return !(a == b);
        }


        /// <summary>
        /// Унарный плюс - вычисление модуля комплексного числа
        /// </summary>
        public static double operator +(Complex a)
        {
            if (a is null)
                throw new ArgumentNullException(nameof(a));
            return Math.Sqrt(a.Real * a.Real + a.Imagine * a.Imagine);
        }

        /// <summary>
        /// Унарный минус - получение сопряженного комплексного числа
        /// </summary>
        public static Complex operator -(Complex a)
        {
            if (a is null)
                throw new ArgumentNullException(nameof(a));
            return new Complex(a.Real, -a.Imagine);
        }     

        /// <summary>
        /// Строковое представление комплексного числа
        /// </summary>
        public override string ToString()
        {
            const double epsilon = 1e-10;

            // Нулевое число
            if (Math.Abs(Real) < epsilon && Math.Abs(Imagine) < epsilon)
                return "0";

            // Только реальная часть
            if (Math.Abs(Imagine) < epsilon)
                return Real.ToString("F2");

            // Только мнимая часть
            if (Math.Abs(Real) < epsilon)
                return $"{Imagine:F2}i";

            // Обе части
            string sign = Imagine > 0 ? "+" : "-";
            return $"{Real:F2} {sign} {Math.Abs(Imagine):F2}i";
        }
        
        
        
    }
}
