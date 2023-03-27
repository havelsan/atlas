using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TeshisEtkinMaddeGridConfig : IEntityTypeConfiguration<AtlasModel.TeshisEtkinMaddeGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TeshisEtkinMaddeGrid> builder)
        {
            builder.ToTable("TESHISETKINMADDEGRID");
            builder.HasKey(nameof(AtlasModel.TeshisEtkinMaddeGrid.ObjectId));
            builder.Property(nameof(AtlasModel.TeshisEtkinMaddeGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.TeshisEtkinMaddeGrid.TeshisRef)).HasColumnName("TESHIS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TeshisEtkinMaddeGrid.EtkinMaddeRef)).HasColumnName("ETKINMADDE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.EtkinMadde).WithOne().HasForeignKey<AtlasModel.TeshisEtkinMaddeGrid>(x => x.EtkinMaddeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}