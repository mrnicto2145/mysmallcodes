

namespace Hello
{
    class Program
    {
        static void Main()
        {
            var userInput = Console.ReadLine().Split();
            var dx = Math.Abs(userInput[0][0] - userInput[1][0]);
            var dy = Math.Abs(userInput[0][1] - userInput[1][1]);
            var bishopMove = dx == dy;
            var knightMove = (dx == 1 && dy == 2) || (dx == 2 && dy == 1);
            var rookMove = (dx != 0 && dy == 0) || (dy != 0 && dx == 0);
            var queenMove = bishopMove || rookMove;
            var kingMove = dx <= 1 && dy <= 1;
            Console.Write("Bishop: ");
            Console.WriteLine(bishopMove);
            Console.Write("Knight: ");
            Console.WriteLine(knightMove);
            Console.Write("Rook: ");
            Console.WriteLine(rookMove);
            Console.Write("Queen: ");
            Console.WriteLine(queenMove);
            Console.Write("King: ");
            Console.WriteLine(kingMove);                 
            
        }
    }
}
