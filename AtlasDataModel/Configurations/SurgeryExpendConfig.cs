using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SurgeryExpendConfig : IEntityTypeConfiguration<AtlasModel.SurgeryExpend>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SurgeryExpend> builder)
        {
            builder.ToTable("SURGERYEXPEND");
            builder.HasKey(nameof(AtlasModel.SurgeryExpend.ObjectId));
            builder.Property(nameof(AtlasModel.SurgeryExpend.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SurgeryExpend.MainSurgeryRef)).HasColumnName("MAINSURGERY").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseTreatmentMaterial).WithOne().HasForeignKey<AtlasModel.BaseTreatmentMaterial>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MainSurgery).WithOne().HasForeignKey<AtlasModel.SurgeryExpend>(x => x.MainSurgeryRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}