namespace SimpleCli.Arg;


public class ArgParser<TCommandsEnum, TFlagsEnum> 
    where TCommandsEnum : Enum
    where TFlagsEnum : Enum
{
    public delegate bool TryCommandStringToArgEnum(string arg, out TCommandsEnum result);

    public delegate bool TryFlagStringToArgEnum(string[] args, TCommandsEnum command, out TFlagsEnum[] result);

    private readonly TryCommandStringToArgEnum _tryCommandStringToEnum;
    private readonly TryFlagStringToArgEnum _tryFlagArgStringToEnum;
    
    public ArgParser(TryCommandStringToArgEnum tryCommandStringToEnum, TryFlagStringToArgEnum tryFlagArgStringToEnum)
    {
        _tryCommandStringToEnum = tryCommandStringToEnum;
        _tryFlagArgStringToEnum = tryFlagArgStringToEnum;
    }

    /// <summary>
    /// Parse a command
    /// </summary>
    /// <param name="args">string[] of every word in the command</param>
    /// <returns>Parsed command as "SimpleCli.Arg.Command" object</returns>
    public Command<TCommandsEnum, TFlagsEnum>? Parse(string[] args)
    {
        // try to parse the base command
        if (!_tryCommandStringToEnum(args[0], out TCommandsEnum baseCommand))
            return null;
        // try to parse the flags
        if (!_tryFlagArgStringToEnum(args, baseCommand, out TFlagsEnum[] flags))
            flags = Array.Empty<TFlagsEnum>();

        return new Command<TCommandsEnum, TFlagsEnum>(baseCommand, flags);
    }
}
