using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Завдання 5: Перевірка, чи всі цифри числа різні.");

        long n = GetNaturalInput("Введіть натуральне число n: ");
        long originalN = n;

        // Використаємо масив bool для відстеження цифр 0-9
        bool[] seenDigits = new bool[10];
        bool allUnique = true;

        while (n > 0)
        {
            int digit = (int)(n % 10); // Беремо останню цифру
            
            if (seenDigits[digit])
            {
                allUnique = false;
                break; 
            }
            
            seenDigits[digit] = true; // Позначаємо, що бачили цю цифру
            n /= 10; // Відкидаємо останню цифру
        }

        if (allUnique)
            Console.WriteLine($"Усі цифри числа {originalN} різні.");
        else
            Console.WriteLine($"У числі {originalN} є однакові цифри.");

        Console.ReadLine();
    }

    static long GetNaturalInput(string message)
    {
        long value;
        while (true)
        {
            Console.Write(message);
            // Перевіряємо, що це число і воно > 0
            if (long.TryParse(Console.ReadLine(), out value) && value > 0)
            {
                return value;
            }
            Console.WriteLine("Помилка. Введіть натуральне число (ціле, більше 0).");
        }
    }
}
