using System;
using NWebsec.Core.Common.HttpHeaders.Configuration;

namespace NWebsec.Core.Common.Middleware.Options
{
    public class FeaturePolicyOptions : IFluentFeaturePolicyOptions, IFeaturePolicyConfiguration
    {
        public bool Enabled { get; private set; } = true;
        public IFeaturePolicyDirectiveBasicConfiguration AutoPlayDirective { get; private set; } = new FeaturePolicyDirectiveConfiguration();
        public IFeaturePolicyDirectiveBasicConfiguration CameraDirective { get; private set; } = new FeaturePolicyDirectiveConfiguration();
        public IFeaturePolicyDirectiveBasicConfiguration DocumentDomainDirective { get; private set; } = new FeaturePolicyDirectiveConfiguration();
        public IFeaturePolicyDirectiveBasicConfiguration EncryptedMediaDirective { get; private set; } = new FeaturePolicyDirectiveConfiguration();
        public IFeaturePolicyDirectiveBasicConfiguration FullScreenDirective { get; private set; } = new FeaturePolicyDirectiveConfiguration();
        public IFeaturePolicyDirectiveBasicConfiguration GeolocationDirective { get; private set; } = new FeaturePolicyDirectiveConfiguration();
        public IFeaturePolicyDirectiveBasicConfiguration MicrophoneDirective { get; private set; } = new FeaturePolicyDirectiveConfiguration();
        public IFeaturePolicyDirectiveBasicConfiguration MidiDirective { get; private set; } = new FeaturePolicyDirectiveConfiguration();
        public IFeaturePolicyDirectiveBasicConfiguration PaymentDirective { get; private set; } = new FeaturePolicyDirectiveConfiguration();
        public IFeaturePolicyDirectiveBasicConfiguration VrDirective { get; private set; } = new FeaturePolicyDirectiveConfiguration();

        public IFluentFeaturePolicyOptions AutoPlay(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer)
        {
            configurer(AutoPlayDirective);
            return this;
        }
    }
}