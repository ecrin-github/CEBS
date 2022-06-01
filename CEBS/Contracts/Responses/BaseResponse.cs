namespace CEBS.Contracts.Responses;

public class BaseResponse<T>
{
    public int Total { get; set; }
    public T[] Data { get; set; } = Array.Empty<T>();
}