using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PlannedActionConfig : IEntityTypeConfiguration<AtlasModel.PlannedAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PlannedAction> builder)
        {
            builder.ToTable("PLANNEDACTION");
            builder.HasKey(nameof(AtlasModel.PlannedAction.ObjectId));
            builder.Property(nameof(AtlasModel.PlannedAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PlannedAction.DoctorReturnDescription)).HasColumnName("DOCTORRETURNDESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PlannedAction.AbortRequestDescription)).HasColumnName("ABORTREQUESTDESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PlannedAction.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.PlannedAction.ProcedureObjectRef)).HasColumnName("PROCEDUREOBJECT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ProcedureObject).WithOne().HasForeignKey<AtlasModel.PlannedAction>(x => x.ProcedureObjectRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}