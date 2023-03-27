using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TaburcuKoduConfig : IEntityTypeConfiguration<AtlasModel.TaburcuKodu>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TaburcuKodu> builder)
        {
            builder.ToTable("TABURCUKODU");
            builder.HasKey(nameof(AtlasModel.TaburcuKodu.ObjectId));
            builder.Property(nameof(AtlasModel.TaburcuKodu.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.TaburcuKodu.taburcuKodu)).HasColumnName("TABURCUKODU");
            builder.Property(nameof(AtlasModel.TaburcuKodu.taburcuKoduAdi)).HasColumnName("TABURCUKODUADI");
            builder.HasOne(t => t.BaseMedulaDefinition).WithOne().HasForeignKey<AtlasModel.BaseMedulaDefinition>(p => p.ObjectId);
        }
    }
}