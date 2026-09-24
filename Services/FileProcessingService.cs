
using System.Text.Json;
using static GARRATA_09242026.Data.JsonProcessing;


namespace GARRATA_09242026.Services;

public class FileProcessingService : IFileProcessingService
{
    public async Task<JsonProcessingResult> ProcessJsonAsync(IFormFile file, CancellationToken cancellationToken)
    {
        try
        {
            // TODO
            // Add logic to get the filename and processing time

            await using var stream = file.OpenReadStream();
            using var document = await JsonDocument.ParseAsync(
                stream,
                cancellationToken: cancellationToken);

            var activeRecords = document.RootElement
                .EnumerateArray()
                .Where(record =>
                    record.ValueKind == JsonValueKind.Object &&
                    record.TryGetProperty("active", out var activeProperty) &&
                    activeProperty.ValueKind == JsonValueKind.True)
                .Select(record => record.Clone())
                .ToArray();

            // TODO
            // add logger logic to log if file upload and process are success

            return new JsonProcessingResult
            {
                IsValid = true,
                Response = new JsonProcessingResponse
                {
                    Message = "JSON file processed successfully.",
                    FileName = file.FileName,
                    TotalRecords = document.RootElement.GetArrayLength(),
                    MatchingRecords = activeRecords.Length,
                    Records = activeRecords
                    // TODO
                    // Shape this response to add the filename and processingtime
                }
            };
        }
        catch (JsonException)
        {
            // TODO
            // add logger logic to log if error is encountered
             return Invalid("The uploaded file contains invalid JSON.");
        }
    }

    private JsonProcessingResult Invalid(string message)
{
    return new JsonProcessingResult
    {
        IsValid = false,
        ErrorMessage = message
    };
}
}
