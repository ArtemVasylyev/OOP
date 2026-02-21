using System;
using System.Drawing;

namespace ShapesApp
{

    public abstract class Shape
    {

        public float X { get; set; }
        public float Y { get; set; }
        public float Angle { get; set; }
        public string Name { get; set; }

        public static int TotalShapesCount { get; private set; } = 0;


        public Shape() 
        { 
            X = 200; Y = 200; Name = "Невідома фігура"; Angle = 0; 
            TotalShapesCount++; 
        }

        public Shape(float x, float y) 
        { 
            X = x; Y = y; Name = "Невідома фігура"; Angle = 0; 
            TotalShapesCount++; 
        }

        public Shape(float x, float y, string name) 
        { 
            X = x; Y = y; Name = name; Angle = 0; 
            TotalShapesCount++; 
        }

        public void Move(float dx, float dy)
        {
            X += dx;
            Y += dy;
        }

        public void Move(PointF offset)
        {
            X += offset.X;
            Y += offset.Y;
        }

        public virtual void Rotate(float angleDegrees)
        {
            Angle += angleDegrees;
        }


        public abstract void Resize(float factor);
        public abstract void Draw(Graphics g);
        public abstract string GetInfo();
    }



    public class MyRectangle : Shape
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public MyRectangle(float x, float y, float w, float h) : base(x, y, "Прямокутник")
        {
            Width = w; Height = h;
        }

        public override void Resize(float factor) { Width *= factor; Height *= factor; }

        public override void Draw(Graphics g)
        {

            g.TranslateTransform(X, Y);
            g.RotateTransform(Angle);
            g.DrawRectangle(Pens.Blue, -Width / 2, -Height / 2, Width, Height);
            g.ResetTransform();
        }

        public override string GetInfo() => $"{Name}: ({X}, {Y}), Ш:{Width}, В:{Height}, Кут:{Angle}°";
    }

    public class MySquare : Shape
    {
        public float Side { get; set; }

        public MySquare(float x, float y, float side) : base(x, y, "Квадрат")
        {
            Side = side;
        }

        public override void Resize(float factor) { Side *= factor; }

        public override void Draw(Graphics g)
        {
            g.TranslateTransform(X, Y);
            g.RotateTransform(Angle);
            g.DrawRectangle(Pens.Green, -Side / 2, -Side / 2, Side, Side);
            g.ResetTransform();
        }

        public override string GetInfo() => $"{Name}: ({X}, {Y}), Сторона:{Side}, Кут:{Angle}°";
    }

    public class MyCircle : Shape
    {
        public float Radius { get; set; }

        public MyCircle(float x, float y, float radius) : base(x, y, "Коло")
        {
            Radius = radius;
        }

        public override void Resize(float factor) { Radius *= factor; }

        public override void Draw(Graphics g)
        {
            g.TranslateTransform(X, Y);
            g.RotateTransform(Angle);
            g.DrawEllipse(Pens.Red, -Radius, -Radius, Radius * 2, Radius * 2);

            g.DrawLine(Pens.Red, 0, 0, Radius, 0);
            g.ResetTransform();
        }

        public override string GetInfo() => $"{Name}: ({X}, {Y}), R:{Radius}, Кут:{Angle}°";
    }
}