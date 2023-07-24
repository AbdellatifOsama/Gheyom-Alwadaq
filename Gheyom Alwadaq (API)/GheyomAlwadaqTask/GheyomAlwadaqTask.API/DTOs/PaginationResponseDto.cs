namespace GheyomAlwadaqTask.API.DTOs
{
    public class PaginationResponseDto<T>
    {
        public PaginationResponseDto(int pageIndex, int pageSize, int totalItems, List<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItems = totalItems;
            this.data = data;
            TotalPages = (TotalItems / pageSize) + ((TotalItems % pageSize) / 10 > 0 ? ((TotalItems % pageSize) / 10) : (int)Math.Ceiling((decimal)(TotalItems % pageSize) / 10));
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> data { get; set; }
    }
}
