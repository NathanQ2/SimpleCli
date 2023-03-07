using System.Diagnostics.CodeAnalysis;
using SimpleCLI.ProgramData.Utils.CommandManagement;

// PART OF SIMPLE CLI https://github.com/BigBoyTaco/SimpleCli
namespace SimpleCLI.ProgramData.Utils.Exceptions;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class InvalidCommandException : NullReferenceException
{
    // ReSharper disable once MemberCanBePrivate.Global
    public Command? Command { get; private set; }
    // ReSharper disable once MemberCanBePrivate.Global
    public bool CommandIsNull { get; private set; }

    public InvalidCommandException() {}
    
    public InvalidCommandException(Command? command, bool commandIsNull = false, string message = "")
    {
        Command = command;
        CommandIsNull = commandIsNull;
        ConsoleColor prev = Console.BackgroundColor;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine($"Command is null: {commandIsNull}");
        Console.WriteLine(message);
        Console.BackgroundColor = prev;
    }
}
