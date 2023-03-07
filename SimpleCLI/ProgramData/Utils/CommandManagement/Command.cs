namespace SimpleCLI.ProgramData.Utils.CommandManagement;

public class Command
{
    public CommandType CommandType { get; private set; } = CommandType.None;
    public CommandArgs? CommandArgs { get; private set; }

    // command(string) -> command(Command)
    public static Command GetCommand(string cmd)
    {
        Command command = new Command();
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
                command.CommandArgs = new CommandArgs {WhatToSay = args[1]};

                break;
            default:
                command.CommandType = CommandType.NotRecognized;

                break;
        }
        
        return command;
    }
}
