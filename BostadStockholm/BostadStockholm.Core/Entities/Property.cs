namespace BostadStockholm.Core.Entities
{
    public class Property
    {
        public virtual Guid Id { get; set; }

        public virtual string Address { get; set; }

        public virtual int AreaId { get; set; }
        
        public virtual string PropertyOwner { get; set; }

        public virtual int BuildingYear { get; set; }

        public virtual bool HasElevator { get; set; }

        public virtual bool IsAccessible { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual Area Area { get; set; }

        public virtual IList<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}