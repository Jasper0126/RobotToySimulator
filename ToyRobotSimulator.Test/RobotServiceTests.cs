using ToyRobotSimulator.Constant;
using ToyRobotSimulator.Services;

namespace ToyRobotSimulator.Test;

public class RobotServiceTests
{
    [Fact]
    public void Place_ValidInput_ShouldSuccess()
    {
        // Arrange
        Table table = new(0, 0, RobotDirectionType.SOUTH_WEST);
        var service = new RobotServices(table, CONST.TABLE_SIZE);

        // Act
        var result = service.Place("3,4,NORTH", false);

        // Assert
        Assert.Equal(3, result.X);
        Assert.Equal(4, result.Y);
        Assert.Equal(RobotDirectionType.NORTH, result.Direction);
    }

    [Fact]
    public void Move_ValidInput_ShouldSuccess()
    {
        // Arrange
        Table table = new(1, 2, RobotDirectionType.NORTH);
        var service = new RobotServices(table, CONST.TABLE_SIZE);

        // Act
        var result = service.Move();

        // Assert
        Assert.Equal(1, result.X);
        Assert.Equal(3, result.Y);
        Assert.Equal(RobotDirectionType.NORTH, result.Direction);
    }

    [Fact]
    public void RotateLeft_ValidInput_ShouldSuccess()
    {
        // Arrange
        Table table = new(1, 2, RobotDirectionType.NORTH);
        var service = new RobotServices(table, CONST.TABLE_SIZE);

        // Act
        var result = service.RotateLeft();

        // Assert
        Assert.Equal(1, result.X);
        Assert.Equal(2, result.Y);
        Assert.Equal(RobotDirectionType.WEST, result.Direction);
    }
    
    [Fact]
    public void RotateRight_ValidInput_ShouldSuccess()
    {
        // Arrange
        Table table = new(1, 2, RobotDirectionType.NORTH);
        var service = new RobotServices(table, CONST.TABLE_SIZE);

        // Act
        var result = service.RotateRight();

        // Assert
        Assert.Equal(1, result.X);
        Assert.Equal(2, result.Y);
        Assert.Equal(RobotDirectionType.EAST, result.Direction);
    }
    
    [Fact]
    public void Report_ValidInput_ShouldSuccess()
    {
        // Arrange
        Table table = new(1, 2, RobotDirectionType.NORTH);
        var service = new RobotServices(table, CONST.TABLE_SIZE);
        string expectedMessage = "1,2,NORTH";

        // Act
        var result = service.Report();

        // Assert
        Assert.Equal(expectedMessage, result);
    }
}