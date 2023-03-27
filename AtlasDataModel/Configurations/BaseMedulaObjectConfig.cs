using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseMedulaObjectConfig : IEntityTypeConfiguration<AtlasModel.BaseMedulaObject>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseMedulaObject> builder)
        {
            builder.ToTable("BASEMEDULAOBJECT");
            builder.HasKey(nameof(AtlasModel.BaseMedulaObject.ObjectId));
            builder.Property(nameof(AtlasModel.BaseMedulaObject.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseMedulaObject.CreationDate)).HasColumnName("CREATIONDATE");
        }
    }
}