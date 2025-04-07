using System;

abstract class GeometricObject
{
    public abstract void SetCoefficients(params double[] coefficients);
    public abstract void PrintCoefficients();
    public abstract bool ContainsPoint(params double[] coordinates);
}

class Line2D : GeometricObject
{
    protected double a0, a1, a2;

    public override void SetCoefficients(params double[] coefficients)
    {
        a0 = coefficients[0]; a1 = coefficients[1]; a2 = coefficients[2];
    }

    public override void PrintCoefficients()
    {
        Console.WriteLine($"Коефіцієнти прямої: a0 = {a0}, a1 = {a1}, a2 = {a2}");
    }

    public override bool ContainsPoint(params double[] coordinates)
    {
        double x = coordinates[0];
        double y = coordinates[1];
        return a1 * x + a2 * y + a0 == 0;
    }
}

class Hyperplane4D : GeometricObject
{
    protected double a0, a1, a2, a3, a4;

    public override void SetCoefficients(params double[] coefficients)
    {
        a0 = coefficients[0]; a1 = coefficients[1]; a2 = coefficients[2]; a3 = coefficients[3]; a4 = coefficients[4];
    }

    public override void PrintCoefficients()
    {
        Console.WriteLine($"Коефіцієнти гіперплощини: a0 = {a0}, a1 = {a1}, a2 = {a2}, a3 = {a3}, a4 = {a4}");
    }

    public override bool ContainsPoint(params double[] coordinates)
    {
        double x1 = coordinates[0];
        double x2 = coordinates[1];
        double x3 = coordinates[2];
        double x4 = coordinates[3];
        return a1 * x1 + a2 * x2 + a3 * x3 + a4 * x4 + a0 == 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Оберіть об'єкт (1 - пряма, 2 - гіперплощина): ");
        string choice = Console.ReadLine();

        GeometricObject obj;

        if (choice == "1")
        {
            obj = new Line2D();
            obj.SetCoefficients(-6, 2, 3);
            obj.PrintCoefficients();

            Console.Write("Введіть точку (x y): ");
            string[] input = Console.ReadLine().Split();
            double x = double.Parse(input[0]);
            double y = double.Parse(input[1]);

            Console.WriteLine(obj.ContainsPoint(x, y)
                ? "Точка належить прямій."
                : "Точка не належить прямій.");
        }
        else
        {
            obj = new Hyperplane4D();
            obj.SetCoefficients(-10, 1, 2, 3, 4);
            obj.PrintCoefficients();

            Console.Write("Введіть точку (x1 x2 x3 x4): ");
            string[] input = Console.ReadLine().Split();
            double x1 = double.Parse(input[0]);
            double x2 = double.Parse(input[1]);
            double x3 = double.Parse(input[2]);
            double x4 = double.Parse(input[3]);

            Console.WriteLine(obj.ContainsPoint(x1, x2, x3, x4)
                ? "Точка належить гіперплощині."
                : "Точка не належить гіперплощині.");
        }
    }
}
