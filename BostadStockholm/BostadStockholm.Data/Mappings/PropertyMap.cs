using FluentNHibernate.Mapping;
using BostadStockholm.Core.Entities;

namespace BostadStockholm.Data.Mappings
{
    public class PropertyMap : ClassMap<Property>
    {
        public PropertyMap()
        {
            Table("Properties");
            Id(x  => x.Id);
            Map(x => x.Address);
            Map(x => x.PropertyOwner);
            Map(x => x.BuildingYear);
            Map(x => x.HasElevator);
            Map(x => x.IsAccessible);
            Map(x => x.CreatedAt);
            References(x => x.Area).Column("AreaId");
            HasMany (x => x.Apartments).KeyColumn("PropertyId").Inverse().Cascade.All();

        }
    }
}