using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseNursingOrderDetailsConfig : IEntityTypeConfiguration<AtlasModel.BaseNursingOrderDetails>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseNursingOrderDetails> builder)
        {
            builder.ToTable("BASENURSINGORDERDETAILS");
            builder.HasKey(nameof(AtlasModel.BaseNursingOrderDetails.ObjectId));
            builder.Property(nameof(AtlasModel.BaseNursingOrderDetails.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseNursingOrderDetails.Result)).HasColumnName("RESULT").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.BaseNursingOrderDetails.Notes)).HasColumnName("NOTES").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.BaseNursingOrderDetails.Result_Pulse)).HasColumnName("RESULT_PULSE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.BaseNursingOrderDetails.ResultBloodPressure)).HasColumnName("RESULTBLOODPRESSURE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.BaseNursingOrderDetails.Result_SPO2)).HasColumnName("RESULT_SPO2").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.BaseNursingOrderDetails.VitalSignRef)).HasColumnName("VITALSIGN").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.PeriodicOrderDetail).WithOne().HasForeignKey<AtlasModel.PeriodicOrderDetail>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.VitalSign).WithOne().HasForeignKey<AtlasModel.BaseNursingOrderDetails>(x => x.VitalSignRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}