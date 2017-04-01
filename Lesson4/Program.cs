using System;

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

            Shape[] shapes = new Shape[4];
            shapes[0] = rectangle;
            shapes[1] = circle;
            shapes[2] = triangle;
            shapes[3] = sector;

            foreach(Shape shape in shapes)
            {
                Console.WriteLine(shape.GetName());
                Console.WriteLine(shape.GetArea());
                Console.WriteLine(shape.GetPerimeter());
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
