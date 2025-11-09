using System;


namespace Hello
{
    class Sample1
    {
        public static void F()
        {
            i = 1;
        }

        public static int checki()
        {
            return i;
        }
        static int i = 0;
    }

    class Sample2
    {
        static string who = "class";

        public static void F()
        {
            string who = "F";
        }

        public static void G()
        {
            F();
            Console.WriteLine(who);
        }

        public static void H()
        {
            string who = "H";
            F();
            Console.Write(who);
        }
    }

    class Sample3
    {
        static string who = "class";

        public static void Mixed()
        {
            Console.Write(who + " ");
            string who = "Mixed";
            Console.Write(who);
        }
    }

    class Program
    {
        static void Main()
        {
            Sample1.F();
            Sample2.G();
            Sample2.H();
            Sample3.Mixed();
            Console.WriteLine(Sample1.checki());
        }
    }
    
}
