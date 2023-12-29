using MyFirstLib;

namespace TestApp;

public class MainApp : IMainApp
{
    private readonly SgvDownloader _downloader;

    public MainApp(SgvDownloader downloader)
    {
        _downloader = downloader;
    }

    public async Task Start()
    {
        var result = await _downloader.Downloader();
        foreach (var item in result)
        {
            Console.WriteLine($"{item.sgv}");
        }
    }
}

public interface IMainApp
{
    public Task Start();
}