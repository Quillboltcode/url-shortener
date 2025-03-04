

using Microsoft.AspNetCore.OpenApi;
using Dapper;
using Microsoft.Data.SqlClient;


using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Helper function for generating short codes
static string GenerateShortCode() => 
    Convert.ToBase64String(Guid.NewGuid().ToByteArray())[..8];
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>{
    c.SwaggerDoc("v1", new OpenApiInfo{
        Title = "ShortUrl Service API",
        Version = "V1",
        Description = "This is Demo api for shorturl website",
        Contact = new OpenApiContact{
            Name = " Huynh Tuan Minh",
            Email = "example@gmai.com" 
        }
    });
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped(_=>new SqlConnection(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




// UrL validation
// Validate Url : "http://www.google.com"
//              : "https://www.google.com"
static bool IsValidUrl(string url)=>
    Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

// URL Shortening endpoint
app.MapPost("/shorten", async ([FromBody]UrlRequest request,SqlConnection db, HttpContext context) =>
{   
    // Change this logging later on
    var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
    Console.WriteLine(requestBody);
    if (!IsValidUrl(request.url))
    {
        return Results.BadRequest(new{ Error = "Invalid URL" });
    }

    var shortCode = GenerateShortCode();
    Console.WriteLine(request.url);
    await db.ExecuteAsync(
        "INSERT INTO UrlMappings (ShortCode, LongUrl, CreatedAt) VALUES (@ShortCode, @LongUrl, @CreatedAt)",
        new { 
            ShortCode = shortCode, 
            LongUrl = request.url,
            CreatedAt = DateTime.UtcNow 
        });

    return Results.Ok(new { ShortUrl = $"{request.baseUrl}/{shortCode}" });
})
.WithName("ShortenUrl")
.WithOpenApi();

// Redirect endpoint
app.MapGet("/{shortCode}", async (SqlConnection db, string shortCode) =>
{
    var query = "SELECT LongUrl FROM UrlMappings WHERE ShortCode = @ShortCode";
    Console.WriteLine($"Executing SQL Query: {query} with ShortCode = {shortCode}");

    var longUrl = await db.QueryFirstOrDefaultAsync<string>(
        query,
        new { ShortCode = shortCode });
    Console.WriteLine("Run here");
    
    return string.IsNullOrEmpty(longUrl) 
        ? Results.NotFound(new { Error = "URL not found" }) 
        : Results.Ok(longUrl);
})
.WithName("RedirectUrl")
.WithOpenApi();

app.Run();



 record UrlRequest(string url, string baseUrl);