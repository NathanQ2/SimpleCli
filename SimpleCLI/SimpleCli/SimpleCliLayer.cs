using SimpleCli.Arg;

namespace SimpleCli;

public abstract class SimpleCliLayer
{
    public abstract void OnPush();
    public abstract bool OnUpdate();
    public abstract void OnStart();
}
