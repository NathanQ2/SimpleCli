namespace SimpleCli;

public abstract class SimpleCliLayer
{
    /// <summary>
    /// Gets called when this layer is pushed
    /// </summary>
    public abstract void OnPush();
    /// <summary>
    /// Runs when SimpleCli.SimpleCli.Start() gets called
    /// </summary>
    public abstract void OnStart();
    /// <summary>
    /// Gets called every 'frame'
    /// </summary>
    /// <returns>Weather to exit application loop or not</returns>
    public abstract bool OnUpdate();
}
