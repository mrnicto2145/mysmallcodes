using System;
using System.Globalization;

namespace Hello
{
    class Program
    {
        public static double Calculates(string userInput)
        {
	        string[] userInputs=userInput.Split();
            double baseDebt = double.Parse(userInputs[0]);
            double procent = double.Parse(userInputs[1]);
            int timeInMonth = int.Parse(userInputs[2]);
            return baseDebt * Math.Pow(1 + (procent/100) / 12, timeInMonth);
        }
        static void Main()
        {
            string userInput;
            userInput = Console.ReadLine();
            double ans = Calculates(userInput);
            Console.WriteLine(ans);
        }
    }
}
