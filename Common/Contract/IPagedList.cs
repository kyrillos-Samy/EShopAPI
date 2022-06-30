using Newtonsoft.Json;

namespace Common.Contract
{
    [JsonObject]
    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
        T this[int index] { get; }
        int Count { get; }
        IEnumerable<T> Items { get; }
    }

    [JsonObject]
    public interface IPagedList
    {
        int PageCount { get; }
        int TotalItemCount { get; }
        int PageNumber { get; }
        int PageSize { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        bool IsFirstPage { get; }
        bool IsLastPage { get; }
        int FirstItemOnPage { get; }
        int LastItemOnPage { get; }
    }
    public class CustomPager<T> : IPagedList
    {
        public int Count => this.Items != null ? this.Items.Count() : 0;
        public IEnumerable<T> Items { get; set; }
        public int PageCount { get; set; }
        public int TotalItemCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int FirstItemOnPage { get; set; }
        public int LastItemOnPage { get; set; }

        public string Sort { get; set; }
        public bool Ascending { get; set; }
    }
}
