using System;
using NWebsec.Core.Common.Fluent;
using NWebsec.Core.Common.HttpHeaders.Configuration;

namespace NWebsec.Core.Common.Middleware.Options
{
    /// <summary>
    /// Fluent interface to configure options for Feature-Policy.
    /// </summary>
    public interface IFluentFeaturePolicyOptions : IFluentInterface
    {
        IFluentFeaturePolicyOptions AutoPlay(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer);

    }
}