using System.Net;
using IResult = GestranSuppliers.Application.Responses.Interfaces.IResult;

namespace GestranSuppliers.Application.Responses;

public class ResponseResult : IResult
{
    public ResponseResult(bool success, HttpStatusCode statusCode, object? data = null)
    {
        Success = success;
        StatusCode = statusCode;
        Data = data;
    }

    public ResponseResult(bool success, string? message, HttpStatusCode statusCode, object? data = null)
    {
        Success = success;
        Message = message;
        StatusCode = statusCode;
        Data = data;
    }
    
    public bool Success { get; set; }
    public string? Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public object? Data { get; set; }
}