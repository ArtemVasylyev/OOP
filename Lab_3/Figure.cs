using System;

namespace FigureCalculator
{
    // Абстрактний базовий клас
    public abstract class Figure
    {

        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    // Похідний клас: Прямокутник
    public class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea() => Width * Height;
        public override double GetPerimeter() => 2 * (Width + Height);
    }

    // Похідний клас: Коло
    public class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetArea() => Math.PI * Math.Pow(Radius, 2);
        public override double GetPerimeter() => 2 * Math.PI * Radius;
    }

    // Похідний клас: Трапеція
    public class Trapezium : Figure
    {
        public double BaseA { get; set; }
        public double BaseB { get; set; }
        public double SideC { get; set; }
        public double SideD { get; set; }
        public double Height { get; set; }

        public Trapezium(double baseA, double baseB, double sideC, double sideD, double height)
        {
            BaseA = baseA;
            BaseB = baseB;
            SideC = sideC;
            SideD = sideD;
            Height = height;
        }

        public override double GetArea() => ((BaseA + BaseB) / 2) * Height;
        public override double GetPerimeter() => BaseA + BaseB + SideC + SideD;
    }
}