using System;

using ClassLibraryForTests;

namespace Program;
public class Program
{
    static void Main()
    {
        var a = double.Parse(Console.ReadLine());
        var b = double.Parse(Console.ReadLine());
        var c = double.Parse(Console.ReadLine());

        var result = ClassLibraryForTests.Solver.Solve(a,b,c);

        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i]);
        }
    }
}
