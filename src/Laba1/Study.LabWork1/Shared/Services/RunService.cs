using Study.LabWork1.Shared.Abstractions;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.Shared.Services
{
    /// <summary>
    /// Реализация заданий Л/Р
    /// </summary>
    public class RunService : IRunService
    {
        /// <summary>
        /// Задание 1 - Комплексные числа
        /// </summary>
        public void RunTask1()
        {
            Console.WriteLine("=== Лабораторная работа №1: Комплексные числа ===\n");

            // Демонстрация создания чисел
            var c1 = new Complex(3, 4);
            var c2 = new Complex(1, -2);
            var c3 = new Complex(5, 0);
            var c4 = new Complex(0, 6);
            var c5 = new Complex();

            Console.WriteLine("Созданные комплексные числа:");
            Console.WriteLine($"c1 = {c1}");
            Console.WriteLine($"c2 = {c2}");
            Console.WriteLine($"c3 = {c3}");
            Console.WriteLine($"c4 = {c4}");
            Console.WriteLine($"c5 (по умолчанию) = {c5}");
            Console.WriteLine();

            // Арифметические операции
            Console.WriteLine("=== Арифметические операции ===");
            Console.WriteLine($"c1 + c2 = {c1 + c2}");
            Console.WriteLine($"c1 - c2 = {c1 - c2}");
            Console.WriteLine($"c1 * c2 = {c1 * c2}");
            Console.WriteLine($"c1 / c2 = {c1 / c2}");
            Console.WriteLine();

            // Унарные операции
            Console.WriteLine("=== Унарные операции ===");
            Console.WriteLine($"Модуль числа c1: |c1| = {+c1:F4}");
            Console.WriteLine($"Модуль числа c2: |c2| = {+c2:F4}");
            Console.WriteLine($"Сопряженное к c1: conj(c1) = {-c1}");
            Console.WriteLine($"Сопряженное к c2: conj(c2) = {-c2}");
            Console.WriteLine();

            // Операции сравнения
            Console.WriteLine("=== Операции сравнения ===");
            var c1Copy = new Complex(3, 4);
            Console.WriteLine($"c1 == c1Copy: {c1 == c1Copy}");
            Console.WriteLine($"c1 == c2: {c1 == c2}");
            Console.WriteLine($"c1 != c2: {c1 != c2}");
            Console.WriteLine();

            // Дополнительные проверки формата вывода
            Console.WriteLine("=== Проверка формата ToString ===");
            Console.WriteLine($"Число с реальной частью: {c3}");
            Console.WriteLine($"Число с мнимой частью: {c4}");
            Console.WriteLine($"Нулевое число: {c5}");
            Console.WriteLine($"Отрицательная мнимая часть: {new Complex(2, -3.5)}");
            Console.WriteLine($"Дробные части: {new Complex(1.234, 5.678)}");
        }

        /// <summary>
        /// Задание 2
        /// </summary>
        public void RunTask2() => throw new NotImplementedException();

        /// <summary>
        /// Задание 3
        /// </summary>
        public void RunTask3() => throw new NotImplementedException();
    }
}
