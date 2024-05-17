using LMSApi.Configuration;
using LMSApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Switchfully.DotNetToolkit.Authentication;
using System.Text.Json.Serialization;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SchoolClassService>();
builder.Services.AddScoped<LearningModuleService>();
builder.Services.AddScoped<LearningModuleEditor>();
builder.Services.AddScoped<SchoolClassEditor>();
builder.Services.AddScoped<CoachSchoolClassService>();
builder.Services.AddScoped<CoachService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<CourseEditor>();
builder.Services.AddScoped<SchoolClassCourseService>();
builder.Services.AddScoped<SchoolClassCourseEditor>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<StudentEditor>();
builder.Services.AddScoped<CodelabService>();
builder.Services.AddScoped<CodelabEditor>();
builder.Services.AddScoped<StudentCodelabService>();
builder.Services.AddScoped<StudentCodelabEditor>();
builder.Services.AddDbContext<LMSDbContext>(
	options =>
	{
		options.UseSqlServer(builder.Configuration["ConnectionString"]);
	});
builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Authentication
builder.Services
	.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(JwtUtilities.JwtBearerConfigurationOptions);
// Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
			loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
