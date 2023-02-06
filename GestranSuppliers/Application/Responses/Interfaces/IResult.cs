using System.Net;

namespace GestranSuppliers.Application.Responses.Interfaces;

public interface IResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public object Data { get; set; }
}