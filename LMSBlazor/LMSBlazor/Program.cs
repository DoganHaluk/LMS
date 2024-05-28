using BlazorStrap;
using LMSBlazor;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<SchoolClassService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddSingleton<LocalStorageService>();
builder.Services.AddScoped<CoachService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<SchoolClassCourseService>();
builder.Services.AddScoped<LearningModuleService>();
builder.Services.AddScoped<CodelabService>();
builder.Services.AddScoped<StudentCodelabService>();
builder.Services.AddBlazorStrap();
builder.Services.AddSingleton<StateContainer>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7024") });

await builder.Build().RunAsync();
