using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Завдання 6: Реверс масиву без додаткових масивів.");

        int N = GetIntInput("Введіть розмір масиву N (більше 0): ", 1, 1000);
        int[] arr = new int[N];

        // Заповнення масиву
        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < N; i++)
        {
            arr[i] = GetIntVal($"Елемент [{i}]: ");
        }

        Console.WriteLine("\nПочатковий масив: " + string.Join(", ", arr));

        // Алгоритм реверсу на місці
        // Йдемо до середини масиву і міняємо місцями i-й та (N-1-i)-й елементи
        for (int i = 0; i < N / 2; i++)
        {
            int temp = arr[i];
            arr[i] = arr[N - 1 - i];
            arr[N - 1 - i] = temp;
        }

        Console.WriteLine("Переставлений масив: " + string.Join(", ", arr));
        Console.ReadLine();
    }

    // Метод для введення розміру (тільки позитивні)
    static int GetIntInput(string message, int min, int max)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                return value;
            Console.WriteLine($"Введіть число від {min} до {max}.");
        }
    }

    // Метод для введення будь-якого цілого числа
    static int GetIntVal(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value))
                return value;
            Console.WriteLine("Некоректне число.");
        }
    }
}
