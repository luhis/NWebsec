using System.Collections.Generic;
using System.ComponentModel;
using NWebsec.Core.Common.Fluent;

namespace NWebsec.Core.Common.HttpHeaders.Configuration
{
    /// <summary>
    ///     Defines the properties required for Feature Policy directive configuration.
    /// </summary>
    public interface IFeaturePolicyDirectiveBasicConfiguration : IFluentInterface
    {
        /// <summary>
        ///     Infrastructure. Not intended to be used by your code directly. An attempt to hide this from Intellisense has been
        ///     made.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Enabled { get; set; }

        /// <summary>
        ///     Infrastructure. Not intended to be used by your code directly. An attempt to hide this from Intellisense has been
        ///     made.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool NoneSrc { get; set; }

        /// <summary>
        ///     Infrastructure. Not intended to be used by your code directly. An attempt to hide this from Intellisense has been
        ///     made.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool SelfSrc { get; set; }

        /// <summary>
        ///     Infrastructure. Not intended to be used by your code directly. An attempt to hide this from Intellisense has been
        ///     made.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<string> CustomSources { get; set; }
    }
}