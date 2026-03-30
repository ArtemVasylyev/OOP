using System;

namespace Lab6_WinForms
{
    public class TriangleLogic
    {
        public double CalculateArea(double a, double b, double c)
        {
            // Перевірка на від'ємні значення або нуль
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Сторони трикутника повинні бути додатними числами."); // [cite: 1295, 1358]
            }

            // Перевірка нерівності трикутника
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new Exception("Трикутник із такими сторонами не існує (сума двох сторін має бути більша за третю)."); // [cite: 1358]
            }

            double p = (a + b + c) / 2;
            // Обчислення площі за формулою Герона
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}