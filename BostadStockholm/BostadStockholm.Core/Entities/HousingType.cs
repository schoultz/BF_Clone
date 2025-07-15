namespace BostadStockholm.Core.Entities
{
    public class HousingType
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual IList<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}