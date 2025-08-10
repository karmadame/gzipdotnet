using BenchmarkDotNet.Attributes;

namespace gzip.benchmark;

public class GzipVsDefault
{
    private readonly GzipClient _gzipClient = new();
    private readonly DefaultClient _defaultClient = new();
    
    [Params(1000, 10000)]
    public int N;
    
    [Benchmark]
    public List<Todo>? DefaultLiteTodos()
    {
        var result = _defaultClient.LiteTodos();
        result.Wait();  
        return result.Result?.ToList();   
    }
    
    [Benchmark]
    public List<Todo>? GzipLiteTodos()
    {
        var result = _gzipClient.LiteTodos();
        result.Wait();  
        return result.Result?.ToList();   
    }
    
    [Benchmark]
    public List<Todo>? DefaultLongTodos()
    {
        var result = _defaultClient.LongTodo();
        result.Wait();  
        return result.Result?.ToList();   
    }
    
    [Benchmark]
    public List<Todo>? GzipLongTodos()
    {
        var result = _gzipClient.LongTodo();
        result.Wait();  
        return result.Result?.ToList();   
    }
}