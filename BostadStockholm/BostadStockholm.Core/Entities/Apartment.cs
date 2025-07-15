using System;
using System.ComponentModel.DataAnnotations;

namespace BostadStockholm.Core.Entities
{
    public class Apartment
    {
        public virtual Guid Id { get; set; }

        public virtual Guid PropertyId { get; set; }
        public virtual int HousingTypeId { get; set; }

        [StringLength(20)]
        public virtual string ApartmentNumber { get; set; }
        
        [Range(1, 10)]
        public virtual decimal Rooms { get; set; }

        [Range(1, 1000)]
        public virtual int Area { get; set; }

        [Range(0, 100000)]
        public virtual decimal MonthlyRent { get; set; }

        public virtual bool HasBalcony { get; set; }

        public virtual int Floor { get; set; }

        public virtual bool IsAvailable { get; set; }

        public virtual DateTime? AvailableFrom { get; set; }

        [StringLength(1000)]
        public virtual string Description { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual Property Property { get; set; }
        public virtual HousingType HousingType { get; set; }

        public virtual IList<Application> Applications { get; set; } = new List<Application>();
    }
}