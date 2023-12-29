using System.Net.Http.Json;

using TestApp;

namespace MyFirstLib;

public class SgvDownloader
{
    private readonly HttpClient _client;

    public SgvDownloader(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Class1>> Downloader()
    {
        var result = await _client.GetFromJsonAsync<Class1[]>("entries.json");
        return result ?? [];
    }
}