namespace CapitoleSantander;

public class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
             .ConfigureAppConfiguration((hostContext, config) => { }).Build();
        try
        {
            //logs
            host.Run();
        }
        catch (Exception ex)
        {
            //logs
        }
        finally
        {
        }
    }
}
