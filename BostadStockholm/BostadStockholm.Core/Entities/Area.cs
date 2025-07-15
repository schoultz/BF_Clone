namespace BostadStockholm.Core.Entities
{
    public class Area
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string District { get; set; }

        public virtual string Municipality { get; set; }

        public virtual decimal Latitude { get; set; }

        public virtual decimal Longitude { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual IList<Property> Properties { get; set; } = new List<Property>();
    }
}