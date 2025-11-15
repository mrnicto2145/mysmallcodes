using System;

namespace Program
{
    class Program
    {
        static long ITERATION_COUNT = 0;
        public static void Main()
        {
            Console.WriteLine(nPowr(2,30));
            Console.WriteLine(ITERATION_COUNT);
            ITERATION_COUNT = 0;
            Console.WriteLine(nPownr(2,30));
            Console.WriteLine(ITERATION_COUNT);
        }

        public static long nPowr(long n, int p)
        {
            ITERATION_COUNT++;
            if (p == 1)
            {
                return n;
            }
            else if (p%2 == 1)
            {
                return n*nPowr(n, p - 1);
            }
            return nPowr(n*n, p/2);            
        }

        public static long nPownr(long n, int p)
        {
            var k = n;
            var kp = p;
            if (p == 1)
            {
                return n;
            }
            while (kp != 1)
            {
                ITERATION_COUNT++;
                if (kp % 2 == 1)
                {
                    k *=n;
                    kp--;
                }
                k *=k;
                kp = kp/2;
            }
            return k;            
        }
    }
}
