using SimpleCli.Arg;

namespace SimpleCliApp;

public static class Program
{
    private static AppLayer? _appLayer;
    
    private static void Main(string[] args)
    {
        var argParser = new ArgParser<PotentialCommands, PotentialFlags>(
            CommandManager.TryStringToCommandEnum,
            CommandManager.TryStringToFlagsEnum);
        
        _appLayer = new AppLayer(argParser.Parse(args));
        
        SimpleCli.SimpleCli.PushLayer(_appLayer);
        SimpleCli.SimpleCli.Start();
    }
}