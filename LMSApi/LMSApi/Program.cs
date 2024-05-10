using LMSApi.Configuration;
using LMSApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
