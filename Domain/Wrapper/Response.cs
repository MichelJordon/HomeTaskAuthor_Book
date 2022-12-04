using System.Net;
public class Response<T>
{
    public T Data {get; set;}
    public string Massage { get; set; }
    public int StatusCode { get; set; }

    public Response(T date)
    {
        StatusCode = 200;
        Data = date;
    }
    public Response(HttpStatusCode statuscode, string message)
    {   
        StatusCode = statuscode;
        Massage = message;
    }
}