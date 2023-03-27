using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChemoRadioCureProtocolConfig : IEntityTypeConfiguration<AtlasModel.ChemoRadioCureProtocol>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChemoRadioCureProtocol> builder)
        {
            builder.ToTable("CHEMORADIOCUREPROTOCOL");
            builder.HasKey(nameof(AtlasModel.ChemoRadioCureProtocol.ObjectId));
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.CureCount)).HasColumnName("CURECOUNT");
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.RepetitiveDayCount)).HasColumnName("REPETITIVEDAYCOUNT");
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.PreCureMinute)).HasColumnName("PRECUREMINUTE");
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.CureTime)).HasColumnName("CURETIME");
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.AfterCureTime)).HasColumnName("AFTERCURETIME");
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.DrugDose)).HasColumnName("DRUGDOSE");
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.SolventDose)).HasColumnName("SOLVENTDOSE");
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.CureDescription)).HasColumnName("CUREDESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.IsRadiotherapyCure)).HasColumnName("ISRADIOTHERAPYCURE");
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.ChemotherapyRadiotherapyRef)).HasColumnName("CHEMOTHERAPYRADIOTHERAPY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.EtkinMaddeRef)).HasColumnName("ETKINMADDE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.RadiotherapyXRayTypeDefRef)).HasColumnName("RADIOTHERAPYXRAYTYPEDEF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.ChemotherapyApplyMethodRef)).HasColumnName("CHEMOTHERAPYAPPLYMETHOD").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocol.ChemotherapyApplySubMethodRef)).HasColumnName("CHEMOTHERAPYAPPLYSUBMETHOD").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.PlannedAction).WithOne().HasForeignKey<AtlasModel.PlannedAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ChemotherapyRadiotherapy).WithOne().HasForeignKey<AtlasModel.ChemoRadioCureProtocol>(x => x.ChemotherapyRadiotherapyRef).IsRequired(false);
            builder.HasOne(t => t.EtkinMadde).WithOne().HasForeignKey<AtlasModel.ChemoRadioCureProtocol>(x => x.EtkinMaddeRef).IsRequired(false);
            builder.HasOne(t => t.RadiotherapyXRayTypeDef).WithOne().HasForeignKey<AtlasModel.ChemoRadioCureProtocol>(x => x.RadiotherapyXRayTypeDefRef).IsRequired(false);
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.ChemoRadioCureProtocol>(x => x.MaterialRef).IsRequired(false);
            builder.HasOne(t => t.ChemotherapyApplyMethod).WithOne().HasForeignKey<AtlasModel.ChemoRadioCureProtocol>(x => x.ChemotherapyApplyMethodRef).IsRequired(false);
            builder.HasOne(t => t.ChemotherapyApplySubMethod).WithOne().HasForeignKey<AtlasModel.ChemoRadioCureProtocol>(x => x.ChemotherapyApplySubMethodRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}