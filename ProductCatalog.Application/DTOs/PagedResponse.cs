namespace ProductCatalog.Application.DTOs
{
    public class PagedResponse<T>
    {
        public PagedResponse() { }

        public PagedResponse(List<T> items, int total, int pageNumber, int pageSize)
        {
            Items = items;
            Total = total;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public IReadOnlyList<T> Items { get; set; } = [];
        public int Total { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

