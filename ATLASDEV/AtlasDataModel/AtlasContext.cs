using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using Microsoft.EntityFrameworkCore.Proxies.Internal;

namespace AtlasDataModel
{
    public partial class AtlasContext
    {
        private readonly DbContextOptions<AtlasContext> _options;

        public AtlasContext(DbContextOptions<AtlasContext> options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var guidToStringConverter = new GuidToStringConverter();
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(Guid) || property.ClrType == typeof(Guid?))
                        property.SetValueConverter(guidToStringConverter);
                }
            }

            this.ApplyEntityConfigurations(modelBuilder);
            //this.ApplyEntityConfigurationsForEnterprise(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
