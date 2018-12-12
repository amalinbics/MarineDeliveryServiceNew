namespace QueryBase
{
    public interface IQueryFetch
    {
        string GetQuery<T>(T command);
    }
}
