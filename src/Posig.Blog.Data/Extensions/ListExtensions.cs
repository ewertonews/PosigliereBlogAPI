using Posig.Blog.Shared;

namespace Posig.Blog.Data.Extensions
{
    public static class ListExtensions
    {
        public static PagedList<T> ToPagedList<T>(this List<T> list, int pageNumber, int pageSize)
        {
            return new PagedList<T>()
            {
                Items = list,
                Metadata = new ResponseMetadata()
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
