namespace DotnetDapper.Models;

public class Response<T>
{
    public T? Result { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool Success { get; set; } = true;
}
