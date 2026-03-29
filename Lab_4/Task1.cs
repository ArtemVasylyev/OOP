using System;
using System.Linq;

namespace Lab4_WinForms
{
    public class Task1Logic
    {
        private double[] _array;

        // Конструктор, який приймає масив
        public Task1Logic(double[] array)
        {
            _array = array;
        }

        // а) Сума від'ємних елементів
        public double GetSumOfNegatives()
        {
            return _array.Where(x => x < 0).Sum();
        }

        // б) Добуток між максимальним і мінімальним
        public double GetProductBetweenMinMax()
        {
            if (_array.Length < 3) return 0; // Немає елементів між ними

            int minIndex = 0;
            int maxIndex = 0;

            for (int i = 1; i < _array.Length; i++)
            {
                if (_array[i] < _array[minIndex]) minIndex = i;
                if (_array[i] > _array[maxIndex]) maxIndex = i;
            }

            int start = Math.Min(minIndex, maxIndex);
            int end = Math.Max(minIndex, maxIndex);

            if (end - start <= 1) return 0; // Якщо вони стоять поруч

            double product = 1;
            for (int i = start + 1; i < end; i++)
            {
                product *= _array[i];
            }
            return product;
        }

        // Сортування масиву
        public double[] GetSortedArray()
        {
            double[] sorted = (double[])_array.Clone(); // Клонуємо, щоб не змінити оригінал
            Array.Sort(sorted);
            return sorted;
        }
    }
}