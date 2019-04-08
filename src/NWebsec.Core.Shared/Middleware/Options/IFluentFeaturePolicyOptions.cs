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

        IFluentFeaturePolicyOptions Camera(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer);
        IFluentFeaturePolicyOptions DocumentDomain(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer);
        IFluentFeaturePolicyOptions EncryptedMedia(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer);
        IFluentFeaturePolicyOptions FullScreen(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer);
        IFluentFeaturePolicyOptions Geolocation(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer);
        IFluentFeaturePolicyOptions Microphone(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer);
        IFluentFeaturePolicyOptions Midi(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer);
        IFluentFeaturePolicyOptions Payment(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer);
        IFluentFeaturePolicyOptions Vr(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer);
    }
}