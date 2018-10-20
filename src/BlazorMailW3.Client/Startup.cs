using BionicExtensions.Attributes;
using BlazorMailW3.Client.Services;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorMailW3.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            InjectableAttribute.RegisterInjectables(services);
            InjectableAttribute.RegisterInjectables(services);
            services.AddSingleton<AppState>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("body");
        }
    }
}
