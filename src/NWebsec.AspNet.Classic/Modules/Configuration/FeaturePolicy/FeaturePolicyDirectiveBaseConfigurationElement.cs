// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using NWebsec.Core.Common.HttpHeaders.Configuration;
using NWebsec.Core.Common.HttpHeaders.Csp;

namespace NWebsec.Modules.Configuration.FeaturePolicy
{
    public class FeaturePolicyDirectiveBaseConfigurationElement<T> : ConfigurationElement, IFeaturePolicyDirectiveBasicConfiguration where T : FeaturePolicySourceConfigurationElement, new()
    {
        private string[] _customSources;

        public bool Enabled { get; set; }
        public bool All { get; set; }
        public bool NoneSrc { get; set; }
        public bool SelfSrc { get; set; }
        public IEnumerable<string> CustomSources
        {
            get
            {
                if (_customSources == null)
                {
                    _customSources = Sources
                        .Cast<T>()
                        .Select(s =>  CspUriSource.Parse(s.Source).ToString())
                        .ToArray();
                }
                return _customSources;
            }
            set => throw new NotImplementedException();
        }

        [ConfigurationProperty("", IsRequired = false, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(FeaturePolicySourcesElementCollection<>), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        public FeaturePolicySourcesElementCollection<T> Sources
        {
            get => (FeaturePolicySourcesElementCollection<T>)base[""];
        }
    }
}
