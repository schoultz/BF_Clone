using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BostadStockholm.web.Models;
using BostadStockholm.web.Services;

namespace BostadStockholm.web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AdminController> _logger;
        private readonly UserActivityService _activityService;

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<AdminController> logger, UserActivityService activityService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _activityService = activityService;
        }

        //Phase 17, Step 5.1.a - Admin Dashboard and User Role Management: Fix the Admin Dashboard: Make admin Confirmation
        //public IActionResult Index()
        //{
        //var users = _userManager.Users.ToList();
        //return View(users);
        //}
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Admin dashboard accessed by {User}", User.Identity.Name);

            await _activityService.LogActivityAsync(User.Identity.Name, "Admin dashboard accessed.");

            var users = _userManager.Users.ToList();
            var model = new List<AdminDashboardUserViewModel>();

            foreach (var user in users)
            {
                var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                model.Add(new AdminDashboardUserViewModel
                {
                    User = user,
                    IsAdmin = isAdmin
                });
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdminRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && !await _userManager.IsInRoleAsync(user, "Admin"))
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                _logger.LogInformation("{User} is now an Admin User", user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveAdminRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
                _logger.LogInformation("{User} is no longer an Admin User", user);
            }
            return RedirectToAction("Index");
        }
    }
}
