using BostadStockholm.web.Data;
using BostadStockholm.web.Models;
using System;
using System.Security.Cryptography.Pkcs;
using System.Threading.Tasks;

namespace BostadStockholm.web.Services
{
    public class UserActivityService
    {
        private readonly ApplicationDbContext _context;
        public UserActivityService(ApplicationDbContext context) => _context = context;
        public async Task LogActivityAsync(string user, string action)
        {
            var activity = new UserActivity { UserName = user, Action = action, Timestamp = DateTime.UtcNow };
            _context.UserActivities.Add(activity);
            await _context.SaveChangesAsync();

        }
    }
}