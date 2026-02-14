using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Console.WriteLine("Завдання 1: Обчислення виразу.");
        
        double a = GetDoubleInput("Введіть значення a (a не дорівнює 0): ");
        while (a == 0)
        {
            Console.WriteLine("Помилка: 'a' не може дорівнювати 0 (ділення на нуль).");
            a = GetDoubleInput("Введіть значення a ще раз: ");
        }

        double b = GetDoubleInput("Введіть значення b (b не дорівнює 0): ");
         while (b == 0)
        {
            Console.WriteLine("Помилка: 'b' не може дорівнювати 0 (через b^-2).");
            b = GetDoubleInput("Введіть значення b ще раз: ");
        }

        double c = GetDoubleInput("Введіть значення c: ");

        // Перевірка підкореневого виразу (b^2 + 4ac)
        double discriminant = b * b + 4 * a * c;
        if (discriminant < 0)
        {
            Console.WriteLine($"Помилка: Підкореневий вираз ({discriminant}) менше нуля. Обчислення в дійсних числах неможливе.");
        }
        else
        {
            // Формула: (b + sqrt(b^2 + 4ac)) / 2a - a^3*c + b^-2
            // b^-2 = 1 / (b*b)
            double result = (b + Math.Sqrt(discriminant)) / (2 * a) - (Math.Pow(a, 3) * c) + (1 / (b * b));
            Console.WriteLine($"Результат обчислення: {result}");
        }
        
        Console.ReadKey();
    }

    static double GetDoubleInput(string message)
    {
        double value;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            Console.WriteLine("Некоректне введення. Будь ласка, введіть число.");
        }
    }
}