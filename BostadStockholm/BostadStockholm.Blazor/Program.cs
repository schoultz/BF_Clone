using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BostadStockholm.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//But your API running at https://localhost:7285 is not an identity provider. So the Blazor app won’t be able to authenticate — it’ll fail at login.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7285/") });

//Phase 14, Step 3.2 - Configure OIDC Authentication 
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Oidc", options.ProviderOptions);
});

await builder.Build().RunAsync();
