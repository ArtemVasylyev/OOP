using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleshipWinForms
{
    // Стан клітинки на полі
    public enum CellState { Empty, Ship, Miss, Hit }

    // Клас для зберігання інформації про корабель
    public class Ship
    {
        public List<Point> Decks = new List<Point>();

        // Корабель потоплений, якщо всі його палуби мають стан Hit
        public bool IsSunk(CellState[,] grid) => Decks.All(p => grid[p.X, p.Y] == CellState.Hit);
    }

    // Клас ігрового поля
    public class Board
    {
        public CellState[,] Grid = new CellState[10, 10];
        public List<Ship> Ships = new List<Ship>();

        // Метод для ручної постановки одного корабля
        public bool PlaceShip(int x, int y, int size, bool hor)
        {
            if (!CanPlace(x, y, size, hor)) return false;

            Ship ship = new Ship();
            for (int i = 0; i < size; i++)
            {
                int cx = hor ? x + i : x;
                int cy = hor ? y : y + i;
                Grid[cx, cy] = CellState.Ship;
                ship.Decks.Add(new Point(cx, cy));
            }
            Ships.Add(ship);
            return true;
        }

        // Автоматична розстановка для комп'ютера або швидкої гри
        public void AutoPlaceShips()
        {
            Grid = new CellState[10, 10];
            Ships.Clear();
            Random rnd = new Random();
            int[] sizes = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

            foreach (int size in sizes)
            {
                bool placed = false;
                while (!placed)
                {
                    int x = rnd.Next(10), y = rnd.Next(10);
                    bool hor = rnd.Next(2) == 0;
                    placed = PlaceShip(x, y, size, hor);
                }
            }
        }

        // Перевірка, чи можна поставити корабель (щоб не виходив за межі і не торкався інших)
        private bool CanPlace(int x, int y, int size, bool hor)
        {
            if (hor && x + size > 10) return false;
            if (!hor && y + size > 10) return false;

            for (int i = 0; i < size; i++)
            {
                int cx = hor ? x + i : x;
                int cy = hor ? y : y + i;

                // Перевірка самої клітини та сусідніх (навіть по діагоналі)
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        int nx = cx + dx, ny = cy + dy;
                        if (nx >= 0 && nx < 10 && ny >= 0 && ny < 10 && Grid[nx, ny] == CellState.Ship)
                            return false;
                    }
                }
            }
            return true;
        }

        // Постріл та перевірка на знищення корабля
        public bool Shoot(int x, int y, out bool isSunk, out Ship sunkShip)
        {
            isSunk = false;
            sunkShip = null;

            if (Grid[x, y] == CellState.Ship)
            {
                Grid[x, y] = CellState.Hit;

                // Шукаємо, який корабель підбили
                sunkShip = Ships.FirstOrDefault(s => s.Decks.Contains(new Point(x, y)));

                if (sunkShip != null && sunkShip.IsSunk(Grid))
                {
                    isSunk = true;
                    // Зафарбовуємо клітинки навколо вбитого корабля
                    MarkAroundSunkShip(sunkShip);
                }
                return true; // Влучив
            }

            Grid[x, y] = CellState.Miss;
            return false; // Промах
        }

        // Обведення вбитого корабля статусом "Мимо"
        private void MarkAroundSunkShip(Ship ship)
        {
            foreach (var deck in ship.Decks)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        int nx = deck.X + dx, ny = deck.Y + dy;
                        if (nx >= 0 && nx < 10 && ny >= 0 && ny < 10)
                        {
                            if (Grid[nx, ny] == CellState.Empty)
                                Grid[nx, ny] = CellState.Miss;
                        }
                    }
                }
            }
        }
    }
}