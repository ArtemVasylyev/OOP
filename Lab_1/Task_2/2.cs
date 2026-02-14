using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Завдання 2: Електронний годинник.");
        
        // Введення поточного часу з перевіркою діапазонів
        int t = GetIntInput("Введіть поточні години (0-23): ", 0, 23);
        int n = GetIntInput("Введіть поточні хвилини (0-59): ", 0, 59);
        int k = GetIntInput("Введіть поточні секунди (0-59): ", 0, 59);

        Console.WriteLine($"\nПоточний час: {t:D2}:{n:D2}:{k:D2}");

        // Введення інтервалу (без обмеження верхньої межі, бо це просто тривалість)
        int p = GetIntInput("Скільки годин додати? (>=0): ", 0, int.MaxValue);
        int q = GetIntInput("Скільки хвилин додати? (>=0): ", 0, int.MaxValue);
        int r = GetIntInput("Скільки секунд додати? (>=0): ", 0, int.MaxValue);

        // Переводимо все в секунди
        long currentTotalSeconds = t * 3600 + n * 60 + k;
        long addedSeconds = p * 3600 + q * 60 + r;
        
        long finalTotalSeconds = currentTotalSeconds + addedSeconds;

        // Вираховуємо час в межах доби (залишок від ділення на кількість секунд у добі - 86400)
        long secondsInDay = 24 * 3600;
        long normalizedSeconds = finalTotalSeconds % secondsInDay;

        long newHours = normalizedSeconds / 3600;
        long newMinutes = (normalizedSeconds % 3600) / 60;
        long newSeconds = normalizedSeconds % 60;

        Console.WriteLine($"\nНовий час на годиннику: {newHours:D2}:{newMinutes:D2}:{newSeconds:D2}");
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
            Console.WriteLine($"Помилка. Введіть ціле число від {min} до {max}.");
        }
    }
}