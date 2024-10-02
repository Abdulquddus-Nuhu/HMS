using Alansar.Client;
using Alansar.Client.ApiCalls;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


//builder.Services.AddMudServices();
builder.Services.AddMudServices(config =>
{
    config.PopoverOptions.ThrowOnDuplicateProvider = false; // Disable the duplicate provider warning
});

// Register the Refit client for your API
builder.Services.AddRefitClient<IStudentApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

//builder.Services.AddRefitClient<IStudentApi>()
//    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:5081")); // Adjust the base URL as needed




builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

await builder.Build().RunAsync();
