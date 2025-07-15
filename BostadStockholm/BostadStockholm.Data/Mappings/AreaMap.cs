using FluentNHibernate.Mapping;
using BostadStockholm.Core.Entities;

namespace BostadStockholm.Data.Mappings
{
    public class AreaMap : ClassMap<Area>
    {
        public AreaMap()
        {
            Table("Areas");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.District);
            Map(x => x.Municipality);
            Map(x => x.Latitude);
            Map(x => x.Longitude);
            Map(x => x.IsActive);
            HasMany(x => x.Properties).KeyColumn("AreaId").Inverse().Cascade.All();

        }
    }
}