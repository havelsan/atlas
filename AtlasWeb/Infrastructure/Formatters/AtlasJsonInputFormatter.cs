using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Formatters
{
    public class AtlasJsonInputFormatter : NewtonsoftJsonInputFormatter
    {

        public AtlasJsonInputFormatter(
            ILogger logger,
            JsonSerializerSettings serializerSettings,
            MvcOptions options)
            : base(logger, serializerSettings, ArrayPool<char>.Shared, new DefaultObjectPoolProvider(), options, new MvcNewtonsoftJsonOptions())
        {
           
        }

    }
}
