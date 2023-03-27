using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LinenTypeConfig : IEntityTypeConfiguration<AtlasModel.LinenType>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LinenType> builder)
        {
            builder.ToTable("LINENTYPE");
            builder.HasKey(nameof(AtlasModel.LinenType.ObjectId));
            builder.Property(nameof(AtlasModel.LinenType.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LinenType.Type)).HasColumnName("TYPE");
            builder.Property(nameof(AtlasModel.LinenType.MaxWashingCount)).HasColumnName("MAXWASHINGCOUNT");
            builder.Property(nameof(AtlasModel.LinenType.IntegrationCode)).HasColumnName("INTEGRATIONCODE");
            builder.Property(nameof(AtlasModel.LinenType.LinenGroupRef)).HasColumnName("LINENGROUP").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.LinenGroup).WithOne().HasForeignKey<AtlasModel.LinenType>(x => x.LinenGroupRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}