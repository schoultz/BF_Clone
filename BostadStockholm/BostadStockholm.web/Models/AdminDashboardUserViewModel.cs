using Microsoft.AspNetCore.Identity;

namespace BostadStockholm.web.Models
{
    public class AdminDashboardUserViewModel
    {
        public IdentityUser User { get; set; }
        public bool IsAdmin { get; set; }
    }
}