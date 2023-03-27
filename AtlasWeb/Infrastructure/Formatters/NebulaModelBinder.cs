using Infrastructure.Converters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Formatters
{
    public class NebulaModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.IsComplexType && !context.Metadata.IsCollectionType)
            {
                return new NebulaModelBinder();
            }

            return null;
        }
    }

    public class NebulaModelBinder : IModelBinder
    {
        private readonly static CurrencyConverter CustomCurrencyConverter = new CurrencyConverter();
        private readonly static BigCurrencyConverter CustomBigCurrencyConverter = new BigCurrencyConverter();
        private readonly static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            , TypeNameHandling = TypeNameHandling.All, MetadataPropertyHandling = MetadataPropertyHandling.Default
            , Converters = new JsonConverter[]{CustomCurrencyConverter, CustomBigCurrencyConverter}, };
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            MemoryTraceWriter traceWriter = new MemoryTraceWriter();
            try
            {
                var context = bindingContext.HttpContext;
                var buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];
                await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
                var json = Encoding.UTF8.GetString(buffer);
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    traceWriter.LevelFilter = System.Diagnostics.TraceLevel.Verbose;
                    JsonSerializerSettings settings = JsonSerializerSettings;
                    settings.TraceWriter = traceWriter;
                }

                object result = JsonConvert.DeserializeObject(json, bindingContext.ModelType, JsonSerializerSettings);
                bindingContext.Result = ModelBindingResult.Success(result);
            }
            catch
            {
                var traceResult = traceWriter.ToString();
                throw;
            }
        //  return Task.CompletedTask;
        }
    }
}