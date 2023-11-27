using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWASM;
using Client.Implementations;
using Client.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IPackageService, PackageHttpClient>();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(
    sp => 
        new HttpClient { 
            BaseAddress = new Uri("http://localhost:5106") 
        }
);

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();