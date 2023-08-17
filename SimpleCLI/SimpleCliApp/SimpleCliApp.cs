using SimpleCli;
using SimpleCli.Arg;

namespace SimpleCliApp;

/// <summary>
/// Represents the app.
/// </summary>
public class AppLayer : SimpleCliLayer
{
    /// <summary>
    /// Command line commands passed through 
    /// </summary>
    private readonly Command<PotentialCommands, PotentialFlags>? _commandLineCommand;
    public AppLayer(Command<PotentialCommands, PotentialFlags>? commandLineCommand)
    {
        _commandLineCommand = commandLineCommand;
    }

    /// <summary>
    /// Gets called when this layer is pushed
    /// </summary>
    public override void OnPush()
    {
        
    }
    
    /// <summary>
    /// Runs when SimpleCli.SimpleCli.Start() gets called
    /// </summary>
    public override void OnStart()
    {
        if (_commandLineCommand == null) return;
        
        Console.WriteLine($"Arg Parsed: {CommandManager.CommandEnumToString(_commandLineCommand.BaseCommand)} {CommandManager.FlagsEnumToString(_commandLineCommand.Flags)}");

        if (_commandLineCommand.Flags.Contains(PotentialFlags.HelloFlag)) 
            Console.WriteLine("Hello");
        if (_commandLineCommand.Flags.Contains(PotentialFlags.GoodbyeFlag)) 
            Console.WriteLine("Goodbye");
    }
    
    /// <summary>
    /// Gets called every frame
    /// </summary>
    /// <returns>Weather to exit application loop or not</returns>
    public override bool OnUpdate()
    {
        Console.ReadLine();
        
        return true;
    }
}