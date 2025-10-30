namespace HannahAI.Application.Common.Models;

public class Result
{
    public bool Succeeded { get; protected set; }
    public string[] Errors { get; protected set; }

    protected Result(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }

    public static Result Success()
    {
        return new Result(true, Array.Empty<string>());
    }

    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(false, errors);
    }
}

public class Result<T> : Result
{
    public T? Value { get; }

    protected Result(T? value, bool succeeded, IEnumerable<string> errors) : base(succeeded, errors)
    {
        Value = value;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value, true, Array.Empty<string>());
    }

    public new static Result<T> Failure(IEnumerable<string> errors)
    {
        return new Result<T>(default, false, errors);
    }
}
