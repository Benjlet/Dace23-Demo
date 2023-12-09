namespace Dace23Demo.Abstractions
{
    public interface IHttpClientWrapper
    {
        Task<T> GetAsync<T>(string uri);
    }
}