using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    public abstract class Shape
    {
        public abstract double calculateArea();
        public abstract bool isValid();
    }

    public class Rectangle : Shape
    {
        private readonly double length;
        private readonly double width;
        public Rectangle(double _length, double _width)
        {
            length = _length;
            width = _width;
        }
        public override double calculateArea()
        {
            return isValid() ? length * width : 0;
        }
        public override bool isValid()
        {
            return length > 0 && width > 0;
        }
    }
    public class Square : Shape
    {
        private readonly double length;
        public Square(double _length)
        {
            length = _length;
        }
        public override double calculateArea()
        {
            return isValid() ? length * length : 0;
        }
        public override bool isValid()
        {
            return length > 0;
        }
    }
    public class Circle : Shape
    {
        private readonly double radius;
        public Circle(double _radius)
        {
            radius = _radius;
        }
        public override double calculateArea()
        {
            return isValid() ? radius * radius * Math.PI : 0;
        }
        public override bool isValid()
        {
            return radius > 0;
        }
    }
    internal class Program
    {
        static Shape[] generateRandomShapes(int number)
        {
            Random random = new Random();
            List<Shape> shapes = new List<Shape>();
            for (int index = 0; index < number; index++)
            {
                int type = random.Next(3);
                double param1 = (random.NextDouble() - 0.5) * 10.0;
                double param2 = (random.NextDouble() - 0.5) * 10.0;
                switch (type)
                {
                    case 0://rectangle
                        shapes.Add(new Rectangle(param1, param2));
                        break;
                    case 1://square
                        shapes.Add(new Square(param1));
                        break;
                    case 2://circle
                        shapes.Add(new Circle(param1));
                        break;
                }
            }
            return shapes.ToArray();
        }
        static double calculateAreaSum(Shape[] shapes)
        {
            double sum = 0;
            for (int index = 0; index < 10; index++)
            {
                sum += shapes[index].calculateArea();
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Shape[] shapes = generateRandomShapes(10);
            double sum = calculateAreaSum(shapes);
            Console.WriteLine($"the area sum of 10 generated random shapes is {sum}");
        }
    }
}