using System;
using System.Linq;
using NWebsec.Core.Common.HttpHeaders.Configuration;
using NWebsec.Core.Common.HttpHeaders.Csp;
using NWebsec.Core.Common.HttpHeaders.FeaturePolicy;

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

        public static T Self<T>(this T directive) where T : class, IFeaturePolicyDirectiveBasicConfiguration
        {
            if (directive == null) throw new ArgumentNullException(nameof(directive));

            directive.SelfSrc = true;
            return directive;
        }

        public static void All<T>(this T directive) where T : class, IFeaturePolicyDirectiveBasicConfiguration
        {
            if (directive == null) throw new ArgumentNullException(nameof(directive));

            directive.All = true;
        }

        public static T CustomSources<T>(this T directive, params string[] sources) where T : class, IFeaturePolicyDirectiveBasicConfiguration
        {
            if (directive == null) throw new ArgumentNullException(nameof(directive));
            if (sources.Length == 0) throw new ArgumentException("You must supply at least one source.", nameof(sources));

            try
            {
                directive.CustomSources = sources
                    .Select(s => CspUriSource.Parse(s).ToString())
                    .ToArray();
            }
            catch (InvalidFeaturePolicySourceException e)
            {
                throw new ArgumentException("Invalid source. Details: " + e.Message, nameof(sources), e);
            }

            return directive;
        }
    }
}