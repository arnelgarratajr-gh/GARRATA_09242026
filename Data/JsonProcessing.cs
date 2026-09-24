using System;
using System.Text.Json;

namespace GARRATA_09242026.Data;

public class JsonProcessing
{
    public class JsonProcessingResult
{
    public bool IsValid { get; set; }
    public string? ErrorMessage { get; set; }
    public JsonProcessingResponse? Response { get; set; }
}

public class JsonProcessingResponse
{
    public string Message { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public int TotalRecords { get; set; }
    public int MatchingRecords { get; set; }
    // TODO
    // Add more properties for filename and processing time
    public IReadOnlyList<JsonElement> Records { get; set; } = [];
}
}
