using System;

namespace BostadStockholm.Blazor.Models
{
    public class ApartmentDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public decimal Rooms { get; set; }
        public int Area { get; set; }
        public decimal MonthlyRent {  get; set; }
        public DateTime? AvailableFrom { get; set; }
    }
}