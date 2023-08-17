namespace SimpleCli;

public static class SimpleCli
{
    private static SimpleCliLayer? _layer;
    public static void PushLayer(SimpleCliLayer layer)
    {
        _layer = layer;
        _layer.OnPush();
    }

    public static void Start()
    {
        if (_layer == null)
            return;
        
        _layer.OnStart();
        while (true)
        {
            if (_layer.OnUpdate()) break;
        }
    }
}