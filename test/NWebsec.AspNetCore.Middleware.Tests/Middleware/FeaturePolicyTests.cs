using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace NWebsec.AspNetCore.Middleware.Tests.Middleware
{
    public class FeaturePolicyTests
    {
        private static string GetFeaturePolicy(HttpResponseHeaders headers) =>
            headers.GetValues("Feature-Policy").First();


        [Fact]
        public async Task AutoPlay_None()
        {
            using (var server = new TestServer(new WebHostBuilder().Configure(app =>
            {
                app.UseFeaturePolicy(config => config.AutoPlay(a => a.None()));
                app.Run(async context =>
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Hello world");
                });
            })))
            {
                server.BaseAddress = new Uri("http://localhost/");

                using (var httpClient = server.CreateClient())
                {
                    var response = await httpClient.GetAsync("http://localhost/BasePath/RequestPath/");
                    Assert.Equal("autoplay 'none'", GetFeaturePolicy(response.Headers));
                }
            }
        }

        [Fact]
        public async Task AutoPlay_Self()
        {
            using (var server = new TestServer(new WebHostBuilder().Configure(app =>
            {
                app.UseFeaturePolicy(config => config.AutoPlay(a => a.Self()));
                app.Run(async context =>
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Hello world");
                });
            })))
            {
                server.BaseAddress = new Uri("http://localhost/");

                using (var httpClient = server.CreateClient())
                {
                    var response = await httpClient.GetAsync("http://localhost/BasePath/RequestPath/");
                    Assert.Equal("autoplay 'self'", GetFeaturePolicy(response.Headers));
                }
            }
        }

        [Fact]
        public async Task AutoPlay_All()
        {
            using (var server = new TestServer(new WebHostBuilder().Configure(app =>
            {
                app.UseFeaturePolicy(config => config.AutoPlay(a => a.All()));
                app.Run(async context =>
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Hello world");
                });
            })))
            {
                server.BaseAddress = new Uri("http://localhost/");

                using (var httpClient = server.CreateClient())
                {
                    var response = await httpClient.GetAsync("http://localhost/BasePath/RequestPath/");
                    Assert.Equal("autoplay *", GetFeaturePolicy(response.Headers));
                }
            }
        }

        [Fact]
        public async Task AutoPlay_Src()
        {
            using (var server = new TestServer(new WebHostBuilder().Configure(app =>
            {
                app.UseFeaturePolicy(config => config.AutoPlay(a => a.CustomSources("google.com")));
                app.Run(async context =>
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Hello world");
                });
            })))
            {
                server.BaseAddress = new Uri("http://localhost/");

                using (var httpClient = server.CreateClient())
                {
                    var response = await httpClient.GetAsync("http://localhost/BasePath/RequestPath/");
                    Assert.Equal("autoplay google.com", GetFeaturePolicy(response.Headers));
                }
            }
        }
    }
}