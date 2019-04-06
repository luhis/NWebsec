namespace NWebsec.Core.Common.HttpHeaders.Configuration
{
    public class FeaturePolicyConfiguration : IFeaturePolicyConfiguration
    {
        public bool Enabled { get; }
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