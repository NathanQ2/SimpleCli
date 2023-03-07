using SimpleCLI.ProgramData.Utils.Exceptions;

namespace SimpleCLI.ProgramData.Utils.CommandManagement;

// PART OF SIMPLE CLI https://github.com/BigBoyTaco/SimpleCli
public class Command
{
    // ReSharper disable once MemberCanBePrivate.Global
    public CommandType CommandType { get; set; } = CommandType.None;
    // ReSharper disable once MemberCanBePrivate.Global
    public CommandArgs? CommandArgs { get; set; }

    /// <summary>
    /// Gets and parses command (string) to Command (obj)
    /// </summary>
    /// <param name="writeBefore">string to write before "w" is printed (Ex: a directory = /Some/Path>)</param>
    /// <returns>Command obj</returns>
    public static Command GetCommand(string writeBefore = "")
    {
        Console.Write($"{writeBefore}>");
        string cmd = Console.ReadLine() ?? "";
        
        Command command = new Command();
        command.CommandArgs = new CommandArgs();
        string[] args = cmd.Split(' ');
        string baseCommand = args[0]; // base cmd Ex: help or pwd

        switch (baseCommand)
        {
            case "":
                command.CommandType = CommandType.None;

                break;
            case "exit":
                command.CommandType = CommandType.Exit;

                break;
            case "help":
                command.CommandType = CommandType.Help;

                break;
            case "pwd":
                command.CommandType = CommandType.Pwd;

                break;
            case "exampleCommand":
                command.CommandType = CommandType.ExampleCommandType;

                try
                {
                    command.CommandArgs.WhatToSay = args[1];
                }
                catch
                {
                    command.CommandArgs.WhatToSay = null;
                }

                break;
            default:
                command.CommandType = CommandType.NotRecognized;

                break;
        }
        
        return command;
    }
    
    /// <summary>
    /// Executes passed in command
    /// </summary>
    /// <param name="command">Command to execute</param>
    /// <exception cref="InvalidCommandException">Thrown when "command" or "command.CommandArgs" or "commands.CommandArgs.SomeRequiredArg" is null</exception>
    public static void DoCommand(Command? command)
    {
        if (command?.CommandArgs == null)
        {
            throw new InvalidCommandException(command, command == null, "\"command\" or \"command.CommandArgs\" is null in Command.cs");
        }

        switch (command.CommandType)
        {
            case CommandType.Help:
                Commands.PrintHelp();

                break;
            case CommandType.Exit:
                Environment.Exit(0);

                break;
            case CommandType.Pwd:
                Commands.Pwd();

                break;
            case CommandType.NotRecognized:
                Console.WriteLine("That command is not known.");

                break;
            case CommandType.ExampleCommandType when command.CommandArgs.WhatToSay == null:
                
                throw new InvalidCommandException(command, message: "\"command.CommandArgs.WhatToSay\" = null");
            case CommandType.ExampleCommandType:
                Commands.ExampleCommand(command.CommandArgs.WhatToSay);

                break;
            case CommandType.None:
               
                break;
            default:
                throw new InvalidCommandException(command);
        }
    }
    /// <summary>
    /// A static class that holds all the function commands
    /// </summary>
    private static class Commands // put command functions here
    {
        public static void PrintHelp()
        {
            Console.WriteLine("HELP:" +
                              "\n    exit - exits program" +
                              "\n    pwd - prints working directory.");
        }
    
        public static void ExampleCommand(string whatToSay)
        {
            Console.WriteLine(whatToSay);
        }

        public static void Pwd()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
        }
    }

}