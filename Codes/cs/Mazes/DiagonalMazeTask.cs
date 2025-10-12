using System;

namespace Mazes;

public static class DiagonalMazeTask
{
    public static void MoveStraightNSteps(Robot robot, Direction dir, int N)
    {
        for (var i = 0; i < N; i++)
        {
            robot.MoveTo(dir);
        }
    }

    public static int CountSteps(int length1, int length2)
	{
		return Math.Max(1,(int)Math.Round(1.0 * length1 / length2));
	}

    const int BorderSize = 1;
    
    public static void MoveOut(Robot robot, int width, int height)
    {
        var gorisontalSteps = CountSteps(width, height);
        var verticalSteps = CountSteps(height, width);
        var countStraightLines = (Math.Min(width, height) - 2 * BorderSize) * 2 - 1;
        bool isDown;
        for (int i = 0; i < countStraightLines; i++)
        {
            isDown = (height > width && i % 2 == 0) || (height <= width && i % 2 != 0);
            if (isDown) MoveStraightNSteps(robot, Direction.Down, verticalSteps);
            else MoveStraightNSteps(robot, Direction.Right, gorisontalSteps);
        }
    }
}