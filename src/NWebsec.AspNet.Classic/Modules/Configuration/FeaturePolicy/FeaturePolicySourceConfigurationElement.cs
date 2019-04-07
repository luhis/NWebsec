// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System.Configuration;
using NWebsec.Modules.Configuration.Csp.Validation;

namespace NWebsec.Modules.Configuration.FeaturePolicy
{
    public class FeaturePolicySourceConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("source", IsKey = true, IsRequired = true)]
        [CspSourceValidator]
        public virtual string Source
        {

            get => (string) this["source"];
            set => this["source"] = value;
        }
    }
}
