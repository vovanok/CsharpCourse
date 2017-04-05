using System;
using System.Collections.Generic;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(10.5f, 50f);
            Circle circle = new Circle(50f);
            Triangle triangle = new Triangle(10f, 20.5f, 30f);
            Sector sector = new Sector(30f, 50f);

            List<Shape> shapes =
                new List<Shape> { rectangle, circle, triangle, sector };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.Name);
                Console.WriteLine(shape.GetArea());
                Console.WriteLine(shape.GetPerimeter());
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
