using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppForFundamentalConcepts
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var http = new HttpClient()
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            };

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(sp => http);
            using var response = await http.GetAsync("cars.json");
            using var stream = await response.Content.ReadAsStreamAsync();
            builder.Configuration.AddJsonStream(stream);

            //Memory Configuration Source
            var vehicleData = new Dictionary<string, string>()
            {
                { "color", "blue" },
                { "type", "car" },
                { "wheels:count", "3" },
                { "wheels:brand", "Blazin" },
                { "wheels:brand:type", "rally" },
                { "wheels:year", "2008" },
            };
            var memoryConfig = new MemoryConfigurationSource { InitialData = vehicleData };

            builder.Configuration.Add(memoryConfig);

            await builder.Build().RunAsync();
        }
    }
}
