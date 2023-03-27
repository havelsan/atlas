using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugOrderConfig : IEntityTypeConfiguration<AtlasModel.DrugOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugOrder> builder)
        {
            builder.ToTable("DRUGORDER");
            builder.HasKey(nameof(AtlasModel.DrugOrder.ObjectId));
            builder.Property(nameof(AtlasModel.DrugOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugOrder.SelectedMaterial)).HasColumnName("SELECTEDMATERIAL");
            builder.Property(nameof(AtlasModel.DrugOrder.BarcodeLevel)).HasColumnName("BARCODELEVEL").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DrugOrder.Type)).HasColumnName("TYPE").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.DrugOrder.PatientOwnDrug)).HasColumnName("PATIENTOWNDRUG");
            builder.Property(nameof(AtlasModel.DrugOrder.Description)).HasColumnName("DESCRIPTION");
            builder.Property(nameof(AtlasModel.DrugOrder.DescriptionType)).HasColumnName("DESCRIPTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugOrder.DrugUsageType)).HasColumnName("DRUGUSAGETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugOrder.IsImmediate)).HasColumnName("ISIMMEDIATE");
            builder.Property(nameof(AtlasModel.DrugOrder.DrugOrderType)).HasColumnName("DRUGORDERTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugOrder.CaseOfNeed)).HasColumnName("CASEOFNEED");
            builder.Property(nameof(AtlasModel.DrugOrder.ParentDrugOrder)).HasColumnName("PARENTDRUGORDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrder.OutOfTreatment)).HasColumnName("OUTOFTREATMENT");
            builder.Property(nameof(AtlasModel.DrugOrder.EHUCancelReason)).HasColumnName("EHUCANCELREASON").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.DrugOrder.IsUpgraded)).HasColumnName("ISUPGRADED");
            builder.Property(nameof(AtlasModel.DrugOrder.OldHospitalTimeScheduleID)).HasColumnName("OLDHOSPITALTIMESCHEDULEID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrder.NursingApplicationRef)).HasColumnName("NURSINGAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrder.InPatientPhysicianApplicationRef)).HasColumnName("INPATIENTPHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrder.MaterialBarcodeLevelRef)).HasColumnName("MATERIALBARCODELEVEL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrder.MagistralPreparationActionRef)).HasColumnName("MAGISTRALPREPARATIONACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrder.PhysicianOrderedDrugRef)).HasColumnName("PHYSICIANORDEREDDRUG").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseDrugOrder).WithOne().HasForeignKey<AtlasModel.BaseDrugOrder>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.NursingApplication).WithOne().HasForeignKey<AtlasModel.DrugOrder>(x => x.NursingApplicationRef).IsRequired(false);
            builder.HasOne(t => t.InPatientPhysicianApplication).WithOne().HasForeignKey<AtlasModel.DrugOrder>(x => x.InPatientPhysicianApplicationRef).IsRequired(false);
            builder.HasOne(t => t.PhysicianOrderedDrug).WithOne().HasForeignKey<AtlasModel.DrugOrder>(x => x.PhysicianOrderedDrugRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}