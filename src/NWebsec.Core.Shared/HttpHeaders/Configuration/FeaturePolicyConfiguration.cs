namespace NWebsec.Core.Common.HttpHeaders.Configuration
{
    public class FeaturePolicyConfiguration : IFeaturePolicyConfiguration
    {
        public bool Enabled { get; }
        public ICspDirectiveConfiguration AutoPlayDirective { get; }
        public ICspDirectiveConfiguration CameraDirective { get; }
        public ICspDirectiveConfiguration DocumentDomainDirective { get; }
        public ICspDirectiveConfiguration EncryptedMediaDirective { get; }
        public ICspDirectiveConfiguration FullScreenDirective { get; }
        public ICspDirectiveConfiguration GeolocationDirective { get; }
        public ICspDirectiveConfiguration MicrophoneDirective { get; }
        public ICspDirectiveConfiguration MidiDirective { get; }
        public ICspDirectiveConfiguration PaymentDirective { get; }
        public ICspDirectiveConfiguration VrDirective { get; }
    }
}