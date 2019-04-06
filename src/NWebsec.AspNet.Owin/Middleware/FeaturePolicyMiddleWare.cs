// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NWebsec.Core.Common.HttpHeaders;
using NWebsec.Core.Common.HttpHeaders.Configuration;
using NWebsec.Owin.Core;

namespace NWebsec.Owin.Middleware
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class FeaturePolicyMiddleWare
    {
        private readonly IFeaturePolicyConfiguration _config;
        private readonly HeaderResult _headerResult;
        private readonly AppFunc _next;

        public FeaturePolicyMiddleWare(AppFunc next, IFeaturePolicyConfiguration options)
        {
            _next = next;
            _config = options;

            var headerGenerator = new HeaderGenerator();
            _headerResult = headerGenerator.CreateFeaturePolicyResult(_config);
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var env = new OwinEnvironment(environment);

            this.SetFeaturePolicyHeaders(env);

            if (_next != null)
            {
                await _next(environment);
            }

        }

        internal void SetFeaturePolicyHeaders(OwinEnvironment owinEnvironment)
        {
            owinEnvironment.NWebsecContext.FeaturePolicy = _config;
            

            if (_headerResult.Action == HeaderResult.ResponseAction.Set)
            {
                owinEnvironment.ResponseHeaders.SetHeader(_headerResult.Name, _headerResult.Value);
            }
        }

    }
}