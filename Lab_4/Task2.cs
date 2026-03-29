namespace Lab4_WinForms
{
    public class Task2Logic
    {
        private int[,] _matrix;

        public Task2Logic(int[,] matrix)
        {
            _matrix = matrix;
        }

        // Правий верхній кут
        public int GetTopRightElement()
        {
            int cols = _matrix.GetLength(1);
            return _matrix[0, cols - 1];
        }

        // Лівий нижній кут
        public int GetBottomLeftElement()
        {
            int rows = _matrix.GetLength(0);
            return _matrix[rows - 1, 0];
        }

        // Форматування матриці у текст для виведення на екран
        public string GetMatrixAsString()
        {
            int rows = _matrix.GetLength(0);
            int cols = _matrix.GetLength(1);
            string result = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += _matrix[i, j] + "\t";
                }
                result += "\n";
            }
            return result;
        }
    }
}