using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleshipWinForms
{
    public partial class Form1 : Form
    {
        Board playerBoard = new Board();
        Board enemyBoard = new Board();
        Button[,] playerButtons = new Button[10, 10];
        Button[,] enemyButtons = new Button[10, 10];

        // Змінні для режиму розстановки
        bool isPlacing = true;

        // Блокування ходу гравця під час пострілів бота
        bool isPlayerTurn = true;

        bool isHorizontal = true;
        int[] shipSizes = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
        int currentShipIndex = 0;

        Label infoLabel;
        Button rotateBtn;
        Button autoPlaceBtn;

        // Для Штучного Інтелекту (аналіз ходів)
        List<Point> targets = new List<Point>();
        bool[,] aiHits = new bool[10, 10];
        Random rnd = new Random();

        public Form1()
        {
            this.Text = "Морський Бій - РГР";
            this.Size = new Size(900, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Створюємо елементи керування для розстановки
            infoLabel = new Label { Location = new Point(20, 15), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            this.Controls.Add(infoLabel);

            rotateBtn = new Button { Text = "Поворот: Горизонтально", Location = new Point(20, 45), Size = new Size(160, 30) };
            rotateBtn.Click += (s, e) => { isHorizontal = !isHorizontal; rotateBtn.Text = "Поворот: " + (isHorizontal ? "Горизонтально" : "Вертикально"); };
            this.Controls.Add(rotateBtn);

            autoPlaceBtn = new Button { Text = "Розставити випадково", Location = new Point(190, 45), Size = new Size(160, 30) };
            autoPlaceBtn.Click += (s, e) => { playerBoard.AutoPlaceShips(); currentShipIndex = shipSizes.Length; UpdatePlacementUI(); UpdateVisuals(); };
            this.Controls.Add(autoPlaceBtn);

            Label lblEnemy = new Label { Text = "Поле супротивника", Location = new Point(460, 55), AutoSize = true };
            this.Controls.Add(lblEnemy);

            // Генеруємо ігрові поля
            CreateGrid(20, 85, playerButtons, false);
            CreateGrid(460, 85, enemyButtons, true);

            enemyBoard.AutoPlaceShips();
            UpdatePlacementUI();
            UpdateVisuals();
        }

        private void CreateGrid(int xOffset, int yOffset, Button[,] btnArray, bool isEnemy)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Button b = new Button
                    {
                        Size = new Size(35, 35),
                        Location = new Point(xOffset + x * 35, yOffset + y * 35),
                        Tag = new Point(x, y), // Зберігаємо координати прямо в кнопці
                        BackColor = Color.LightBlue,
                        FlatStyle = FlatStyle.Flat
                    };

                    if (isEnemy) b.Click += EnemyCell_Click;
                    else b.Click += PlayerCell_Click;

                    btnArray[x, y] = b;
                    this.Controls.Add(b);
                }
            }
        }

        //  ЛОГІКА РОЗСТАНОВКИ 
        private void PlayerCell_Click(object sender, EventArgs e)
        {
            if (!isPlacing) return;

            Button btn = (Button)sender;
            Point p = (Point)btn.Tag;
            int size = shipSizes[currentShipIndex];

            if (playerBoard.PlaceShip(p.X, p.Y, size, isHorizontal))
            {
                currentShipIndex++;
                UpdateVisuals();
                UpdatePlacementUI();
            }
        }

        private void UpdatePlacementUI()
        {
            if (currentShipIndex < shipSizes.Length)
            {
                infoLabel.Text = $"ЕТАП РОЗСТАНОВКИ. Поставте {shipSizes[currentShipIndex]}-палубний корабель.";
                infoLabel.ForeColor = Color.DarkRed;
            }
            else
            {
                isPlacing = false;
                infoLabel.Text = "БІЙ ПОЧАВСЯ! Ваш хід — стріляйте по правому полю.";
                infoLabel.ForeColor = Color.DarkGreen;
                rotateBtn.Visible = false;
                autoPlaceBtn.Visible = false;
            }
        }

        // ВІЗУАЛІЗАЦІЯ ТА БІЙ 
        private void UpdateVisuals()
        {
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                {
                    playerButtons[x, y].BackColor = GetColor(playerBoard.Grid[x, y], false);
                    enemyButtons[x, y].BackColor = GetColor(enemyBoard.Grid[x, y], true);
                }
        }

        private Color GetColor(CellState state, bool hideShips)
        {
            switch (state)
            {
                case CellState.Ship: return hideShips ? Color.LightBlue : Color.Gray;
                case CellState.Hit: return Color.Red;
                case CellState.Miss: return Color.DarkBlue;
                default: return Color.LightBlue;
            }
        }

        // Асинхронний метод обробки кліку по ворожому полю
        private async void EnemyCell_Click(object sender, EventArgs e)
        {
            if (isPlacing)
            {
                MessageBox.Show("Спочатку розставте всі свої кораблі!");
                return;
            }

            // Блокуємо постріл гравця, поки бот не закінчить хід
            if (!isPlayerTurn) return;

            Button btn = (Button)sender;
            Point p = (Point)btn.Tag;

            if (enemyBoard.Grid[p.X, p.Y] == CellState.Hit || enemyBoard.Grid[p.X, p.Y] == CellState.Miss) return;

            bool hit = enemyBoard.Shoot(p.X, p.Y, out bool isSunk, out Ship _);
            UpdateVisuals();

            if (enemyBoard.Ships.TrueForAll(s => s.IsSunk(enemyBoard.Grid)))
            {
                MessageBox.Show("Вітаємо! Ви перемогли супротивника!");
                Application.Restart();
                return;
            }

            // Якщо ми промахнулися, хід переходить до бота
            if (!hit)
            {
                isPlayerTurn = false;
                infoLabel.Text = "ХІД СУПРОТИВНИКА...";
                infoLabel.ForeColor = Color.DarkRed;

                await EnemyTurn(); // Запускаємо хід бота

                isPlayerTurn = true; // Повертаємо хід гравцю
                infoLabel.Text = "ВАШ ХІД!";
                infoLabel.ForeColor = Color.DarkGreen;
            }
        }

        // Асинхронний хід ворога
        private async Task EnemyTurn()
        {
            bool hit = true;
            // Бот стріляє, поки влучає
            while (hit)
            {
                // Пауза 600мс, щоб було видно серію пострілів бота
                await Task.Delay(600);

                Point p;
                // Аналіз ходів ШІ: якщо є цілі для добивання, б'ємо по них
                if (targets.Count > 0)
                {
                    p = targets[0];
                    targets.RemoveAt(0);
                }
                else
                {
                    // Інакше стріляємо випадково
                    do { p = new Point(rnd.Next(10), rnd.Next(10)); } while (aiHits[p.X, p.Y]);
                }

                aiHits[p.X, p.Y] = true;
                hit = playerBoard.Shoot(p.X, p.Y, out bool isSunk, out Ship sunkShip);

                if (hit)
                {
                    if (isSunk)
                    {
                        // Якщо корабель вбито, очищаємо список цілей
                        targets.Clear();
                        // Позначаємо клітинки навколо, щоб бот туди більше не стріляв
                        MarkAiHitsAroundSunk(sunkShip);
                    }
                    else
                    {
                        // Якщо просто попали, додаємо сусідні клітинки в масив для добивання
                        AddTarget(p.X + 1, p.Y); AddTarget(p.X - 1, p.Y);
                        AddTarget(p.X, p.Y + 1); AddTarget(p.X, p.Y - 1);
                    }
                }

                UpdateVisuals();

                if (playerBoard.Ships.TrueForAll(s => s.IsSunk(playerBoard.Grid)))
                {
                    MessageBox.Show("Комп'ютер переміг! Всі ваші кораблі знищено.");
                    Application.Restart();
                    return;
                }
            }
        }

        private void MarkAiHitsAroundSunk(Ship ship)
        {
            foreach (var deck in ship.Decks)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        int nx = deck.X + dx, ny = deck.Y + dy;
                        if (nx >= 0 && nx < 10 && ny >= 0 && ny < 10)
                            aiHits[nx, ny] = true;
                    }
                }
            }
        }

        private void AddTarget(int x, int y)
        {
            if (x >= 0 && x < 10 && y >= 0 && y < 10 && !aiHits[x, y])
                targets.Insert(0, new Point(x, y));
        }
    }
}