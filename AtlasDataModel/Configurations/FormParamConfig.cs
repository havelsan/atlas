using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class FormParamConfig : IEntityTypeConfiguration<AtlasModel.FormParam>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.FormParam> builder)
        {
            builder.ToTable("FORMPARAM");
            builder.HasKey(nameof(AtlasModel.FormParam.ObjectId));
            builder.Property(nameof(AtlasModel.FormParam.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.FormParam.IsFilter)).HasColumnName("ISFILTER");
            builder.Property(nameof(AtlasModel.FormParam.IsRequired)).HasColumnName("ISREQUIRED");
            builder.Property(nameof(AtlasModel.FormParam.ParamKey)).HasColumnName("PARAMKEY");
        }
    }
}