using ToyRobotSimulator.Constant;
using ToyRobotSimulator.Services;

namespace ToyRobotSimulator;

public class CommandProcessor
{
    Table table;
    bool isPlaced = false;

    public CommandProcessor()
    {
        table = new(0, 0, RobotDirectionType.SOUTH_WEST);
    }

    public void Execute(string input)
    {
        try
        {
            string[] command = input.Split(" ");
            RobotServices service = new(table, CONST.TABLE_SIZE);

            switch (command[0])
            {
                case CONST.PLACE when command.Length == 2:
                    table = service.Place(command[1], isPlaced);

                    if (table is not null)
                        isPlaced = true;
                    break;
                case CONST.MOVE:

                    if (!isPlaced)
                        return;

                    table = service.Move();
                    break;
                case CONST.LEFT:

                    if (!isPlaced)
                        return;

                    table = service.RotateLeft();
                    break;
                case CONST.RIGHT:

                    if (!isPlaced)
                        return;

                    table = service.RotateRight();
                    break;
                case CONST.REPORT:

                    if (!isPlaced)
                        return;

                    Console.WriteLine(service.Report());
                    break;
                default:
                    throw new ArgumentException("Command not accepted");
            }
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
    }
}
