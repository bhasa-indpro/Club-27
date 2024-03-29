using Club_27.Models;
using Club_27.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Club_27;
using Club_27.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Nest;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("Club27DBContextConnection");;

//builder.Services.AddDbContext<Club27DBContext>(options =>    options.UseSqlServer(connectionString));;

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<Club27DBContext>();;

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<Club27DBContext>();
//builder.Services.AddDefaultIdentity<ApplicationRole, IdentityUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<Club27DBContext>();
builder.Services.AddSingleton<IEmailSender, EmailSender>();
var connectionString = builder.Configuration.GetConnectionString("Club_27ContextConnection");;

//builder.Services.AddDbContext<Club27DBContext>(options =>    options.UseSqlServer(connectionString));;

//var connectionstring = builder.Configuration.GetConnectionString("Club27Connection");


builder.Services.AddDbContext<Club27DBContext>(x => x.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

// Dependency Injection
builder.Services.AddScoped<EmployeeMasterSL>();
builder.Services.AddScoped<ActivityMasterSL>();
builder.Services.AddScoped<EnrollmentSL>();
builder.Services.AddScoped<TeamSL>();
builder.Services.AddScoped<VenueSL>();
builder.Services.AddScoped<BookingSL>();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var settings = new ConnectionSettings();
builder.Services.AddSingleton<IElasticClient>(new ElasticClient (settings));

builder.Services.AddRazorPages();
//builder.Services.AddSwaggerGen();

builder.Services.ConfigureApplicationCookie(options => { options.LoginPath = "/Identity/Account/Login"; });
builder.Services.ConfigureApplicationCookie(options => { options.AccessDeniedPath = "/Identity/Account/AccessDenied"; });
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
//else
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(options =>
//    {
//        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//        options.RoutePrefix = string.Empty;
//    });
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public partial class Program { }

//public partial class Program
//{
//    public static ILoggerFactory Logger { get; set; }
//}
