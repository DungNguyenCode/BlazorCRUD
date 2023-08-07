using AppView;
using AppView.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<IAPIService, APIService>();
builder.Services.AddScoped(sp=>new HttpClient { BaseAddress= new Uri("https://localhost:7233") }); // Thiết lập địa chỉ gốc

await builder.Build().RunAsync();
