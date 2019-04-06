using Microsoft.AspNetCore.Http;
using NWebsec.Core.Common.HttpHeaders;
using NWebsec.Core.Common.HttpHeaders.Configuration;

namespace NWebsec.AspNetCore.Middleware.Middleware
{
    public class FeaturePolicyMiddleware
    {
        private readonly IFeaturePolicyConfiguration _config;
        private readonly HeaderResult _headerResult;
        private readonly RequestDelegate _next;

    }
}