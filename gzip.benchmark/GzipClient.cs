using System.Net;
using System.Net.Http.Json;

namespace gzip.benchmark;

public class GzipClient
{
    private readonly HttpClient _client;

    public GzipClient()
    {
        var handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip
        };
        _client = new HttpClient(handler);
        _client.BaseAddress = new Uri("https://localhost:7049/api/");
    }
    
    public async Task<IEnumerable<Todo>?> LiteTodos()
    {
        var response = await _client.GetFromJsonAsync<IEnumerable<Todo>>("todos/lite");
        return response;
    }
    
    public async Task<IEnumerable<Todo>?> LongTodo()
    {
        var response = await _client.GetFromJsonAsync<IEnumerable<Todo>>("todos/lite");
        return response;
    }
}