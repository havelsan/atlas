using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseDrugOrderConfig : IEntityTypeConfiguration<AtlasModel.BaseDrugOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseDrugOrder> builder)
        {
            builder.ToTable("BASEDRUGORDER");
            builder.HasKey(nameof(AtlasModel.BaseDrugOrder.ObjectId));
            builder.Property(nameof(AtlasModel.BaseDrugOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseDrugOrder.Frequency)).HasColumnName("FREQUENCY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.BaseDrugOrder.PlannedStartTime)).HasColumnName("PLANNEDSTARTTIME");
            builder.Property(nameof(AtlasModel.BaseDrugOrder.DoseAmount)).HasColumnName("DOSEAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.BaseDrugOrder.UsageNote)).HasColumnName("USAGENOTE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.BaseDrugOrder.Day)).HasColumnName("DAY");
            builder.Property(nameof(AtlasModel.BaseDrugOrder.SecondaryMasterResourceRef)).HasColumnName("SECONDARYMASTERRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseDrugOrder.FromResourceRef)).HasColumnName("FROMRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseDrugOrder.ProcedureDoctorRef)).HasColumnName("PROCEDUREDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseDrugOrder.MasterResourceRef)).HasColumnName("MASTERRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseDrugOrder.ProcedureSpecialityRef)).HasColumnName("PROCEDURESPECIALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseDrugOrder.HospitalTimeScheduleRef)).HasColumnName("HOSPITALTIMESCHEDULE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubActionMaterial).WithOne().HasForeignKey<AtlasModel.SubActionMaterial>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.SecondaryMasterResource).WithOne().HasForeignKey<AtlasModel.BaseDrugOrder>(x => x.SecondaryMasterResourceRef).IsRequired(false);
            builder.HasOne(t => t.FromResource).WithOne().HasForeignKey<AtlasModel.BaseDrugOrder>(x => x.FromResourceRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDoctor).WithOne().HasForeignKey<AtlasModel.BaseDrugOrder>(x => x.ProcedureDoctorRef).IsRequired(false);
            builder.HasOne(t => t.MasterResource).WithOne().HasForeignKey<AtlasModel.BaseDrugOrder>(x => x.MasterResourceRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}