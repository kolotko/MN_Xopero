namespace Xopero.Models;

public class Result<T> : Result
{
    public T? Body { get; set; }
}
public class Result
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}