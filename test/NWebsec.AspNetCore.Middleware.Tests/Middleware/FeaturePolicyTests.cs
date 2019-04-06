using System;
using System.Linq;
using System.Net;
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
        [Theory]
        [InlineData("http://localhost/")]
        [InlineData("http://localhost/BasePath/")]
        public async Task Csp_UpgradeEnabledAndUpgradableRequest_Redirects(string basePath)
        {
            using (var server = new TestServer(new WebHostBuilder().Configure(app =>
            {
                app.UseFeaturePolicy(config => { });
                app.Run(async context =>
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Hello world");
                });
            })))
            {
                server.BaseAddress = new Uri(basePath);

                using (var httpClient = server.CreateClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                    var response = await httpClient.GetAsync("http://localhost/BasePath/RequestPath/");
                    //TODO check path settings in OWIN
                    Assert.Equal(HttpStatusCode.RedirectKeepVerb, response.StatusCode);
                    Assert.Equal("Upgrade-Insecure-Requests", response.Headers.Vary.Single());
                    Assert.Equal("https://localhost/BasePath/RequestPath/", response.Headers.Location.AbsoluteUri);
                }
            }
        }
    }
}