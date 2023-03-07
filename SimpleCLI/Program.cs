using SimpleCLI.ProgramData.Utils.CommandManagement;

namespace SimpleCLI;

internal static class Program
{
    private static void Main()
    {
        while (true)
            Command.DoCommand(Command.GetCommand());
        // ReSharper disable once FunctionNeverReturns
    }
}