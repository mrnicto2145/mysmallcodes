namespace ClassLibraryForTests;

public class Solver
{
    public static double[] Solve(double a, double b, double c)
    {
        var discriminant = b * b - 4 * a * c;
        if (discriminant > 0)
        {
            var x1 = (-b + Math.Sqrt(discriminant)) / 2 / a;
            var x2 = (-b - Math.Sqrt(discriminant)) / 2 / a; 
            return new[] {x1, x2}; 
        } 
        else if (discriminant == 0)
        {
            var x = -b / 2 /a;
            return new[] {x};
        }
        else
        {
            return new double[0];
        }
    }
}
