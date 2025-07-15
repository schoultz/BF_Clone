using FluentNHibernate.Mapping;
using BostadStockholm.Core.Entities;

namespace BostadStockholm.Data.Mappings
{
    public class ApartmentMap : ClassMap<Apartment>
    {
        public ApartmentMap() 
        {
            Table("Apartments");
            Id(x  => x.Id);
            Map(x => x.ApartmentNumber);
            Map(x => x.Rooms);
            Map(x => x.Area);
            Map(x => x.MonthlyRent);
            Map(x => x.HasBalcony);
            Map(x => x.Floor);
            Map(x => x.IsAvailable);
            Map(x => x.AvailableFrom);
            Map(x => x.Description);
            Map(x => x.CreatedAt);
            References(x => x.Property).Column("PropertyId");
            References(x => x.HousingType).Column("HousingTypeId");
            HasMany(x => x.Applications).KeyColumn("ApartmentId").Inverse().Cascade.All();
        }
    }
}
