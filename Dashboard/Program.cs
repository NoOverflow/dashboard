using Dashboard.Areas.Identity.Data;
using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Models.Widgets;
using Dashboard.Services;
using Dashboard.Services.Widget;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DashboardContextConnection");

builder.Services.AddDbContextFactory<DashboardContext>(options => options.UseSqlServer(connectionString));
builder.Services
    .AddDefaultIdentity<DashboardUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedEmail = false;
    })
    .AddEntityFrameworkStores<DashboardContext>();
builder.Services.AddHttpClient();
builder.Services
    .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
    .AddScoped<IUrlHelper>(x => x
        .GetRequiredService<IUrlHelperFactory>()
        .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext));
builder.Services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
builder.Services.AddRazorPages();
builder.Services.AddScoped<SessionState>();
builder.Services.AddBlazorContextMenu();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<TestService>();
builder.Services.AddScoped<UpdateService>(provider => new UpdateService(TimeSpan.FromMilliseconds(1000))); // TODO: Make this a user configuration

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddAuthentication()
    .AddSpotify(options =>
    {
        options.Scope.Add("user-read-private");
        options.Scope.Add("user-read-email");
        options.UsePkce = true;
        options.ClientId = "31136507629443baa7494abbc7856cd9";
        options.ClientSecret = builder.Configuration["spotify-app-secrets"];
        options.CallbackPath = "/spotify-callback";
    })
    .AddMicrosoftAccount(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Microsoft:id"];
        options.ClientSecret = builder.Configuration["Authentication:Microsoft:secret"];
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:id"];
        options.ClientSecret = builder.Configuration["Authentication:Google:secret"];
    });


   

builder.Services.AddScoped<OAuthManagerService>(provider => new OAuthManagerService(
        provider.GetService<IHttpClientFactory>(),
        provider.GetService<AuthenticationStateProvider>(),
        provider.GetService<UserManager<DashboardUser>>(),
        provider.GetService<IUserStore<DashboardUser>>(),
        provider.GetService<IDbContextFactory<DashboardContext>>()
    )
    .RegisterOAuth(ServiceType.Spotify, new OAuthConfiguration()
    {
        TokenUrl = "https://accounts.spotify.com/api/token",
        AuthorizeUrl = "https://accounts.spotify.com/authorize",
        Id = "31136507629443baa7494abbc7856cd9",
        RedirectUrl = "/spotify-service-callback",
        Secret = builder.Configuration["spotify-app-secrets"],
        Scopes = new[]
        {
            "user-read-private",
            "user-read-email",
            "user-modify-playback-state",
            "user-read-playback-state",
            "streaming",
            "user-read-currently-playing"
        }
    }));

// Register OAuth dashboard services
builder.Services.AddScoped<WeatherService>(provider => new WeatherService(
    provider.GetService<IHttpClientFactory>(),
    "https://api.weatherapi.com",
    builder.Configuration["weather-api-key"]
));

builder.Services.AddScoped<NYTimesService>(provider => new NYTimesService(
    provider.GetService<IHttpClientFactory>(),
    "https://api.nytimes.com/svc/news/v3",
    builder.Configuration["nytimes-api-key"]
));

builder.Services.AddScoped<SpotifyService>(provider => new SpotifyService(
    provider.GetService<NavigationManager>(),
    provider.GetService<UserManager<DashboardUser>>(),
    provider.GetService<OAuthManagerService>(),
    provider.GetService<SessionState>()
));

// Register widgets
builder.Services.AddSingleton<WidgetFactoryService>(provider =>
    new WidgetFactoryService()
        .RegisterWidgetType<NewsWidgetModel>()
        .RegisterWidgetType<SpotifyWidgetModel>()
        .RegisterWidgetType<WeatherWidgetModel>()
);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthorization();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseMvcWithDefaultRoute();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
