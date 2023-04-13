using System;

namespace GeometryLibrary
{
    public interface IShape
    {
        double GetArea();
    }

    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }
    }

    public class Triangle : IShape
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public double GetArea()
        {
            double p = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        }

        public bool IsRightAngled()
        {
            double[] sides = { sideA, sideB, sideC };
            Array.Sort(sides);

            return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);
        }
    }

    public class ShapeFactory
    {
        public static IShape CreateShape(string shapeType, params double[] parameters)
        {
            if (shapeType.ToLower() == "circle" && parameters.Length == 1)
            {
                return new Circle(parameters[0]);
            }
            else if (shapeType.ToLower() == "triangle" && parameters.Length == 3)
            {
                return new Triangle(parameters[0], parameters[1], parameters[2]);
            }
            else
            {
                throw new ArgumentException("Invalid arguments.");
            }
        }
    }
}
