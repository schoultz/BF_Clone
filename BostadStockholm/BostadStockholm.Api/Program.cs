using BostadStockholm.Services.Interfaces;

using BostadStockholm.Services;
using BostadStockholm.Services.Implementations;
using NHibernate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

//FIX ISession test-------------------
// Register the singleton NHibernate ISessionFactory from your helper
builder.Services.AddSingleton(factory => BostadStockholm.Data.NHibernateHelper.SessionFactory);
//Register ISession scoped (one session per request)
builder.Services.AddScoped(factory =>
{
    var sessionFactory = factory.GetRequiredService<ISessionFactory>();
    return sessionFactory.OpenSession();
});
//Register your application services that depend on ISession
builder.Services.AddScoped<IApartmentService, ApartmentService>();
//END FIX ISession test-------------------

// Add OpenAPI/Swagger services (assuming AddOpenApi is an extension method you have)
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();

