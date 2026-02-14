using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Завдання 4: Визначення дати за номером дня (не високосний рік).");

        int dayOfYear = GetIntInput("Введіть номер дня (1-365): ", 1, 365);

        // Кількість днів у місяцях не високосного року
        int[] daysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        string[] monthNames = { 
            "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень",
            "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень" 
        };

        int tempDays = dayOfYear;
        int monthIndex = 0;

        // Віднімаємо дні місяців, поки залишок більше, ніж днів у поточному місяці
        for (int i = 0; i < daysInMonths.Length; i++)
        {
            if (tempDays <= daysInMonths[i])
            {
                monthIndex = i;
                break;
            }
            tempDays -= daysInMonths[i];
        }

        Console.WriteLine($"День номер {dayOfYear} — це {tempDays} {monthNames[monthIndex]}.");
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
            Console.WriteLine($"Помилка. Введіть число від {min} до {max}.");
        }
    }
}
