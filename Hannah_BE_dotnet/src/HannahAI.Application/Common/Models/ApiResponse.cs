namespace HannahAI.Application.Common.Models;

public class ApiResponse<T>
{
    public bool Succeeded { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public List<string>? Errors { get; set; }

    public ApiResponse(T data, string? message = null)
    {
        Succeeded = true;
        Data = data;
        Message = message;
    }

    public ApiResponse(string message, List<string>? errors = null)
    {
        Succeeded = false;
        Message = message;
        Errors = errors;
    }

    public static ApiResponse<T> Success(T data, string? message = null)
    {
        return new ApiResponse<T>(data, message);
    }

    public static ApiResponse<T> Failure(string message, List<string>? errors = null)
    {
        return new ApiResponse<T>(message, errors);
    }
}
