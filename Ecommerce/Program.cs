using Ecommerce.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using dotenv.net;
using Ecommerce.DataAccess.Respository.IRepository;
using Ecommerce.DataAccess.Respository;
using Microsoft.AspNetCore.Identity;
using Ecommerce.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from the .env file
DotEnv.Load();

// Build the connection string using environment variables
var connectionString = string.Format(
    "Server={0},{1};Database={2};User Id={3};Password={4};TrustServerCertificate=True;",
    Environment.GetEnvironmentVariable("SQLSERVER_HOST"),
    Environment.GetEnvironmentVariable("SQLSERVER_PORT"),
    Environment.GetEnvironmentVariable("SQLSERVER_DB"),
    Environment.GetEnvironmentVariable("SQLSERVER_USER"),
    Environment.GetEnvironmentVariable("SQLSERVER_PASSWORD")
);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
