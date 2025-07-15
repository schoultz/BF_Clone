using FluentNHibernate.Mapping;
using BostadStockholm.Core.Entities;

namespace BostadStockholm.Data.Mappings 
{
    public class NewsMap : ClassMap<News> 
    {
        public NewsMap()
        {
            Table("News");
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Content);
            Map(x => x.Summary);
            Map(x => x.PublishedDate);
            Map(x => x.AuthorName);
            Map(x => x.IsPublished);
            Map(x => x.Tags);
        }
    }
}