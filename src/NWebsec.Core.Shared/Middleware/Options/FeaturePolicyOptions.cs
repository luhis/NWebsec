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

        public IFluentFeaturePolicyOptions Camera(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer)
        {
            configurer(CameraDirective);
            return this;
        }

        public IFluentFeaturePolicyOptions DocumentDomain(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer)
        {
            configurer(DocumentDomainDirective);
            return this;
        }

        public IFluentFeaturePolicyOptions EncryptedMedia(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer)
        {
            configurer(EncryptedMediaDirective);
            return this;
        }

        public IFluentFeaturePolicyOptions FullScreen(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer)
        {
            configurer(FullScreenDirective);
            return this;
        }

        public IFluentFeaturePolicyOptions Geolocation(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer)
        {
            configurer(GeolocationDirective);
            return this;
        }

        public IFluentFeaturePolicyOptions Microphone(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer)
        {
            configurer(MicrophoneDirective);
            return this;
        }

        public IFluentFeaturePolicyOptions Midi(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer)
        {
            configurer(MidiDirective);
            return this;
        }

        public IFluentFeaturePolicyOptions Payment(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer)
        {
            configurer(PaymentDirective);
            return this;
        }

        public IFluentFeaturePolicyOptions Vr(Action<IFeaturePolicyDirectiveBasicConfiguration> configurer)
        {
            configurer(VrDirective);
            return this;
        }
    }
}