namespace Mazes;

public static class SnakeMazeTask
{
    public static void MoveStraightNSteps(Robot robot, Direction dir, int N)
    {
        for (int i = 0; i < N; i++)
        {
            robot.MoveTo(dir);
        }
    }
    
    const int VerticalCorridorSteps = 2;
    const int BorderSize = 1;

    public static void MoveOut(Robot robot, int width, int height)
    {
        int repeatableParts = 2 * (height / 4) - 1;
        int gorisontalSteps = width - 2 * BorderSize - 1;
        for (int i = 0; i < repeatableParts; i++)
        {
            MoveStraightNSteps(robot, Direction.Right - 1 * (i % 2), gorisontalSteps);
            MoveStraightNSteps(robot, Direction.Down, VerticalCorridorSteps);
        }
        MoveStraightNSteps(robot, Direction.Left, gorisontalSteps);
    }
}