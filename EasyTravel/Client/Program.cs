using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MudBlazor.Services;

namespace EasyTravel.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
          

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddMudServices();

            builder.Services.AddHttpClient("api", client => client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]))
                .AddHttpMessageHandler(sp =>
                {
                    var handler = sp.GetService<AuthorizationMessageHandler>()
                    .ConfigureHandler(
                        authorizedUrls: new[] { builder.Configuration["ApiUrl"] },
                        scopes: new[] { "api1" });
                    return handler;
                });

            builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("api"));

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("oidc", options.ProviderOptions);
            });
            await builder.Build().RunAsync();
        }
    }
}
