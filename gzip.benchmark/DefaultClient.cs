using System.Net;
using System.Net.Http.Json;

namespace gzip.benchmark;

public class DefaultClient
{
    private readonly HttpClient _client;

    public DefaultClient()
    {
        _client = new HttpClient();
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