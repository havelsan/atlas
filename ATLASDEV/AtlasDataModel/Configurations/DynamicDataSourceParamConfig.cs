using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DynamicDataSourceParamConfig : IEntityTypeConfiguration<AtlasModel.DynamicDataSourceParam>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DynamicDataSourceParam> builder)
        {
            builder.ToTable("DYNAMICDATASOURCEPARAM");
            builder.HasKey(nameof(AtlasModel.DynamicDataSourceParam.ObjectId));
            builder.Property(nameof(AtlasModel.DynamicDataSourceParam.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DynamicDataSourceParam.ParamKey)).HasColumnName("PARAMKEY");
            builder.Property(nameof(AtlasModel.DynamicDataSourceParam.DynamicDataSourceRef)).HasColumnName("DYNAMICDATASOURCE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DynamicDataSource).WithOne().HasForeignKey<AtlasModel.DynamicDataSourceParam>(x => x.DynamicDataSourceRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}