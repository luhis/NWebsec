using NWebsec.Core.Common.HttpHeaders.Configuration;

namespace NWebsec.Core.Common.Middleware.Options
{
    public class FeaturePolicyOptions : IFluentFeaturePolicyOptions, IFeaturePolicyConfiguration
    {
        public bool Enabled { get; set; } = true;
        public IFeaturePolicyDirectiveBasicConfiguration AutoPlayDirective { get; }
        public IFeaturePolicyDirectiveBasicConfiguration CameraDirective { get; }
        public IFeaturePolicyDirectiveBasicConfiguration DocumentDomainDirective { get; }
        public IFeaturePolicyDirectiveBasicConfiguration EncryptedMediaDirective { get; }
        public IFeaturePolicyDirectiveBasicConfiguration FullScreenDirective { get; }
        public IFeaturePolicyDirectiveBasicConfiguration GeolocationDirective { get; }
        public IFeaturePolicyDirectiveBasicConfiguration MicrophoneDirective { get; }
        public IFeaturePolicyDirectiveBasicConfiguration MidiDirective { get; }
        public IFeaturePolicyDirectiveBasicConfiguration PaymentDirective { get; }
        public IFeaturePolicyDirectiveBasicConfiguration VrDirective { get; }
    }
}