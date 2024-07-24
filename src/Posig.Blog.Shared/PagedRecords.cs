namespace Posig.Blog.Shared
{
    public class PagedRecords<T> { 

        public required PagedRecordsMetadata Metadata { get; set; }

        public List<T> Items { get; set; } = [];
        
    }
}
