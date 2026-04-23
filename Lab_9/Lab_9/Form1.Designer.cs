namespace Lab_9
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            btnDraw = new Button();
            txtX0 = new TextBox();
            txtY0 = new TextBox();
            txtR = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(766, 909);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // btnDraw
            // 
            btnDraw.Location = new Point(932, 828);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(135, 61);
            btnDraw.TabIndex = 1;
            btnDraw.Text = "Draw grafic";
            btnDraw.UseVisualStyleBackColor = true;
            btnDraw.Click += btnDraw_Click;
            // 
            // txtX0
            // 
            txtX0.Location = new Point(995, 159);
            txtX0.Name = "txtX0";
            txtX0.Size = new Size(150, 31);
            txtX0.TabIndex = 2;
            // 
            // txtY0
            // 
            txtY0.Location = new Point(995, 225);
            txtY0.Name = "txtY0";
            txtY0.Size = new Size(150, 31);
            txtY0.TabIndex = 3;
            // 
            // txtR
            // 
            txtR.Location = new Point(995, 293);
            txtR.Name = "txtR";
            txtR.Size = new Size(150, 31);
            txtR.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(932, 165);
            label1.Name = "label1";
            label1.Size = new Size(32, 25);
            label1.TabIndex = 5;
            label1.Text = "x=";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(932, 231);
            label2.Name = "label2";
            label2.Size = new Size(33, 25);
            label2.TabIndex = 6;
            label2.Text = "y=";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(932, 299);
            label3.Name = "label3";
            label3.Size = new Size(35, 25);
            label3.TabIndex = 7;
            label3.Text = "R=";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 933);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtR);
            Controls.Add(txtY0);
            Controls.Add(txtX0);
            Controls.Add(btnDraw);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnDraw;
        private TextBox txtX0;
        private TextBox txtY0;
        private TextBox txtR;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
