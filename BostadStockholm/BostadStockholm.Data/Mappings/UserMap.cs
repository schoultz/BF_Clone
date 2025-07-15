using FluentNHibernate.Mapping;
using BostadStockholm.Core.Entities;

namespace BostadStockholm.Data.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id);
            Map(x => x.Email).Not.Nullable();
            Map(x => x.PasswordHash).Not.Nullable();
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.PhoneNumber);
            Map(x => x.DateOfBirth);
            Map(x => x.CreatedAt);
            Map(x => x.IsActive);
            HasMany(x => x.Applications).KeyColumn("UserId").Inverse().Cascade.All();
        }
    }
}