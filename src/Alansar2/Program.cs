using Alansar.Data;
using Alansar.Entities.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Alansar2.Components;
using Alansar.Services;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsStaging())
{
    builder.WebHost.UseUrls("http://localhost:5001");
}

//builder.Services.AddHostedService<DiningAssignmentService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CookieService>();


//builder.Services.AddRazorPages().AddMvcOptions(options =>
//{
//    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
//});
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddPageRoute("/Auth/Login", "/Auth/Login");
});


builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient("MyAppClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5001/");
});
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyAppClient"));

builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<AuthenticationStateProvider>();


// Add MudBlazor services
//builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


//builder.Services.AddDbContextFactory<AppDbContext>(opt =>
//{
//    //var connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");
//    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
//    opt.UseNpgsql(connectionString);
//    opt.EnableSensitiveDataLogging();
//});


//builder.Services.AddIdentity<User, IdentityRole<int>>(opt =>
//{
//    opt.User.RequireUniqueEmail = true;
//})
//.AddEntityFrameworkStores<AppDbContext>()
//.AddDefaultTokenProviders();



#region Authentication & Authorization
//builder.Services.Configure<IdentityOptions>(options =>
//{
//    //options.Password.RequireDigit = true;
//    //options.Password.RequiredLength = 8;
//    //options.Password.RequireNonAlphanumeric = false;
//    //options.Password.RequireUppercase = true;
//    //options.Password.RequireLowercase = false;
//});

//builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
//    .AddCookie(IdentityConstants.ApplicationScheme);

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.Cookie.Name = "auth_token";
//    options.LoginPath = "/login";
//    options.LogoutPath = "/logout";
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//    options.Cookie.SameSite = SameSiteMode.Strict;
//});

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//})
//.AddCookie(options =>
//{
//    options.Cookie.Name = "auth_token";
//    options.LoginPath = "/login";
//    options.LogoutPath = "/logout";
//    options.Cookie.HttpOnly = true;
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
//});

//builder.Services.AddAuthorization();
//builder.Services.AddAuthorizationCore();  // Adds support for core authorization
//builder.Services.AddCascadingAuthenticationState();

#endregion


builder.Services.AddIdentity<User, IdentityRole<int>>(opt =>
{
    opt.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


builder.Services.AddDbContextFactory<AppDbContext>(opt =>
{
    //var connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    opt.UseNpgsql(connectionString);
    opt.EnableSensitiveDataLogging();
});



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
    });

builder.Services.AddAuthorization();
builder.Services.AddAuthorizationCore();  // Adds support for core authorization
builder.Services.AddCascadingAuthenticationState();



//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(builder =>
//    {
//        builder.AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//    });
//});


var app = builder.Build();

// Apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    //context.Database.EnsureDeleted();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAuthentication();
app.UseAuthorization();

//app.UseRouting();
//app.UseAntiforgery();

app.MapControllers();
app.MapRazorPages();

app.Run();
