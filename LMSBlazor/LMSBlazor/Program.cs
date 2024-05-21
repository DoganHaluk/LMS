using LMSBlazor;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<SchoolClassService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<CoachService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7024") });

await builder.Build().RunAsync();
