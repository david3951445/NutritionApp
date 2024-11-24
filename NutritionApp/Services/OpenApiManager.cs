using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using System.Net.Http;
using System.Runtime.CompilerServices;
namespace NutritionApp.Services;

public class OpenApiManager(OpenApiDocument document)
{
    private readonly OpenApiDocument _document = document;
    private readonly HttpClient _httpClient = new();

    public static async Task<OpenApiManager> FromUrlAsync(string apiUrl)
    {
        // Fetch the JSON content (can also use a file stream if you have a local file)
        using HttpClient httpClient = new();
        var json = await httpClient.GetStringAsync(apiUrl);

        return await FromJsonAsync(json);
    }

    public static async Task<OpenApiManager> FromJsonAsync(string json)
    {
        return new OpenApiManager(await ReadFromJsonAsync(json));
    }

    /// <summary>
    /// Read and parse the OpenAPI JSON using OpenApiStreamReader
    /// </summary>
    private static async Task<OpenApiDocument> ReadFromJsonAsync(string json)
    {
        // Create a stream from the JSON string
        using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));

        // Use OpenApiStreamReader to load the document
        var reader = new OpenApiStreamReader();
        ReadResult result = await reader.ReadAsync(stream);

        // Return the OpenAPI document
        return result.OpenApiDocument;
    }

    public async Task<string> CallGetMethodAsync(string path, string queryKey, string queryValue)
    {
        // Find the matching path in the OpenAPI document
        if (!_document.Paths.TryGetValue(path, out var pathItem))
            throw new InvalidOperationException($"Path '{path}' not found in OpenAPI document.");

        // Find a GET operation
        if (!pathItem.Operations.TryGetValue(OperationType.Get, out var getOperation))
            throw new InvalidOperationException($"GET operation not defined for path '{path}'.");

        // Validate the query parameter
        var queryParam = getOperation.Parameters.FirstOrDefault(p => p.In == ParameterLocation.Query && p.Name == queryKey)
            ?? throw new InvalidOperationException($"Query parameter '{queryKey}' not defined for path '{path}'.");

        // Build the query string
        var uri = $"{path}?{queryKey}={Uri.EscapeDataString(queryValue)}";

        // Send the GET request
        var response = await _httpClient.GetAsync(uri);

        // Ensure the response is successful
        response.EnsureSuccessStatusCode();

        // Return the response content
        return await response.Content.ReadAsStringAsync();
    }
}
