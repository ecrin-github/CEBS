namespace CEBS.Contracts.Responses;

public class ApiResponse<T> : BaseResponse<T>
{
    public int? Size { get; set; } = 10;
    public int? Page { get; set; } = 1;
    public int StatusCode { get; set; }
    public string[] Messages { get; set; } = Array.Empty<string>();
}