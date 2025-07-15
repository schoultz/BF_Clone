using FluentNHibernate.Mapping;
using BostadStockholm.Core.Entities;

namespace BostadStockholm.Data.Mappings 
{
    public class HousingTypeMap : ClassMap<HousingType>
    {
        public HousingTypeMap() 
        {
            Table("HousingTypes");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.IsActive);
            HasMany(x => x.Apartments).KeyColumn("HousingTypeId").Inverse().Cascade.All();
        }
    }
}