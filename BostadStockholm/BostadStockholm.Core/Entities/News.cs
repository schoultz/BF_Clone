namespace BostadStockholm.Core.Entities
{
    public class News
    {
        public virtual Guid Id { get; set; }
        
        public virtual string Title { get; set; }
        
        public virtual string Content { get; set; }

        public virtual string Summary { get; set; }
        
        public virtual DateTime PublishedDate { get; set; }

        public virtual string AuthorName { get; set; }

        public virtual bool IsPublished { get; set; }

        public virtual string Tags { get; set; }
    }
}