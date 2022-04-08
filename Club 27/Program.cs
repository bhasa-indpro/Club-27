using Club_27.Models;
using Club_27.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionstring = builder.Configuration.GetConnectionString("Club27Connection");
builder.Services.AddDbContext<Club27DBContext>(x => x.UseSqlServer(connectionstring));
// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency Injection
builder.Services.AddScoped<EmployeeMasterSL>();
builder.Services.AddScoped<ActivityMasterSL>();
builder.Services.AddScoped<EnrollmentSL>();

builder.Services.AddSwaggerGen();
var app = builder.Build();

//var path = Directory.GetCurrentDirectory();
//ILoggerFactory loggerFactory = Logger.AddFile($"{path}\\Logs\\Log.txt");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//public partial class Program
//{
//    public static ILoggerFactory Logger { get; set; }
//}
