using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_11 
{
    public partial class Form1 : Form
    {
        private string dbFile = "AirportDB.sqlite";
        private string connString;

        public Form1()
        {
            InitializeComponent();
            connString = $"Data Source={dbFile};Version=3;";
            InitializeDatabase(); // a. Підключення та створення БД
        }

        // --- СТВОРЕННЯ БД ТА 2-Х ТАБЛИЦЬ ---
        private void InitializeDatabase()
        {
            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    // Таблиця 1: Рейси
                    string createFlights = "CREATE TABLE Flights (Id INTEGER PRIMARY KEY AUTOINCREMENT, Destination TEXT, Price REAL)";
                    // Таблиця 2: Квитки (зв'язок з рейсами)
                    string createTickets = "CREATE TABLE Tickets (Id INTEGER PRIMARY KEY AUTOINCREMENT, FlightId INTEGER, PassengerName TEXT)";

                    using (var cmd = new SQLiteCommand(createFlights, conn)) cmd.ExecuteNonQuery();
                    using (var cmd = new SQLiteCommand(createTickets, conn)) cmd.ExecuteNonQuery();
                }
            }
        }

        // Універсальний метод для відображення даних у DataGridView
        private void ShowData(string sqlQuery)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (var adapter = new SQLiteDataAdapter(sqlQuery, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        // b. Введення даних: ДОДАТИ РЕЙС (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                string sql = "INSERT INTO Flights (Destination, Price) VALUES (@dest, @price)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@dest", textBox1.Text);
                    cmd.Parameters.AddWithValue("@price", Convert.ToDouble(textBox2.Text));
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Рейс додано!");
            button3_Click(null, null); // Оновлюємо таблицю рейсів
        }

        // b. Введення даних: КУПИТИ КВИТОК (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                string sql = "INSERT INTO Tickets (FlightId, PassengerName) VALUES (@fId, @pass)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fId", Convert.ToInt32(textBox3.Text));
                    cmd.Parameters.AddWithValue("@pass", textBox1.Text); // ПІБ беремо з першого поля
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Квиток продано!");
            button4_Click(null, null); // Оновлюємо таблицю квитків
        }

        // c. Побудова звіту 1: УСІ РЕЙСИ (button3)
        private void button3_Click(object sender, EventArgs e)
        {
            ShowData("SELECT * FROM Flights");
        }

        // c. Побудова звіту 2: ПРОДАНІ КВИТКИ (JOIN двох таблиць) (button4)
        private void button4_Click(object sender, EventArgs e)
        {
            // Звіт показує ІД квитка, ПІБ пасажира та куди він летить (з іншої таблиці)
            string sql = @"SELECT Tickets.Id AS TicketID, Tickets.PassengerName, Flights.Destination, Flights.Price 
                           FROM Tickets 
                           JOIN Flights ON Tickets.FlightId = Flights.Id";
            ShowData(sql);
        }

        // d. Пошук у БД по одному критерію: ПОШУК ЗА НАПРЯМКОМ (button5)
        private void button5_Click(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                string sql = "SELECT * FROM Flights WHERE Destination LIKE @search";
                using (var adapter = new SQLiteDataAdapter(new SQLiteCommand(sql, conn)))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
}