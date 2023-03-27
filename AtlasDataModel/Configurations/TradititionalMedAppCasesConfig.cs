using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TradititionalMedAppCasesConfig : IEntityTypeConfiguration<AtlasModel.TradititionalMedAppCases>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TradititionalMedAppCases> builder)
        {
            builder.ToTable("TRADITITIONALMEDAPPCASES");
            builder.HasKey(nameof(AtlasModel.TradititionalMedAppCases.ObjectId));
            builder.Property(nameof(AtlasModel.TradititionalMedAppCases.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.TradititionalMedAppCases.SKRSGetatAppliedCasesRef)).HasColumnName("SKRSGETATAPPLIEDCASES").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.TradititionalMedAppCases.TraditionalMedicineRef)).HasColumnName("TRADITIONALMEDICINE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.TraditionalMedicine).WithOne().HasForeignKey<AtlasModel.TradititionalMedAppCases>(x => x.TraditionalMedicineRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}