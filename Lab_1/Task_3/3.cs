using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Завдання 3: Перевірка суми цифр чотиризначного числа.");

        // Вводимо число від 1000 до 9999
        int number = GetIntInput("Введіть чотиризначне число: ", 1000, 9999);

        // Отримуємо цифри
        int digit1 = number / 1000;
        int digit2 = (number / 100) % 10;
        int digit3 = (number / 10) % 10;
        int digit4 = number % 10;

        bool result = (digit1 + digit2) == (digit3 + digit4);

        Console.WriteLine($"Число: {number}");
        Console.WriteLine($"Сума перших двох ({digit1}+{digit2}={digit1+digit2}) == Сума останніх двох ({digit3}+{digit4}={digit3+digit4})?");
        Console.WriteLine($"Результат: {result}"); // Друкує True або False
        
        Console.ReadLine();
    }

    static int GetIntInput(string message, int min, int max)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
            {
                return value;
            }
            Console.WriteLine($"Будь ласка, введіть коректне чотиризначне число (від {min} до {max}).");
        }
    }
}
