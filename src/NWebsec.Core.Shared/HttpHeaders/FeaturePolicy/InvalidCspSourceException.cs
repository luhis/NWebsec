// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;

namespace NWebsec.Core.Common.HttpHeaders.FeaturePolicy
{
    public class InvalidFeaturePolicySourceException : Exception
    {
        public InvalidFeaturePolicySourceException(string s)
            : base(s)
        {
        }
    }
}