namespace NWebsec.Core.Common.HttpHeaders.Configuration
{
    public interface IFeaturePolicyConfiguration
    {
        bool Enabled { get; }

        ICspDirectiveConfiguration AutoPlayDirective { get; }

        ICspDirectiveConfiguration CameraDirective { get; }

        ICspDirectiveConfiguration DocumentDomainDirective { get; }

        ICspDirectiveConfiguration EncryptedMediaDirective { get; }

        ICspDirectiveConfiguration FullScreenDirective { get; }

        ICspDirectiveConfiguration GeolocationDirective { get; }

        ICspDirectiveConfiguration MicrophoneDirective { get; }

        ICspDirectiveConfiguration MidiDirective { get; }

        ICspDirectiveConfiguration PaymentDirective { get; }

        ICspDirectiveConfiguration VrDirective { get; }
    }
}