using ToyRobotSimulator.Constant;

namespace ToyRobotSimulator;

public class Table
{
    public int X { get; set; }
    public int Y { get; set; }
    public RobotDirectionType? Direction { get; set; }

    public Table(int x, int y, RobotDirectionType? robotDirectionType = null)
    {
        X = x;
        Y = y;

        if (robotDirectionType != null)
        {
            Direction = robotDirectionType;
        }
    }
}
