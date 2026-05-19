using System;
using System.Collections.Generic;

namespace Study.LabWork1.Features.Task3
{
    /// <summary>
    /// Узел дерева, который может иметь потомков
    /// </summary>
    /// <typeparam name="T">Тип значения, хранимого в узле</typeparam>
    public class TreeNode<T>
    {
     
        public T Value { get; set; }
        public List<TreeNode<T>> Children { get; set; }


        public TreeNode(T value)
        {
            Value = value;
            Children = new List<TreeNode<T>>();
        }

        public void AddChild(TreeNode<T> child)
        {
            Children.Add(child);
        }

        /// <summary>
        /// Добавить дочерний узел по значению
        /// </summary>
        public TreeNode<T> AddChild(T value)
        {
            var child = new TreeNode<T>(value);
            Children.Add(child);
            return child;
        }

        /// <summary>
        /// Рекурсивная функция для вывода значений всех потомков
        /// Выводит значение текущего узла и рекурсивно вызывает себя для всех детей
        /// </summary>
        /// <param name="level">Уровень вложенности (для форматирования отступов)</param>
        public void PrintChildrenValues(int level = 0)
        {
            
            string indent = new string(' ', level * 4);
            Console.WriteLine($"{indent}└─ {Value}");

            
            if (Children.Count > 0)
            {
                
                foreach (var child in Children)
                {
                    child.PrintChildrenValues(level + 1);
                }
            }
            
        }

        
    }
}
