namespace BostadStockholm.Core.Entities
{
    public class Application
    {
        public virtual Guid Id { get; set; }

        public virtual Guid UserId { get; set; }
        public virtual Guid ApartmentId { get; set; }

        public virtual DateTime ApplicationDate { get; set; }

        public virtual int QueuePosition { get; set; }

        public virtual string Status { get; set; }

        public virtual string Notes { get; set; }

        public virtual User User { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}