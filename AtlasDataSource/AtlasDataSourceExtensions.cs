using AtlasDataModel;
using AtlasModel;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasDataSource
{
    public static class AtlasDataSourceExtensions
    {
        public static void AddAtlasODataExtensions(this IServiceCollection services)
        {
            services.AddOData();
            services.AddODataQueryFilter();
        }

        public static IEdmModel RegisterEntities()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var items = typeof(AtlasContext).GetProperties().Where(p => p.PropertyType.Name == "DbSet`1").Select(p => new
            {
                name = p.Name,
                type = p.PropertyType.GetGenericArguments().FirstOrDefault()

            }).ToList();

            foreach (var item in items)
            {
                if (item.type.GetProperty("ObjectId") == null)
                {
                    continue;
                }
                EntityTypeConfiguration entityType = builder.AddEntityType(item.type);
                entityType.HasKey(item.type.GetProperty("ObjectId"));

                builder.AddEntitySet(item.name, entityType);
                //builder.AddComplexType(item.type);
            }



            return builder.GetEdmModel();
        }
    }
}
