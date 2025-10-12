namespace Mazes;

public static class EmptyMazeTask
{
	public static void MoveStraightNSteps(Robot robot, Direction dir, int N)
	{
		for (int i = 0; i < N; i++)
		{
			robot.MoveTo(dir);
		}
	}
	const int BorderSize = 1;

	public static void MoveOut(Robot robot, int width, int height)
	{
		MoveStraightNSteps(robot, Direction.Right, width - BorderSize*2 - 1);
		MoveStraightNSteps(robot, Direction.Down, height - BorderSize*2 - 1);
	}
}