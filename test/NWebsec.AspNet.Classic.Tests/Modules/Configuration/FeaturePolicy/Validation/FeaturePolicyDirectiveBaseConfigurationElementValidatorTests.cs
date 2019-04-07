// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System.Configuration;
using NWebsec.Modules.Configuration.FeaturePolicy;
using NWebsec.Modules.Configuration.FeaturePolicy.Validation;
using Xunit;

namespace NWebsec.AspNet.Classic.Tests.Modules.Configuration.FeaturePolicy.Validation
{
    public class FeaturePolicyDirectiveBaseConfigurationElementValidatorTests
    {
        private readonly FeaturePolicyDirectiveBaseConfigurationElementValidator _validator;
        private readonly FeaturePolicyDirectiveBaseConfigurationElement<FeaturePolicySourceConfigurationElement> _configElement;
        private const string ValidSource = "nwebsec.codeplex.com";

        public FeaturePolicyDirectiveBaseConfigurationElementValidatorTests()
        {
            this._validator = new FeaturePolicyDirectiveBaseConfigurationElementValidator();
            this._configElement = new FeaturePolicyDirectiveBaseConfigurationElement<FeaturePolicySourceConfigurationElement>();
        }

        [Fact]
        public void Validate_Self_NoException()
        {
            this._configElement.SelfSrc = true;

            this._validator.Validate(this._configElement);
        }

        [Fact]
        public void Validate_Source_NoException()
        {
            this._configElement.Sources.Add(new FeaturePolicySourceConfigurationElement { Source = ValidSource });

            this._validator.Validate(this._configElement);
        }

        [Fact]
        public void Validate_None_NoException()
        {
            this._configElement.NoneSrc = true;

            this._validator.Validate(this._configElement);
        }

        [Fact]
        public void Validate_NoneWithSource_ThrowsException()
        {
            this._configElement.NoneSrc = true;
            this._configElement.Sources.Add(new FeaturePolicySourceConfigurationElement { Source = ValidSource });

            Assert.Throws<ConfigurationErrorsException>(() => this._validator.Validate(this._configElement));
        }

        [Fact]
        public void Validate_NoneWithSelf_ThrowsException()
        {
            this._configElement.NoneSrc = true;
            this._configElement.SelfSrc = true;

            Assert.Throws<ConfigurationErrorsException>(() => this._validator.Validate(this._configElement));
        }
    }
}
