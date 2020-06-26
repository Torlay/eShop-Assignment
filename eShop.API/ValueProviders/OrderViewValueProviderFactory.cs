using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.API.ValueProviders
{
    public class OrderViewValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            
            var result = context.ActionContext.HttpContext.Request.BodyReader.ReadAsync();
            string newOrder = DecodeBody(result.Result.Buffer);

            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("newOrder", newOrder);

            if(d.Count > 0)
            {
                var valueProvider = new OrderViewValueProvider(BindingSource.ModelBinding, d, CultureInfo.InvariantCulture);
                
                context.ValueProviders.Add(valueProvider);
            }

            return Task.CompletedTask;

        }

        public string DecodeBody(System.Buffers.ReadOnlySequence<byte> bytes)
        {
            var decoder = Encoding.Default.GetDecoder();
            var sb = new StringBuilder();
            var processed = 0L;
            var total = bytes.Length;
            foreach (var i in bytes)
            {
                processed += i.Length;
                var isLast = processed == total;
                var span = i.Span;
                var charCount = decoder.GetCharCount(span, isLast);
                Span<char> buffer = stackalloc char[charCount];
                decoder.GetChars(span, buffer, isLast);
                sb.Append(buffer);
            }

            return sb.ToString();
        }
    }
}
