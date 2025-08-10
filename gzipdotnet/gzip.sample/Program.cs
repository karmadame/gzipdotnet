using System.IO.Compression;
using gzip.sample.Logic;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
    options.Providers.Add<BrotliCompressionProvider>();
    options.MimeTypes = ["application/json"];
});

builder.Services.Configure<GzipCompressionProviderOptions>(opts =>
{
    opts.Level = CompressionLevel.Fastest;
});

builder.Services.Configure<BrotliCompressionProviderOptions>(opts =>
{
    opts.Level = CompressionLevel.Fastest;
});

var app = builder.Build();

app.UseResponseCompression();

app.Use(async (context, next) =>
{
    // Ejemplo: deshabilitar compresión para endpoints sensibles
    if (context.Request.Path.StartsWithSegments("/default"))
    {
        context.Request.Headers.Remove("Accept-Encoding");
        context.Response.Headers.Remove("Content-Encoding");
    }

    await next();
});

app.MapGet("/api/todos/lite", TodoService.ShortTodoList);

app.MapGet("/api/todos/long", TodoService.LongTodoList);

app.MapGet("/default/todos/lite", TodoService.ShortTodoList);

app.MapGet("/default/todos/long", TodoService.LongTodoList);

app.Run();