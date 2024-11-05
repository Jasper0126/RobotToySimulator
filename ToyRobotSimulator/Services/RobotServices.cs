using ToyRobotSimulator.Constant;

namespace ToyRobotSimulator.Services;

public class RobotServices
{
    readonly int tableSize = 5;
    readonly Table table;

    public RobotServices(Table table, int tableSize)
    {
        this.table = table;
        this.tableSize = tableSize;
    }

    bool ValidateFuturePosition(int x, int y)
    {
        return x >= 0 && x < tableSize && y >= 0 && y < tableSize;
    }

    public Table Place(string placeInput, bool isPlaced)
    {
        string[]? parameters = placeInput.Split(",");
        string? direction = parameters.Length == 2 ? null : parameters[2];

        bool isValidX = int.TryParse(parameters[0], out int x);
        bool isValidY = int.TryParse(parameters[1], out int y);
        bool isDirectionValid = !string.IsNullOrEmpty(direction) && Enum.IsDefined(typeof(RobotDirectionType), direction ?? "");

        if (!isValidX || !isValidY)
        {
            throw new ArgumentException("Invalid coordinates");
        }

        if (!isDirectionValid)
        {
            if (!isPlaced || !string.IsNullOrEmpty(direction))
            {
                throw new ArgumentException("Invalid direction");
            }
        }

        if (!ValidateFuturePosition(x, y))
        {
            throw new ArgumentOutOfRangeException("Placement out of bounds.");
        }

        RobotDirectionType? parseDirection = string.IsNullOrEmpty(direction) ? null : (RobotDirectionType)Enum.Parse(typeof(RobotDirectionType), direction);

        return new Table(x, y, parseDirection ?? table.Direction);
    }

    public Table Move()
    {
        if (table == null) throw new InvalidOperationException("Robot not placed on the table.");

        int newX = table.X;
        int newY = table.Y;

        switch (table.Direction)
        {
            case RobotDirectionType.NORTH: newY++; break;
            case RobotDirectionType.SOUTH: newY--; break;
            case RobotDirectionType.EAST: newX++; break;
            case RobotDirectionType.WEST: newX--; break;
        }

        if (!ValidateFuturePosition(newX, newY))
        {
            throw new ArgumentOutOfRangeException("Placement out of bounds.");
        }

        table.X = newX;
        table.Y = newY;

        return table;
    }

    public Table RotateLeft()
    {
        if (table == null) throw new InvalidOperationException("Robot not placed on the table.");

        table.Direction = table.Direction switch
        {
            RobotDirectionType.NORTH => RobotDirectionType.WEST,
            RobotDirectionType.SOUTH => RobotDirectionType.EAST,
            RobotDirectionType.WEST => RobotDirectionType.SOUTH,
            RobotDirectionType.EAST => RobotDirectionType.NORTH
        };

        return table;
    }

    public Table RotateRight()
    {
        if (table == null) throw new InvalidOperationException("Robot not placed on the table.");

        table.Direction = table.Direction switch
        {
            RobotDirectionType.NORTH => RobotDirectionType.EAST,
            RobotDirectionType.SOUTH => RobotDirectionType.WEST,
            RobotDirectionType.WEST => RobotDirectionType.NORTH,
            RobotDirectionType.EAST => RobotDirectionType.SOUTH
        };

        return table;
    }

    public string Report()
    {
        if (table == null)
        {
            return "Robot not placed on the table.";
        }

        string direction = table.Direction?.ToString().Replace("_", " ") ?? "";
        return $"{table.X},{table.Y},{direction}";
    }
}
