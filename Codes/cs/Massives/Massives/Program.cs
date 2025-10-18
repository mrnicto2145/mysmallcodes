
using System.Diagnostics;

namespace Hello
{
    class Program
    {
        static int[][] ToMultySet(int[] a)
        {
            var b = new int[a.Length];
            var count = new int[a.Length];
            var t = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (b[t] != a[i])
                {
                    count[t] = 1;
                    b[t] = a[i];
                    t++;
                }
                else
                {
                    count[t] += 1;
                }
            }
            var c = new int[t + 1];
            var fcount = new int[t + 1];
            for (int i = 0; i < t + 1; i++)
            {
                c[t] = b[t];
                fcount[t] = count[t];
            }
            var r = new int[2][] { c, fcount };
            return r;
        }

        static int[][] MultyIntersection(int[][] a, int[][] b)
        {
            var cd = new int[a.Length + b.Length];
            var cc = new int[a.Length + b.Length];
            var t = 0;
            for (int i = 0; i < a[0].Length; i++)
            {
                for (int j = 0; j < b[0].Length; j++)
                {
                    if (a[0][i] > b[0][j]) break;
                    else if (a[0][i] == b[0][j])
                    {
                        cd[t] = a[0][i];
                        cc[t] = Math.Min(a[1][i], b[1][j]);
                        t++;
                    }
                }
            }
            var cf = new int[2][] { new int[t + 1], new int[t + 1] };
            for (int i = 0; i < t + 1; i++)
            {
                cf[0][i] = cd[i];
                cf[1][i] = cc[i];
            }
            return cf;
        }
        static int[][] MultyUnion(int[][] a, int[][] b)
        {
            var cd = new int[a.Length + b.Length];
            var cc = new int[a.Length + b.Length];
            var t = 0;
            for (int i = 0; i < a[0].Length; i++)
            {
                var flag = true;
                for (int j = 0; j < cd.Length; j++)s
                {
                    if (a[0][i] == cd[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    cd[t] = a[0][i];
                    cc[t] = a[1][i];
                    t++;
                }
            }
            var cf = new int[2][] { new int[t + 1], new int[t + 1] };
            for (int i = 0; i < t + 1; i++)
            {
                cf[0][i] = cd[i];
                cf[1][i] = cc[i];
            }
            return cf;
        }
        static void Main()
        {
            var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var ma = ToMultySet(a);
            var mb = ToMultySet(b);
            
        }
    }


}
