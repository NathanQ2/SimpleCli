using System.Text;
using SimpleCli.Arg;

namespace SimpleCliApp;

public enum PotentialCommands
{
    None,
    Message
}

public enum PotentialFlags
{
    None,
    HelloFlag,
    GoodbyeFlag
}

public static class CommandManager
{
    public static bool TryStringToCommandEnum(string arg, out PotentialCommands result)
    {
        switch (arg)
        {
            case "message":
                result = PotentialCommands.Message;

                return true;
        }

        result = PotentialCommands.None;

        return false;
    }

    public static bool TryStringToFlagEnum(string arg, PotentialCommands command, out PotentialFlags result)
    {
        switch  (command)
        {
            case PotentialCommands.Message:
                switch (arg)
                {
                    case "-h" or "--hello":
                        result = PotentialFlags.HelloFlag;

                        return true;
                    case "-b" or "--bye":
                        result = PotentialFlags.GoodbyeFlag;

                        return true;
                }

                break;
            case PotentialCommands.None:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(command), command, null);
        }

        result = PotentialFlags.None;

        return false;
    }

    public static bool TryStringToFlagsEnum(string[] args, PotentialCommands command, out PotentialFlags[] result)
    {
        result = Array.Empty<PotentialFlags>();
        var flags = new List<PotentialFlags>();

        foreach (string arg in args)
        {
            if (!TryStringToFlagEnum(arg, command, out PotentialFlags flag))
            {
                //return false;
            }

            flags.Add(flag);
        }

        result = flags.ToArray();

        return true;
    }

    public static string CommandEnumToString(PotentialCommands command)
    {
        switch (command)
        {
            case PotentialCommands.Message:
                return "Message";

            case PotentialCommands.None:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(command), command, null);
        }

        return "";
    }

    public static string FlagEnumToString(PotentialFlags flag)
    {
        switch (flag)
        {
            case PotentialFlags.HelloFlag:
                return "-h";
            case PotentialFlags.GoodbyeFlag:
                return "-b";
            default:
                return "";
        }
    }

    public static string FlagsEnumToString(PotentialFlags[] flags)
    {
        var sb = new StringBuilder();

        foreach (PotentialFlags flag in flags)
        {
            sb.Append(FlagEnumToString(flag));
            sb.Append(' ');
        }

        return sb.ToString();
    }
}