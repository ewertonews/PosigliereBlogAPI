using Posig.Blog.Shared;

namespace Posig.Blog.Data.Extensions
{
    public static class ListExtensions
    {
        public static PagedRecords<T> ToPagedList<T>(this List<T> list, int pageNumber, int pageSize)
        {
            return new PagedRecords<T>()
            {
                Items = list,
                Metadata = new PagedRecordsMetadata()
                {
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalCount = list.Count,
                    TotalPages = (int)Math.Ceiling(list.Count / (double)pageSize)
                }
            };
        }
    }
}
