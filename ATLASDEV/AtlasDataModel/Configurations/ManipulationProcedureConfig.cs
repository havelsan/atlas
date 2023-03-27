using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ManipulationProcedureConfig : IEntityTypeConfiguration<AtlasModel.ManipulationProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ManipulationProcedure> builder)
        {
            builder.ToTable("MANIPULATIONPROCEDURE");
            builder.HasKey(nameof(AtlasModel.ManipulationProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.ManipulationProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ManipulationProcedure.Birim)).HasColumnName("BIRIM").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.ManipulationProcedure.Sonuc)).HasColumnName("SONUC").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.ManipulationProcedure.RaporTakipNo)).HasColumnName("RAPORTAKIPNO").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.ManipulationProcedure.Description)).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.ManipulationProcedure.IsResultSeen)).HasColumnName("ISRESULTSEEN");
            builder.Property(nameof(AtlasModel.ManipulationProcedure.ManipulationRequestRef)).HasColumnName("MANIPULATIONREQUEST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ManipulationProcedure.ProcedureDepartmentRef)).HasColumnName("PROCEDUREDEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ManipulationProcedure.SagSolRef)).HasColumnName("SAGSOL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseSurgeryAndManipulationProcedure).WithOne().HasForeignKey<AtlasModel.BaseSurgeryAndManipulationProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ManipulationRequest).WithOne().HasForeignKey<AtlasModel.ManipulationProcedure>(x => x.ManipulationRequestRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDepartment).WithOne().HasForeignKey<AtlasModel.ManipulationProcedure>(x => x.ProcedureDepartmentRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}