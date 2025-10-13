

using System.ComponentModel;

namespace Program
{
    class Progr
    {
        static void Main()
        {
            int h, t, v, x;
            string[] userInput = Console.ReadLine().Split();
            h = int.Parse(userInput[0]);
            t = int.Parse(userInput[1]);
            v = int.Parse(userInput[2]);
            x = int.Parse(userInput[3]);
            double[] m = MinMaxTimes(h, t, v, x);
            Console.Write(m[0]);
            Console.Write(' ');
            Console.Write(m[1]);
        }
        
        static double[] MinMaxTimes(int h, int t, int v, int x)
        {
            double[] times = { 0, 0 };
            if (x * t >= h)
            {
                times[1] = h * 1.0 / (x + 1);
                times[0] = 0;
            }
            else
            {
                times[1] = Math.Min(h - x * t,t);
                times[0] = (h - x * t) * 1.0 / (v - x);
            }
            return times;
        }


    }
}
