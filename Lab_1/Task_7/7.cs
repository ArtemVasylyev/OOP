using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Завдання 7: Підрахунок кількості слів у рядку, що закінчується крапкою.");

        string input;
        while (true)
        {
            Console.WriteLine("Введіть рядок тексту (має закінчуватися крапкою):");
            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) && input.Trim().EndsWith("."))
            {
                break;
            }
            Console.WriteLine("Рядок не може бути порожнім і повинен закінчуватися крапкою.");
        }

        // Видаляємо крапку в кінці, щоб вона не заважала, якщо вона відокремлена пробілом
        string text = input.TrimEnd('.');

        // Розбиваємо рядок на масив слів, використовуючи пробіли як роздільник.
        // StringSplitOptions.RemoveEmptyEntries ігнорує зайві пробіли між словами.
        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine($"Введений рядок: {input}");
        Console.WriteLine($"Кількість слів: {words.Length}");
        
        Console.ReadLine();
    }
}
