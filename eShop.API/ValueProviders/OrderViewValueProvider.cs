using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.API.ValueProviders
{
    public class OrderViewValueProvider : BindingSourceValueProvider, IValueProvider
    {
        private readonly Dictionary<string, string> _values;
        private PrefixContainer _prefixContainer;

        public OrderViewValueProvider(BindingSource bindingSource, Dictionary<string, string> values, CultureInfo culture) : base(bindingSource)
        {
            if (bindingSource == null)
            {
                throw new ArgumentNullException(nameof(bindingSource));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            _values = values;
            Culture = culture;
        }

        protected PrefixContainer PrefixContainer
        {
            get
            {
                if (_prefixContainer == null)
                {
                    _prefixContainer = new PrefixContainer(_values.Keys);
                }

                return _prefixContainer;
            }
        }

        public CultureInfo Culture { get; }

        public override bool ContainsPrefix(string prefix)
        {
            return PrefixContainer.ContainsPrefix(prefix);
        }

        public override ValueProviderResult GetValue(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length == 0)
            {
                return ValueProviderResult.None;
            }

            var value = _values[key];

            if (string.IsNullOrEmpty(value))
            {
                return ValueProviderResult.None;
            }
            else
            {
                return new ValueProviderResult(value, Culture);
            }
        }
    }
}
