using FluentNHibernate.Mapping;
using BostadStockholm.Core.Entities;

namespace BostadStockholm.Data.Mappings
{
	public class ApplicationMap : ClassMap<Application> 
	{ 
		public ApplicationMap() 
		{
			Table("Applications");
			Id(x => x.Id);
			Map(x => x.ApplicationDate);
			Map(x => x.QueuePosition);
			Map(x => x.Status);
			Map(x => x.Notes);
			References(x => x.User).Column("UserId");
			References(x => x.Apartment).Column("ApartmentId");

		}
	}
}