﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Http;
using NWebsec.Core.Common.HttpHeaders;
using NWebsec.Core.Common.HttpHeaders.Configuration;
using NWebsec.Core.Common.Middleware.Options;

namespace NWebsec.AspNetCore.Middleware.Middleware
{

    public class HpkpMiddleware : MiddlewareBase
    {
        private readonly IHpkpConfiguration _config;
        private readonly HeaderResult _headerResult;

        public HpkpMiddleware(RequestDelegate next, HpkpOptions options, bool reportOnly)
            : base(next)
        {
            _config = options.Config;

            var headerGenerator = new HeaderGenerator();
            _headerResult = headerGenerator.CreateHpkpResult(_config, reportOnly);
        }

        internal override void PreInvokeNext(HttpContext context)
        {

            if (_config.HttpsOnly && !context.Request.IsHttps)
            {
                return;
            }
            
            if (_headerResult.Action == HeaderResult.ResponseAction.Set)
            {
                context.Response.Headers[_headerResult.Name] = _headerResult.Value;
            }
        }
    }
}