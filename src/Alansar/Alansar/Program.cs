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

// Register the Refit client for your API
builder.Services.AddRefitClient<IStudentApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:5081/"));


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

// Add Identity For DbContext
builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//identity
//builder.Services.AddDbContext<IdentityDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddIdentity<User, IdentityRole<int>>()
//    .AddEntityFrameworkStores<IdentityDbContext>()
//    .AddDefaultTokenProviders();

//interceptor for identityDbContext
//builder.Services.AddScoped<SyncEntityInterceptor>();

//builder.Services.AddDbContext<IdentityDbContext>((serviceProvider, options) =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
//           .AddInterceptors(serviceProvider.GetRequiredService<SyncEntityInterceptor>());
//});


//interceptor for AppDbContext
//builder.Services.AddScoped<TenantSaveChangesInterceptor>();

//builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
//           .AddInterceptors(serviceProvider.GetRequiredService<TenantSaveChangesInterceptor>());
//});




// Add exception filter for database-related issues
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure Identity with user and role management
//builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
//{
//    options.User.RequireUniqueEmail = true;
//})
//.AddEntityFrameworkStores<AppDbContext>()
//.AddSignInManager()
//.AddDefaultTokenProviders();

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

        // Apply IdentityDbContext migrations
        //var identityDbContext = services.GetRequiredService<IdentityDbContext>();
        //identityDbContext.Database.EnsureDeleted();
        //identityDbContext.Database.Migrate();

        // Apply AppDbContext migrations
        var appDbContext = services.GetRequiredService<AppDbContext>();
        appDbContext.Database.EnsureDeleted();
        appDbContext.Database.Migrate();

        // Seed data for both contexts
        await SeedData.SeedAsync(services);
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

    var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
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

//builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
////builder.Services.AddIdentityCore<User>(options => 
//{
//    //options.SignIn.RequireConfirmedAccount = true;
//    options.User.RequireUniqueEmail = true;

//})
//.AddEntityFrameworkStores<AppDbContext>()
//.AddSignInManager()
//.AddDefaultTokenProviders();


//app.MapAdditionalIdentityEndpoints();



