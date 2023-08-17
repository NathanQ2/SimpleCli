namespace SimpleCli.Arg;

public class Command<TPotentialCommands, TPotentialFlags>
    where TPotentialCommands : Enum
    where TPotentialFlags : Enum
{
    public readonly TPotentialCommands BaseCommand;
    public readonly TPotentialFlags[]    Flags;

    public Command(TPotentialCommands command, TPotentialFlags[] flags)
    {
        BaseCommand = command;
        Flags = flags;
    }
}
