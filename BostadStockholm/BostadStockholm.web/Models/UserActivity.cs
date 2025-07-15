using System;
using System.ComponentModel.DataAnnotations;

namespace BostadStockholm.web.Models
{
    public class UserActivity
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
    }
}