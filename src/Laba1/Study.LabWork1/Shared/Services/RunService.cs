using Study.LabWork1.Shared.Abstractions;
<<<<<<< HEAD
using Study.LabWork1.Features.Task1;
using Study.LabWork1.Features.Task3;
=======
>>>>>>> parent of 75664c8 (Задание 1 Лаба 1 Написал класс для комплексных чисел)

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1() => throw new NotImplementedException();

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() => throw new NotImplementedException();

<<<<<<< HEAD
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
        public void RunTask3()
        {
            

            
            var root = BuildTree();
 
           
            root.PrintChildrenValues();

            
        }

        /// <summary>
        /// Построение конфигурации дерева
        /// </summary>
        private TreeNode<string> BuildTree()
        {
            
            var root = new TreeNode<string>("Root");

           
            var child1 = root.AddChild("Node 1");
            var child2 = root.AddChild("Node 2");
            var child3 = root.AddChild("Node 3");

            
            child1.AddChild("Node 1.1");
            var child12 = child1.AddChild("Node 1.2");
            child1.AddChild("Node 1.3");

            child12.AddChild("Node 1.2.1");
            child12.AddChild("Node 1.2.2");

            child2.AddChild("Node 2.1");
            var child22 = child2.AddChild("Node 2.2");

           
            child22.AddChild("Node 2.2.1");
            child22.AddChild("Node 2.2.2");
            child22.AddChild("Node 2.2.3");

            
            child3.AddChild("Node 3.1");
            child3.AddChild("Node 3.2");

            return root;
        }
    }
=======
    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
>>>>>>> parent of 75664c8 (Задание 1 Лаба 1 Написал класс для комплексных чисел)
}
