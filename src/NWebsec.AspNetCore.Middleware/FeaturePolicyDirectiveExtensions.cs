using System;
using NWebsec.Core.Common.HttpHeaders.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    public static class FeaturePolicyDirectiveExtensions
    {
        public static void None<T>(this T directive) where T : class, IFeaturePolicyDirectiveBasicConfiguration
        {
            if (directive == null) throw new ArgumentNullException(nameof(directive));

            directive.NoneSrc = true;
        }
    }
}