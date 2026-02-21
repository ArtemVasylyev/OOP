using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShapesApp
{
    public partial class Form1 : Form
    {
        private Shape currentShape;

        private PictureBox pbCanvas;
        private Label lblInfo;
        private Button btnRect, btnSquare, btnCircle;
        private Button btnMove, btnResize, btnShrink, btnRotate; 

        public Form1()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Геометричні фігури";

            this.Size = new Size(650, 550); 
            this.StartPosition = FormStartPosition.CenterScreen;

            int y = 20;
            Label lbl1 = new Label() { Text = "Створення:", Location = new Point(20, y), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            this.Controls.Add(lbl1);


            y += 30;
            btnRect = new Button() { Text = "Прямокутник", Location = new Point(20, y), Size = new Size(140, 35) };
            btnRect.Click += (s, e) => { currentShape = new MyRectangle(200, 200, 100, 60); UpdateCanvas(); };
            this.Controls.Add(btnRect);

            y += 45;
            btnSquare = new Button() { Text = "Квадрат", Location = new Point(20, y), Size = new Size(140, 35) };
            btnSquare.Click += (s, e) => { currentShape = new MySquare(200, 200, 80); UpdateCanvas(); };
            this.Controls.Add(btnSquare);

            y += 45;
            btnCircle = new Button() { Text = "Коло", Location = new Point(20, y), Size = new Size(140, 35) };
            btnCircle.Click += (s, e) => { currentShape = new MyCircle(200, 200, 50); UpdateCanvas(); };
            this.Controls.Add(btnCircle);

            y += 55;
            Label lbl2 = new Label() { Text = "Дії:", Location = new Point(20, y), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            this.Controls.Add(lbl2);

            y += 30;
            btnMove = new Button() { Text = "Перемістити", Location = new Point(20, y), Size = new Size(140, 35) };
            btnMove.Click += (s, e) => { currentShape?.Move(15, 15); UpdateCanvas(); }; 
            this.Controls.Add(btnMove);

            y += 45;
            btnResize = new Button() { Text = "Збільшити", Location = new Point(20, y), Size = new Size(140, 35) };
            btnResize.Click += (s, e) => { currentShape?.Resize(1.2f); UpdateCanvas(); }; // Коефіцієнт > 1 збільшує
            this.Controls.Add(btnResize);

            y += 45;
            btnShrink = new Button() { Text = "Зменшити", Location = new Point(20, y), Size = new Size(140, 35) };
            btnShrink.Click += (s, e) => { currentShape?.Resize(0.8f); UpdateCanvas(); }; // Коефіцієнт < 1 зменшує
            this.Controls.Add(btnShrink);

            y += 45;
            btnRotate = new Button() { Text = "Повернути", Location = new Point(20, y), Size = new Size(140, 35) };
            btnRotate.Click += (s, e) => { currentShape?.Rotate(15); UpdateCanvas(); };
            this.Controls.Add(btnRotate);

            y += 55;
            lblInfo = new Label() { Text = "Інформація:\n-", Location = new Point(20, y), Size = new Size(140, 100) };
            this.Controls.Add(lblInfo);

            pbCanvas = new PictureBox() 
            { 
                Location = new Point(180, 20), 
                Size = new Size(430, 430), 
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            pbCanvas.Paint += PbCanvas_Paint; 
            this.Controls.Add(pbCanvas);
        }

        private void UpdateCanvas()
        {
            if (currentShape != null)
            {
                lblInfo.Text = currentShape.GetInfo() + $"\nВсього фігур: {Shape.TotalShapesCount}";
            }
            pbCanvas.Invalidate(); 
        }

        private void PbCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            currentShape?.Draw(e.Graphics);
        }
    }
}