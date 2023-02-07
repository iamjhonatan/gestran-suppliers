namespace GestranSuppliers.Application.Responses;

public class Pagination<T>
{
    public Pagination(int total, int page, int limit, IEnumerable<T> data)
    {
        Total = total;
        Page = page;
        Limit = limit;
        Data = data;
    }

    public int Total { get; set; }
    public int Page { get; set; } = 0;
    public int Limit { get; set; }
    public IEnumerable<T> Data { get; set; }
}