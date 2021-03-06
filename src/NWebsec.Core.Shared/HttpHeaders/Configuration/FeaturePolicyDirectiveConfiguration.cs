using System.Collections.Generic;

namespace NWebsec.Core.Common.HttpHeaders.Configuration
{
    public class FeaturePolicyDirectiveConfiguration : IFeaturePolicyDirectiveBasicConfiguration
    {
        private static readonly string[] EmptySources = new string[0];

        public FeaturePolicyDirectiveConfiguration()
        {
            this.Enabled = true;
            this.CustomSources = EmptySources;
        }

        public bool Enabled { get; set; }
        public bool All { get; set; }
        public bool NoneSrc { get; set; }
        public bool SelfSrc { get; set; }
        public IEnumerable<string> CustomSources { get; set; }
    }
}