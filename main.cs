using System;
using GeometryLibrary;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите радиус круга:");
            double radius = double.Parse(Console.ReadLine());

            IShape circle = ShapeFactory.CreateShape("circle", radius);
            Console.WriteLine($"Площадь круга с радиусом {radius}: {circle.GetArea()}");

            Console.WriteLine("Введите длины сторон треугольника (через пробел):");
            string[] sides = Console.ReadLine().Split(' ');
            double a = double.Parse(sides[0]);
            double b = double.Parse(sides[1]);
            double c = double.Parse(sides[2]);

            IShape triangle = ShapeFactory.CreateShape("triangle", a, b, c);
            Console.WriteLine($"Площадь треугольника со сторонами {a}, {b}, {c}: {triangle.GetArea()}");

            if (triangle is Triangle t && t.IsRightAngled())
            {
                Console.WriteLine("Треугольник является прямоугольным.");
            }
        }
    }
}