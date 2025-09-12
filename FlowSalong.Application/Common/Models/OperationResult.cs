namespace FlowSalong.Application.Common.Models;

public record OperationResult<T>(bool Success, T? Data = default, string? ErrorMessage = null)
{
    public static OperationResult<T> Ok(T data) => new(true, data);
    public static OperationResult<T> Fail(string message) => new(false, default, message);
};
