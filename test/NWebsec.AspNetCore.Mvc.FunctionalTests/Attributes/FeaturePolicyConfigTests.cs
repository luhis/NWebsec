using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using NWebsec.AspNetCore.Mvc.FunctionalTests.Plumbing;
using Xunit;

namespace NWebsec.AspNetCore.Mvc.FunctionalTests.Attributes
{
    public class FeaturePolicyConfigTests : IDisposable
    {
        private readonly TestServer _server;
        private readonly HttpClient _httpClient;

        public FeaturePolicyConfigTests()
        {
            _server = TestServerBuilder<MvcAttributeWebsite.StartupFeaturePolicyConfig>.CreateTestServer();
            _httpClient = _server.CreateClient();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
            _server.Dispose();
        }

        [Fact]
        public async Task FeaturePolicyConfig_EnabledInConfig_SetsHeaders()
        {
            const string path = "/FeaturePolicyConfig";

            var response = await _httpClient.GetAsync(path);

            Assert.True(response.IsSuccessStatusCode, $"Request failed: {path}");
            var cspHeader = response.Headers.GetValues("Feature-Policy").Single();
            Assert.True(cspHeader.Contains("autoplay *"), path);
        }

        [Fact]
        public async Task FeaturePolicyConfig_SourcesInConfigAndInAttributeWithInheritSources_CombinesSources()
        {
            const string path = "/FeaturePolicyConfig/AddSource";

            var response = await _httpClient.GetAsync(path);

            Assert.True(response.IsSuccessStatusCode, $"Request failed: {path}");
            var cspHeader = response.Headers.GetValues("Feature-Policy").Single();
            Assert.True(cspHeader.Contains("script-src configscripthost attributescripthost;"), path);
        }

        [Fact]
        public async Task FeaturePolicyConfig_SourcesInConfigAndInAttributeWithInheritSourcesDisabled_OverridesSources()
        {
            const string path = "/FeaturePolicyConfig/OverrideSource";

            var response = await _httpClient.GetAsync(path);

            Assert.True(response.IsSuccessStatusCode, $"Request failed: {path}");
            var cspHeader = response.Headers.GetValues("Feature-Policy").Single();
            Assert.True(cspHeader.Contains("script-src attributescripthost;"), path);
        }

        [Fact]
        public async Task FeaturePolicyConfig_DisabledOnAction_NoHeader()
        {
            const string path = "/FeaturePolicyConfig/DisableCsp";

            var response = await _httpClient.GetAsync(path);

            Assert.True(response.IsSuccessStatusCode, $"Request failed: {path}");
            Assert.Empty(response.Headers.Where(h => h.Key.Equals("Feature-Policy")));
        }

        [Fact]
        public async Task FeaturePolicyConfig_ScriptSrcAllowInlineUnsafeEval_OverridesAllowInlineUnsafeEval()
        {
            const string path = "/FeaturePolicyConfig/ScriptSrcAllowInlineUnsafeEval";

            var response = await _httpClient.GetAsync(path);

            Assert.True(response.IsSuccessStatusCode, $"Request failed: {path}");
            Assert.True(response.Headers.Contains("Feature-Policy"), path);
            var cspHeader = response.Headers.GetValues("Feature-Policy").Single();
            Assert.True(cspHeader.Contains("script-src 'unsafe-inline' 'unsafe-eval' configscripthost;"), path);
        }
    }
}