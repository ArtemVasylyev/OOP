using System.Text.RegularExpressions;

namespace Lab5_WinForms
{
    public class StringLogic
    {
        /// <summary>
        /// Видаляє повторні пробіли, залишаючи лише один.
        /// </summary>
        public string RemoveDuplicateSpaces(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Регулярний вираз \s+ шукає один або більше пробілів (пропуски, табуляції тощо)
            // і замінює їх на один звичайний пробіл.
            string result = Regex.Replace(input, @"\s+", " ");

            // Видаляємо пробіли на початку та в кінці, якщо вони є
            return result.Trim();
        }
    }
}