// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;
using System.Configuration;

namespace NWebsec.Modules.Configuration.FeaturePolicy
{
    public class FeaturePolicySourcesElementCollection<T> : ConfigurationElementCollection where T : FeaturePolicySourceConfigurationElement, new()
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            // todo cna this be simplified?
            return ((FeaturePolicySourceConfigurationElement)element).Source;
        }

        public FeaturePolicySourceConfigurationElement this[int index]
        {
            get => (FeaturePolicySourceConfigurationElement)this.BaseGet(index);
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public void Add(FeaturePolicySourceConfigurationElement element)
        {
            this.BaseAdd(element);
        }

        public void Clear()
        {
            this.BaseClear();
        }

        public Object[] GetAllKeys()
        {
            return this.BaseGetAllKeys();
        }

        public void Remove(FeaturePolicySourceConfigurationElement element)
        {
            this.BaseRemove(element);
        }

        public void Remove(string name)
        {
            this.BaseRemove(name);
        }

        public void RemoveAt(int index)
        {
            this.BaseRemoveAt(index);
        }

        public int IndexOf(FeaturePolicySourceConfigurationElement element)
        {
            return this.BaseIndexOf(element);
        }

        public bool IsRemoved(FeaturePolicySourceConfigurationElement element)
        {
            return this.BaseIsRemoved(element);
        }
    }
}