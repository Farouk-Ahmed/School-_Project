using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolProject.Core;
using SchoolProject.Core.Middleware;
using SchoolProject.Infrastructure;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Service;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Connectoion To Sql Server
builder.Services.AddDbContext<AppDBContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
});

#region Dependency Injections
builder.Services.addInfrastructureDepencenc()
				.addServiceDepencenc()
				.addCoreDepencenc();
#endregion

#region Localization
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt =>
{
	opt.ResourcesPath = "";
});
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	List<CultureInfo> supportedCultures = new List<CultureInfo>
	{
		new CultureInfo("en-US"),
		new CultureInfo("de-DE"),
		new CultureInfo("fr-FR"),
		new CultureInfo("ar-EG"),
	};
	options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ar-EG");
	options.SupportedCultures = supportedCultures;
	options.SupportedUICultures = supportedCultures;
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
#region Localization Middleware

var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion

//Using ErrorHandlerMiddleware
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
