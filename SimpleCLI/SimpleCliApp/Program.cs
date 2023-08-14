namespace SimpleCliApp;

public static class Program
{
    private static AppLayer _appLayer = new AppLayer();
    
    private static void Main()
    {
        SimpleCli.SimpleCli.PushLayer(_appLayer);
        SimpleCli.SimpleCli.Start();
    }
}