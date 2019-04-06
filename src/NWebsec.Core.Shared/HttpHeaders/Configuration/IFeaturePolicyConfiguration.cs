namespace NWebsec.Core.Common.HttpHeaders.Configuration
{
    public interface IFeaturePolicyConfiguration
    {
        bool Enabled { get; }

        IFeaturePolicyDirectiveBasicConfiguration AutoPlayDirective { get; }

        IFeaturePolicyDirectiveBasicConfiguration CameraDirective { get; }

        IFeaturePolicyDirectiveBasicConfiguration DocumentDomainDirective { get; }

        IFeaturePolicyDirectiveBasicConfiguration EncryptedMediaDirective { get; }

        IFeaturePolicyDirectiveBasicConfiguration FullScreenDirective { get; }

        IFeaturePolicyDirectiveBasicConfiguration GeolocationDirective { get; }

        IFeaturePolicyDirectiveBasicConfiguration MicrophoneDirective { get; }

        IFeaturePolicyDirectiveBasicConfiguration MidiDirective { get; }

        IFeaturePolicyDirectiveBasicConfiguration PaymentDirective { get; }

        IFeaturePolicyDirectiveBasicConfiguration VrDirective { get; }
    }
}