namespace Posig.Blog.Shared
{
    public class PagedList<T> { 

        public required ResponseMetadata Metadata { get; set; }

        public List<T> Items { get; set; } = [];
        
    }
}
