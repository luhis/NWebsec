using NWebsec.Core.Common.HttpHeaders.Configuration;

namespace NWebsec.Core.Common.Middleware.Options
{
    public class FeaturePolicyOptions : IFluentFeaturePolicyOptions, IFeaturePolicyConfiguration
    {
        public bool Enabled { get; set; } = true;
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