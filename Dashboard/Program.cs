using Dashboard.Areas.Identity.Data;
using Dashboard.Data;
using Dashboard.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DashboardContextConnection");builder.Services.AddDbContext<DashboardContext>(options =>
    options.UseSqlServer(connectionString));builder.Services.AddDefaultIdentity<DashboardUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DashboardContext>();
// Add services to the container.
builder.Services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<TestService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseMvcWithDefaultRoute();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
