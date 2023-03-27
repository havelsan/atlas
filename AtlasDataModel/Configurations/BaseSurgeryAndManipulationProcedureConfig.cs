using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseSurgeryAndManipulationProcedureConfig : IEntityTypeConfiguration<AtlasModel.BaseSurgeryAndManipulationProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseSurgeryAndManipulationProcedure> builder)
        {
            builder.ToTable("BASESURGEMANIPULPROCEDURE");
            builder.HasKey(nameof(AtlasModel.BaseSurgeryAndManipulationProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.BaseSurgeryAndManipulationProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseSurgeryAndManipulationProcedure.SutPoint)).HasColumnName("SUTPOINT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.BaseSurgeryAndManipulationProcedure.AnesteziDoktorRef)).HasColumnName("ANESTEZIDOKTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseSurgeryAndManipulationProcedure.AyniFarkliKesiRef)).HasColumnName("AYNIFARKLIKESI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseSurgeryAndManipulationProcedure.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseSurgeryAndManipulationProcedure.ProcedureDoctor2Ref)).HasColumnName("PROCEDUREDOCTOR2").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseSurgeryAndManipulationProcedure.EuroScoreOfProcedureRef)).HasColumnName("EUROSCOREOFPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.AnesteziDoktor).WithOne().HasForeignKey<AtlasModel.BaseSurgeryAndManipulationProcedure>(x => x.AnesteziDoktorRef).IsRequired(false);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.BaseSurgeryAndManipulationProcedure>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDoctor2).WithOne().HasForeignKey<AtlasModel.BaseSurgeryAndManipulationProcedure>(x => x.ProcedureDoctor2Ref).IsRequired(false);
            #endregion Parent Relations
        }
    }
}