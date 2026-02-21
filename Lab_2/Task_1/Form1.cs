using System;
using System.Drawing;
using System.Windows.Forms;

namespace AddressApp
{
    public partial class Form1 : Form
    {
        private PostalAddress currentAddress;

        private TextBox txtCountry, txtCity, txtStreet, txtBuilding, txtZipCode;
        private Button btnCreate, btnUpdate, btnDestroy;
        private Label lblResult, lblCounter;

        public Form1()
        {
            InitializeUI(); 
            UpdateCounterLabel();
        }


        private void InitializeUI()
        {
            this.Text = "Поштова Адреса";
            this.Size = new Size(400, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            int y = 20;
            this.Controls.Add(new Label() { Text = "Країна:", Location = new Point(20, y), AutoSize = true });
            txtCountry = new TextBox() { Location = new Point(120, y), Text = "Україна", Width = 200 };
            this.Controls.Add(txtCountry);

            y += 30;
            this.Controls.Add(new Label() { Text = "Місто:", Location = new Point(20, y), AutoSize = true });
            txtCity = new TextBox() { Location = new Point(120, y), Text = "Київ", Width = 200 };
            this.Controls.Add(txtCity);

            y += 30;
            this.Controls.Add(new Label() { Text = "Вулиця:", Location = new Point(20, y), AutoSize = true });
            txtStreet = new TextBox() { Location = new Point(120, y), Text = "Хрещатик", Width = 200 };
            this.Controls.Add(txtStreet);

            y += 30;
            this.Controls.Add(new Label() { Text = "Будинок:", Location = new Point(20, y), AutoSize = true });
            txtBuilding = new TextBox() { Location = new Point(120, y), Text = "1", Width = 200 };
            this.Controls.Add(txtBuilding);

            y += 30;
            this.Controls.Add(new Label() { Text = "Індекс:", Location = new Point(20, y), AutoSize = true });
            txtZipCode = new TextBox() { Location = new Point(120, y), Text = "01001", Width = 200 };
            this.Controls.Add(txtZipCode);

            y += 40;
            btnCreate = new Button() { Text = "Створити", Location = new Point(20, y), Width = 100 };
            btnCreate.Click += btnCreate_Click;
            this.Controls.Add(btnCreate);

            btnUpdate = new Button() { Text = "Змінити", Location = new Point(130, y), Width = 100 };
            btnUpdate.Click += btnUpdate_Click;
            this.Controls.Add(btnUpdate);

            btnDestroy = new Button() { Text = "Знищити", Location = new Point(240, y), Width = 100 };
            btnDestroy.Click += btnDestroy_Click;
            this.Controls.Add(btnDestroy);

            y += 40;
            lblResult = new Label() { Text = "Поточна адреса:\n-", Location = new Point(20, y), Size = new Size(340, 60) };
            this.Controls.Add(lblResult);

            y += 70;
            lblCounter = new Label() { Text = "Активних адрес: 0", Location = new Point(20, y), AutoSize = true, ForeColor = Color.Blue };
            this.Controls.Add(lblCounter);
        }

        private void UpdateCounterLabel()
        {
            lblCounter.Text = $"Активних адрес у пам'яті: {PostalAddress.ActiveAddressesCount}";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            currentAddress = new PostalAddress(txtCountry.Text, txtCity.Text, txtStreet.Text, txtBuilding.Text, txtZipCode.Text);
            lblResult.Text = "Поточна адреса:\n" + currentAddress.ToString();
            UpdateCounterLabel();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentAddress != null)
            {
                currentAddress.UpdateAddress(txtStreet.Text, txtBuilding.Text);
                lblResult.Text = "Оновлена адреса:\n" + currentAddress.ToString();
            }
            else MessageBox.Show("Спочатку створіть адресу!");
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            if (currentAddress != null)
            {
                currentAddress = null;
                lblResult.Text = "Об'єкт адреси видалено з посилання.";
                GC.Collect();
                GC.WaitForPendingFinalizers();
                UpdateCounterLabel();
            }
        }
    }
}