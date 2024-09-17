using Alansar.Client.Components.Pages;
using Alansar.Components;
using Alansar.Components.Account;
using Alansar.Core.Entities.Identity;
using Alansar.Data;
using Alansar.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;


var builder = WebApplication.CreateBuilder(args);

// If running in staging, set specific URLs
if (builder.Environment.IsStaging())
{
    builder.WebHost.UseUrls("http://localhost:5081");
}

// Add core services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CookieService>();

// Add controllers, razor pages, and HTTP context accessor
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();


// Configure HTTP client for the app
builder.Services.AddHttpClient("MyAppClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5081/");
});
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyAppClient"));


// Add MudBlazor services with custom configuration
builder.Services.AddMudServices(config =>
{
    config.PopoverOptions.ThrowOnDuplicateProvider = false;
});

// Add Blazor services for Razor components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Configure authentication state management
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

// Add database context with PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<AppDbContext>(opt =>
{
    opt.UseNpgsql(connectionString);
    opt.EnableSensitiveDataLogging();
});

// Add exception filter for database-related issues
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure Identity with user and role management
builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddSignInManager()
.AddDefaultTokenProviders();

// Register a no-op email sender for identity
builder.Services.AddSingleton<IEmailSender<User>, IdentityNoOpEmailSender>();

//congfigure cookie for returning 401 on accessing authorized apis
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        if (context.Request.Path.StartsWithSegments("/api"))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        }
        context.Response.Redirect(context.RedirectUri);
        return Task.CompletedTask;
    };
});



// Build the app
var app = builder.Build();


// Apply migrations on startup
if (!app.Environment.IsProduction())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.EnsureDeleted();
        context.Database.Migrate();
    }
}


// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}


app.UseExceptionHandler(a => a.Run(async context =>
{
    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
    var error = exceptionHandlerPathFeature?.Error;

    var statusCode = context.Response.StatusCode; // Get the actual status code

    var problemDetails = new ProblemDetails
    {
        Status = statusCode, // Set the status code from the response context
        Title = "An error occurred",
        Detail = error?.Message ?? "An unexpected error occurred.",
    };

    context.Response.ContentType = "application/json";
    await context.Response.WriteAsJsonAsync(problemDetails);
}));



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();


// Configure Razor components and map endpoints
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Alansar.Client._Imports).Assembly);

// Add identity-specific Razor page endpoints
app.MapAdditionalIdentityEndpoints();

// Map controllers and Razor pages
app.MapControllers();
app.MapRazorPages();

// Run the app
app.Run();














//var builder = WebApplication.CreateBuilder(args);

//if (builder.Environment.IsStaging())
//{
//    builder.WebHost.UseUrls("http://localhost:5081");
//}

//builder.Services.AddScoped<UserService>();
//builder.Services.AddScoped<CookieService>();


//builder.Services.AddControllers();
//builder.Services.AddRazorPages();
////builder.Services.AddRazorPages(options =>
////{
////    options.Conventions.AddPageRoute("/Auth/Login", "/Auth/Login");
////});

//builder.Services.AddHttpClient();
//builder.Services.AddHttpClient("MyAppClient", client =>
//{
//    client.BaseAddress = new Uri("http://localhost:5081/");
//});
//builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyAppClient"));
//builder.Services.AddHttpContextAccessor();

//// Add MudBlazor services
////builder.Services.AddMudServices();
//builder.Services.AddMudServices(config =>
//{
//    config.PopoverOptions.ThrowOnDuplicateProvider = false; // Disable the duplicate provider warning
//});

//// Add services to the container.
//builder.Services.AddRazorComponents()
//    .AddInteractiveServerComponents()
//    .AddInteractiveWebAssemblyComponents();

//builder.Services.AddCascadingAuthenticationState();
//builder.Services.AddScoped<IdentityUserAccessor>();
//builder.Services.AddScoped<IdentityRedirectManager>();
//builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

//builder.Services.AddAuthentication(options =>
//    {
//        options.DefaultScheme = IdentityConstants.ApplicationScheme;
//        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
//    })
//    .AddIdentityCookies();

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
////builder.Services.AddDbContext<AppDbContext>(options =>
////    options.UseSqlServer(connectionString));
//builder.Services.AddDbContextFactory<AppDbContext>(opt =>
//{
//    opt.UseNpgsql(connectionString);
//    opt.EnableSensitiveDataLogging();
//});


//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
////builder.Services.AddIdentityCore<User>(options => 
//{
//    //options.SignIn.RequireConfirmedAccount = true;
//    options.User.RequireUniqueEmail = true;

//})
//.AddEntityFrameworkStores<AppDbContext>()
//.AddSignInManager()
//.AddDefaultTokenProviders();

//builder.Services.AddSingleton<IEmailSender<User>, IdentityNoOpEmailSender>();




//var app = builder.Build();

//// Apply migrations on startup
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var context = services.GetRequiredService<AppDbContext>();
//    context.Database.EnsureDeleted();
//    context.Database.Migrate();
//}

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseWebAssemblyDebugging();
//    app.UseMigrationsEndPoint();
//}
//else
//{
//    app.UseExceptionHandler("/Error", createScopeForErrors: true);
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();

//app.UseStaticFiles();
////app.UseAntiforgery();

//app.MapRazorComponents<App>()
//    .AddInteractiveServerRenderMode()
//    .AddInteractiveWebAssemblyRenderMode()
//    .AddAdditionalAssemblies(typeof(Alansar.Client._Imports).Assembly);

//// Add additional endpoints required by the Identity /Account Razor components.
//app.MapAdditionalIdentityEndpoints();

//app.UseAuthentication();
//app.UseAuthorization();

//app.UseAntiforgery();


////app.UseRouting();
////app.UseAntiforgery();

//app.MapControllers();
//app.MapRazorPages();

//app.Run();



