using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSICDOConfig : IEntityTypeConfiguration<AtlasModel.SKRSICDO>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSICDO> builder)
        {
            builder.ToTable("SKRSICDO");
            builder.HasKey(nameof(AtlasModel.SKRSICDO.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSICDO.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSICDO.KOD)).HasColumnName("KOD");
            builder.Property(nameof(AtlasModel.SKRSICDO.TOPOGRAFI)).HasColumnName("TOPOGRAFI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDO.YERLESIMBILGISI)).HasColumnName("YERLESIMBILGISI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDO.HISTOLOJIKOD)).HasColumnName("HISTOLOJIKOD");
            builder.Property(nameof(AtlasModel.SKRSICDO.HISTOLOJIACIKLAMA)).HasColumnName("HISTOLOJIACIKLAMA").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDO.DAVRANISKOD)).HasColumnName("DAVRANISKOD").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDO.DAVRANISKODTANIM)).HasColumnName("DAVRANISKODTANIM").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDO.DAVRANISKODACIKLAMA)).HasColumnName("DAVRANISKODACIKLAMA").HasMaxLength(2000);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}