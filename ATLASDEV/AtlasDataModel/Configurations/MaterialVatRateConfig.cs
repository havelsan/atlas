using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MaterialVatRateConfig : IEntityTypeConfiguration<AtlasModel.MaterialVatRate>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MaterialVatRate> builder)
        {
            builder.ToTable("MATERIALVATRATE");
            builder.HasKey(nameof(AtlasModel.MaterialVatRate.ObjectId));
            builder.Property(nameof(AtlasModel.MaterialVatRate.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MaterialVatRate.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.MaterialVatRate.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.MaterialVatRate.VatRate)).HasColumnName("VATRATE");
            builder.Property(nameof(AtlasModel.MaterialVatRate.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.MaterialVatRate>(x => x.MaterialRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}