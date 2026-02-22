using System;
using System.Drawing;
using System.Windows.Forms;

namespace FigureCalculator
{
    public partial class Form1 : Form
    {

        private ComboBox cmbFigureType;
        private Label lblParam1, lblParam2, lblParam3, lblParam4, lblParam5;
        private TextBox txtParam1, txtParam2, txtParam3, txtParam4, txtParam5;
        private Button btnCalculate;
        private Label lblResult;

        public Form1()
        {
            InitializeUI(); 
            cmbFigureType.SelectedIndex = 0; 
        }

        private void InitializeUI()
        {
            this.Text = "Лабораторна 3: Обчислення фігур";
            this.Size = new Size(350, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            cmbFigureType = new ComboBox { Location = new Point(20, 20), Width = 290, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbFigureType.Items.AddRange(new string[] { "Прямокутник", "Коло", "Трапеція" });
            cmbFigureType.SelectedIndexChanged += CmbFigureType_SelectedIndexChanged;
            this.Controls.Add(cmbFigureType);


            lblParam1 = new Label { Location = new Point(20, 60), Width = 130 };
            txtParam1 = new TextBox { Location = new Point(160, 60), Width = 150 };
            
            lblParam2 = new Label { Location = new Point(20, 90), Width = 130 };
            txtParam2 = new TextBox { Location = new Point(160, 90), Width = 150 };
            
            lblParam3 = new Label { Location = new Point(20, 120), Width = 130 };
            txtParam3 = new TextBox { Location = new Point(160, 120), Width = 150 };
            
            lblParam4 = new Label { Location = new Point(20, 150), Width = 130 };
            txtParam4 = new TextBox { Location = new Point(160, 150), Width = 150 };
            
            lblParam5 = new Label { Location = new Point(20, 180), Width = 130 };
            txtParam5 = new TextBox { Location = new Point(160, 180), Width = 150 };

            this.Controls.AddRange(new Control[] { lblParam1, txtParam1, lblParam2, txtParam2, lblParam3, txtParam3, lblParam4, txtParam4, lblParam5, txtParam5 });


            btnCalculate = new Button { Text = "Обчислити", Location = new Point(20, 220), Width = 290, Height = 40 };
            btnCalculate.Click += BtnCalculate_Click;
            this.Controls.Add(btnCalculate);


            lblResult = new Label { Location = new Point(20, 280), Width = 290, Height = 100, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            this.Controls.Add(lblResult);
        }

        private void CmbFigureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideAllParams();

            switch (cmbFigureType.SelectedItem.ToString())
            {
                case "Прямокутник":
                    lblParam1.Text = "Ширина:";
                    lblParam2.Text = "Висота:";
                    ShowParams(2);
                    break;
                case "Коло":
                    lblParam1.Text = "Радіус:";
                    ShowParams(1);
                    break;
                case "Трапеція":
                    lblParam1.Text = "Основа A:";
                    lblParam2.Text = "Основа B:";
                    lblParam3.Text = "Бічна сторона C:";
                    lblParam4.Text = "Бічна сторона D:";
                    lblParam5.Text = "Висота:";
                    ShowParams(5);
                    break;
            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                Figure figure = null;

                switch (cmbFigureType.SelectedItem.ToString())
                {
                    case "Прямокутник":
                        figure = new Rectangle(ParseAndValidate(txtParam1.Text, "Ширина"), ParseAndValidate(txtParam2.Text, "Висота"));
                        break;
                    case "Коло":
                        figure = new Circle(ParseAndValidate(txtParam1.Text, "Радіус"));
                        break;
                    case "Трапеція":
                        figure = new Trapezium(
                            ParseAndValidate(txtParam1.Text, "Основа A"), ParseAndValidate(txtParam2.Text, "Основа B"),
                            ParseAndValidate(txtParam3.Text, "Бічна сторона C"), ParseAndValidate(txtParam4.Text, "Бічна сторона D"),
                            ParseAndValidate(txtParam5.Text, "Висота")
                        );
                        break;
                }

                if (figure != null)
                {
                    lblResult.Text = $"Площа: {Math.Round(figure.GetArea(), 2)}\nПериметр: {Math.Round(figure.GetPerimeter(), 2)}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private double ParseAndValidate(string text, string paramName)
        {
            if (!double.TryParse(text, out double value)) throw new Exception($"Введіть коректне число для '{paramName}'.");
            if (value <= 0) throw new Exception($"Значення '{paramName}' має бути більшим за нуль.");
            return value;
        }

        private void HideAllParams()
        {
            txtParam1.Visible = lblParam1.Visible = false;
            txtParam2.Visible = lblParam2.Visible = false;
            txtParam3.Visible = lblParam3.Visible = false;
            txtParam4.Visible = lblParam4.Visible = false;
            txtParam5.Visible = lblParam5.Visible = false;
            txtParam1.Text = txtParam2.Text = txtParam3.Text = txtParam4.Text = txtParam5.Text = "";
        }

        private void ShowParams(int count)
        {
            if (count >= 1) { txtParam1.Visible = lblParam1.Visible = true; }
            if (count >= 2) { txtParam2.Visible = lblParam2.Visible = true; }
            if (count >= 3) { txtParam3.Visible = lblParam3.Visible = true; }
            if (count >= 4) { txtParam4.Visible = lblParam4.Visible = true; }
            if (count >= 5) { txtParam5.Visible = lblParam5.Visible = true; }
        }
    }
}