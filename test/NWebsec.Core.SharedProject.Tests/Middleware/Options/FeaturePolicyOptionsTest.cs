using NWebsec.Core.Common.Middleware.Options;
using Xunit;

namespace NWebsec.Core.SharedProject.Tests.Middleware.Options
{
    public class FeaturePolicyOptionsTest
    {
        private readonly FeaturePolicyOptions _options;

        public FeaturePolicyOptionsTest()
        {
            this._options = new FeaturePolicyOptions();
        }

        [Fact]
        public void AutoPlay_ConfiguresAutoPlay()
        {
            this._options.AutoPlay(config => Assert.Same(this._options.AutoPlayDirective, config));
        }

        [Fact]
        public void Camera_ConfiguresCamera()
        {
            this._options.Camera(config => Assert.Same(this._options.CameraDirective, config));
        }

        [Fact]
        public void DocumentDomain_ConfiguresDocumentDomain()
        {
            this._options.DocumentDomain(config => Assert.Same(this._options.DocumentDomainDirective, config));
        }

        [Fact]
        public void EncryptedMedia_ConfiguresEncryptedMedia()
        {
            this._options.EncryptedMedia(config => Assert.Same(this._options.EncryptedMediaDirective, config));
        }

        [Fact]
        public void FullScreen_ConfiguresImageSources()
        {
            this._options.FullScreen(config => Assert.Same(this._options.FullScreenDirective, config));
        }

        [Fact]
        public void Geolocation_ConfiguresMediaSources()
        {
            this._options.Geolocation(config => Assert.Same(this._options.GeolocationDirective, config));

        }

        [Fact]
        public void Microphone_ConfiguresFrameSources()
        {
            this._options.Microphone(config => Assert.Same(this._options.MicrophoneDirective, config));
        }

        [Fact]
        public void Midi_ConfiguresMidi()
        {
            this._options.Midi(config => Assert.Same(this._options.MidiDirective, config));
        }

        [Fact]
        public void Payment_ConfiguresConnectSources()
        {
            this._options.Payment(config => Assert.Same(this._options.PaymentDirective, config));
        }

        [Fact]
        public void Vr_ConfiguresBaseUris()
        {
            this._options.Vr(config => Assert.Same(this._options.VrDirective, config));
        }
    }
}