using BostadStockholm.Data;
using BostadStockholm.Data.Interfaces;
using BostadStockholm.Data.Repositories;
using BostadStockholm.Services.Implementations;
using BostadStockholm.Services.Interfaces;
using BostadStockholm.web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using BostadStockholm.web.Services;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register NHibernate ISession as Scoped
builder.Services.AddScoped(factory => NHibernateHelper.OpenSession());

// Register repository generic type
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Register business services
builder.Services.AddScoped<IApartmentService, ApartmentService>();

//Phase 14, Step 1.3 - Register Identity Services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Phase 16, Step 4.9 - Test the full identity flow - Test the forgot password flow - Avoid Duplicate Identity Registrations
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddDefaultIdentity<IdentityUser>(options =>
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<ApplicationDbContext>()
//Phase 16, Step 4 - Test the Full Identity Flow - ERROR: How to Register Token Providers
.AddDefaultTokenProviders();

//Phase 15, Step 1.4 - Register Identity UI in Program.cs
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

//Phase 16, Step 3.2 - Passsword Reset Support - Enable Email Sending Support
builder.Services.AddTransient<IEmailSender, DummyEmailSender>();

//Phase 17, Step 5.3.3: Admin Dashboard and User Role Management: Fix the Admin Dashboard: Access Denied Page: Configure the Redirect to AccessDenied 
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Account/AccessDenied";
});

//Phase 18, Step 1.2 - Logging, Error Handling and UserActivity Auditing: Add Logging Support: Ensure Logging is enabled by default via the builder.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//Phase 18, Step 3.4 - Logging, Error Handling, and User Activity Auditing: User Activity Auditing: Register the service in Program.cs
builder.Services.AddScoped<UserActivityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

    app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

////Phase 14, Step 1.4 - Add Identity Middleware
app.UseAuthentication();

app.UseAuthorization();

//Phase 18: Step 4.4: Logging Error Handling; Test: Trigger known errors to test error handling
//app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");
app.UseStatusCodePagesWithReExecute("/Home/Error404");

// Not in instructions
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    // Not in instructions
    .WithStaticAssets();

//Phase 15, Step 1.4 - Register Identity UI in Program.cs - Add to middleware pipeline
app.MapRazorPages();

//Phase 18: Step 4.4: Logging Error Handling; Test: Trigger known errors to test error handling
app.MapControllers();
app.MapDefaultControllerRoute();
app.MapControllerRoute(
     name: "404",
     pattern: "{*url}",
     defaults: new { controller = "Home", action = "Error404" });

//Phase 17, Step 1.2 - Admin dashboard and user role management - Create Admin role and seed it
static async Task SeedRolesAndAdminAsync(IServiceProvider services)
{
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    var adminEmail = "admin@bostadstockholm.se";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
        await userManager.CreateAsync(adminUser, "AdminPassword123!");
    }

    if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
    {
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}

//Phase 17, Step 1.1 - Admin dashboard and user role management - Create Admin role and seed it
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedRolesAndAdminAsync(services);
}
    app.Run();
