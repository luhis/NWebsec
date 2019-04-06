using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NWebsec.AspNetCore.Core.Extensions;
using NWebsec.Core.Common.HttpHeaders;
using NWebsec.Core.Common.HttpHeaders.Configuration;

namespace NWebsec.AspNetCore.Middleware.Middleware
{
    public class FeaturePolicyMiddleware
    {
        private readonly IFeaturePolicyConfiguration _config;
        private readonly HeaderResult _headerResult;
        private readonly RequestDelegate _next;

        public FeaturePolicyMiddleware(RequestDelegate next, IFeaturePolicyConfiguration options)
        {
            this._config = options;
            this._next = next;

            var headerGenerator = new HeaderGenerator();
            _headerResult = headerGenerator.CreateFeaturePolicyResult(_config);
        }

        public async Task Invoke(HttpContext context)
        {
            SetCspHeaders(context);

            if (_next != null)
            {
                await _next(context);
            }

        }

        internal void SetCspHeaders(HttpContext context)
        {
            {
                context.GetNWebsecContext().FeaturePolicy = _config;
            }

            if (_headerResult.Action == HeaderResult.ResponseAction.Set)
            {
                context.Response.Headers[_headerResult.Name] = _headerResult.Value;
            }
        }

    }
}