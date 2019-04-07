// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;
using System.Configuration;
using System.Linq;

namespace NWebsec.Modules.Configuration.FeaturePolicy.Validation
{
    public class FeaturePolicyDirectiveBaseConfigurationElementValidator : ConfigurationValidatorBase
    {
        public override bool CanValidate(Type type)
        {
            return type == typeof(FeaturePolicyDirectiveBaseConfigurationElement<FeaturePolicySourceConfigurationElement>);
        }

        public override void Validate(object value)
        {
            var element = (FeaturePolicyDirectiveBaseConfigurationElement<FeaturePolicySourceConfigurationElement>)value;
            this.ValidateElement(element);
        }

        internal virtual void ValidateElement<T>(FeaturePolicyDirectiveBaseConfigurationElement<T> element) where T : FeaturePolicySourceConfigurationElement, new()
        {

            if (element.NoneSrc && element.CustomSources.Any())
            {
                throw new ConfigurationErrorsException("Other sources are not allowed when \"None\" is enabled. Disable \"None\" or remove other sources.");
            }

            if (element.NoneSrc && element.SelfSrc)
            {
                throw new ConfigurationErrorsException("Both \"None\" and \"Self\" are enabled. \"None\" cannot be combined with other sources");
            }
        }
    }
}
