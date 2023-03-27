using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugOrderIntroductionConfig : IEntityTypeConfiguration<AtlasModel.DrugOrderIntroduction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugOrderIntroduction> builder)
        {
            builder.ToTable("DRUGORDERINTRODUCTION");
            builder.HasKey(nameof(AtlasModel.DrugOrderIntroduction.ObjectId));
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.IsBarcode)).HasColumnName("ISBARCODE");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.ERecetePassword)).HasColumnName("ERECETEPASSWORD").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.IsRepeated)).HasColumnName("ISREPEATED");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.DrugDescription)).HasColumnName("DRUGDESCRIPTION");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.IsInheldDrug)).HasColumnName("ISINHELDDRUG");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.Frequency)).HasColumnName("FREQUENCY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.RoutineDay)).HasColumnName("ROUTINEDAY").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.RoutineDose)).HasColumnName("ROUTINEDOSE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.Dose)).HasColumnName("DOSE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.Volume)).HasColumnName("VOLUME").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.Unit)).HasColumnName("UNIT").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.UseRoutineValue)).HasColumnName("USEROUTINEVALUE");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.OrderDose)).HasColumnName("ORDERDOSE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.OrderFrequency)).HasColumnName("ORDERFREQUENCY").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.OrderDay)).HasColumnName("ORDERDAY").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.DrugName)).HasColumnName("DRUGNAME").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.DrugObjectID)).HasColumnName("DRUGOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.MaxDose)).HasColumnName("MAXDOSE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.MaxDoseDay)).HasColumnName("MAXDOSEDAY").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.PatientOwnDrug)).HasColumnName("PATIENTOWNDRUG");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.AutoSearch)).HasColumnName("AUTOSEARCH");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.CheckFavoriteDrug)).HasColumnName("CHECKFAVORITEDRUG");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.PlannedStartTime)).HasColumnName("PLANNEDSTARTTIME");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.IsConsultaitonOrder)).HasColumnName("ISCONSULTAITONORDER");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.DrugDescriptionType)).HasColumnName("DRUGDESCRIPTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.IsTemplate)).HasColumnName("ISTEMPLATE");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.TemplateDescription)).HasColumnName("TEMPLATEDESCRIPTION");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.IsImmediate)).HasColumnName("ISIMMEDIATE");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.DrugOrderType)).HasColumnName("DRUGORDERTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.PeriodUnitType)).HasColumnName("PERIODUNITTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.PackageAmount)).HasColumnName("PACKAGEAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.CaseOfNeed)).HasColumnName("CASEOFNEED");
            builder.Property(nameof(AtlasModel.DrugOrderIntroduction.ActiveInPatientPhysicianAppRef)).HasColumnName("ACTIVEINPATIENTPHYSICIANAPP").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ActiveInPatientPhysicianApp).WithOne().HasForeignKey<AtlasModel.DrugOrderIntroduction>(x => x.ActiveInPatientPhysicianAppRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}