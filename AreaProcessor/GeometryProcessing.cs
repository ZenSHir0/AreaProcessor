using System;

namespace AreaProcessor;

public static class GeometryProcessing
{
    public static double CircleArea(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be lower than zero number");

        return Math.Pow(radius, 2) * Math.PI;
    }
    public static double TriangleArea(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            throw new ArgumentException("One or more sides of a triangle are equal to or less than zero");
        if (a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("The sum of two side lengths has to exceed the length of the third side");

        double perimeter = a + b + c;
        double semiperimeter = perimeter / 2;
        double result = Math.Sqrt(semiperimeter * (semiperimeter - a)
            * (semiperimeter - b) * (semiperimeter - c));

        return result;
    }

    public static bool IsTriangleRight(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            throw new ArgumentException("One or more sides of a triangle are equal to or less than zero");

        double[] sides = [a, b, c];
        return Math.Pow(sides[2], 2) == Math.Pow(sides[1], 2) + Math.Pow(sides[0], 2);
    }
}
