using SimpleCLI.ProgramData.Utils.CommandManagement;

namespace SimpleCLI;

internal static class Program
{
    private static void Main()
    {
        while (true)
            DoCommand(GetCommand());
        // ReSharper disable once FunctionNeverReturns
    }

    private static Command GetCommand(string writeBefore = "")
    {
        Console.Write($"{writeBefore}>");
        
        return Command.GetCommand(Console.ReadLine() ?? "");
    }

    private static void DoCommand(Command command)
    {
        if (command.CommandType == CommandType.Help)
        {
            PrintHelp();
        }
        else if (command.CommandType == CommandType.Exit)
        {
            Environment.Exit(0);
        }
        else if (command.CommandType == CommandType.Pwd)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
        }
        else if (command.CommandType == CommandType.NotRecognized)
        {
            Console.WriteLine("That command is not known.");
        }
        else if (command.CommandType == CommandType.ExampleCommandType)
        {
            ExampleCommand(command.CommandArgs.WhatToSay);
        }
    }
    private static void PrintHelp()
    {
        Console.WriteLine("HELP:" +
                          "\n    exit - exits program" +
                          "\n    pwd - prints working directory.");
    }

    private static void ExampleCommand(string whatToSay)
    {
        Console.WriteLine(whatToSay);
    }
}