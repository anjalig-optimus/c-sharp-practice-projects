using System;
namespace OOPS
{
    class Abstraction
    {
        static void Main2(
            
            )
        {
            Rectangle rectangle = new Rectangle(10, 20);
            Console.WriteLine($"Area of Rectangle: {rectangle.GetArea()}");

            Triangle triangle = new Triangle(15, 25);
            Console.WriteLine($"Area of Triangle: {triangle.GetArea()}");

            Circle circle = new Circle(12);
            Console.WriteLine($"Area of Circle: {circle.GetArea()}");

            Cone cone = new Cone(5, 15);
            Console.WriteLine($"Area of Cone: {rectangle.GetArea()}");

            Console.ReadKey();
        }
    }

    public abstract class Shape
    {
        public double Height;
        public double Width;
        public double Radius;
        public const float PI = 3.14f;
        public abstract double GetArea();
    }

    public class Rectangle : Shape
    {
        public Rectangle(double Height, double Width)
        {
            this.Height = Height;
            this.Width = Width;
        }

        public override double GetArea()
        {
            return Width * Height;
        }
    }
    public class Circle : Shape
    {
        public Circle(double Radius)
        {
            this.Radius = Radius;
        }

        public override double GetArea()
        {
            return PI * Radius * Radius;
        }
    }
    public class Triangle : Shape
    {
        public Triangle(double Height, double Width)
        {
            this.Height = Height;
            this.Width = Width;
        }

        public override double GetArea()
        {
            return (Width * Height) / 2;
        }
    }
    public class Cone : Shape
    {
        public Cone(double Radius, double Height)
        {
            this.Radius = Radius;
            this.Height = Height;
        }

        public override double GetArea()
        {
            return PI * Radius * (Radius + Math.Sqrt(Height * Height + Radius * Radius));
        }
    }
}
