namespace ToyRobotSimulator;

class Program
{
    public static async Task Main(string[] args)
    {
        CommandProcessor commandProcessor = new();

        while (true)
        {
            Console.Write("Please enter command: ");
            var input = Console.ReadLine();
            commandProcessor.Execute(input?.ToUpper());
        }
    }
}
