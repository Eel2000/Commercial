namespace Commercial.Domain.Commons;

public class Response<TData> where TData: class 
{
    public TData? Data { get; set; }
    public string[] Errors { get; set; }
    public bool Succeed { get; set; }
    public string? Message { get; set; }

    public Response(string message, TData data)
    {
        Succeed = true;
        Message = message;
        Data = data;
    }

    public Response(TData data)
    {
        Succeed = true;
        Data = data;
    }

    public Response(string message, string[] errors)
    {
        Message = message;
        Errors = errors;
        Succeed = false;
    }
}