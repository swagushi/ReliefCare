using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AidCare_The_Rise_Of_The_Aid.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AidCareContextConnection") ?? throw new InvalidOperationException("Connection string 'AidCareContextConnection' not found.");

builder.Services.AddDbContext<AidCareContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<AidCareUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AidCareContext>();;

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
