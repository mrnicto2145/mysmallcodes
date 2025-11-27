namespace Help
{
    class Program
    {
        static void Main()
        {
            var userInput = Console.ReadLine().Split();
            var a = double.Parse(userInput[0]);
            var b = double.Parse(userInput[1]);
            var c = double.Parse(userInput[2]);
            var d = double.Parse(userInput[3]);
            var startCrossing = Math.Max(a, c);
            var endCrossing = Math.Min(b, d);
            Console.WriteLine(endCrossing >= startCrossing);
        }


    }



}