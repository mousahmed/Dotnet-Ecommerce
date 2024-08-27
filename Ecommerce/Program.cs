using Ecommerce.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using dotenv.net;

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
