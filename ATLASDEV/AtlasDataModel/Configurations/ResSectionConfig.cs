using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResSectionConfig : IEntityTypeConfiguration<AtlasModel.ResSection>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResSection> builder)
        {
            builder.ToTable("RESSECTION");
            builder.HasKey(nameof(AtlasModel.ResSection.ObjectId));
            builder.Property(nameof(AtlasModel.ResSection.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResSection.AppointmentLimit)).HasColumnName("APPOINTMENTLIMIT");
            builder.Property(nameof(AtlasModel.ResSection.ActionCancelledTime)).HasColumnName("ACTIONCANCELLEDTIME");
            builder.Property(nameof(AtlasModel.ResSection.EnabledType)).HasColumnName("ENABLEDTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ResSection.AprilQuota)).HasColumnName("APRILQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.AugustQuota)).HasColumnName("AUGUSTQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.JuneQuata)).HasColumnName("JUNEQUATA");
            builder.Property(nameof(AtlasModel.ResSection.LastQuotaDate)).HasColumnName("LASTQUOTADATE");
            builder.Property(nameof(AtlasModel.ResSection.NovemberQuota)).HasColumnName("NOVEMBERQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.OctoberQuota)).HasColumnName("OCTOBERQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.SeptemberQuota)).HasColumnName("SEPTEMBERQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.WeeklyQuota)).HasColumnName("WEEKLYQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.DontShowHCDepartmentReport)).HasColumnName("DONTSHOWHCDEPARTMENTREPORT");
            builder.Property(nameof(AtlasModel.ResSection.ContactPhone)).HasColumnName("CONTACTPHONE");
            builder.Property(nameof(AtlasModel.ResSection.IsToBeConsultation)).HasColumnName("ISTOBECONSULTATION");
            builder.Property(nameof(AtlasModel.ResSection.IsEtiquettePrinted)).HasColumnName("ISETIQUETTEPRINTED");
            builder.Property(nameof(AtlasModel.ResSection.EtiquetteCount)).HasColumnName("ETIQUETTECOUNT");
            builder.Property(nameof(AtlasModel.ResSection.PCSInUse)).HasColumnName("PCSINUSE");
            builder.Property(nameof(AtlasModel.ResSection.MarchQuota)).HasColumnName("MARCHQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.DailyQuota)).HasColumnName("DAILYQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.DecemberQuota)).HasColumnName("DECEMBERQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.FebruaryQuota)).HasColumnName("FEBRUARYQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.JanuaryQuota)).HasColumnName("JANUARYQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.JulyQuota)).HasColumnName("JULYQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.MayQuota)).HasColumnName("MAYQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.MonthlyQuota)).HasColumnName("MONTHLYQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.NotChargeHCExaminationPrice)).HasColumnName("NOTCHARGEHCEXAMINATIONPRICE");
            builder.Property(nameof(AtlasModel.ResSection.ContactAddress)).HasColumnName("CONTACTADDRESS");
            builder.Property(nameof(AtlasModel.ResSection.IgnoreQuotaControl)).HasColumnName("IGNOREQUOTACONTROL");
            builder.Property(nameof(AtlasModel.ResSection.InpatientQuota)).HasColumnName("INPATIENTQUOTA");
            builder.Property(nameof(AtlasModel.ResSection.HimssRequired)).HasColumnName("HIMSSREQUIRED");
            builder.Property(nameof(AtlasModel.ResSection.IsmedicalWaste)).HasColumnName("ISMEDICALWASTE");
            builder.Property(nameof(AtlasModel.ResSection.ResSectionType)).HasColumnName("RESSECTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ResSection.ResourceStartTime)).HasColumnName("RESOURCESTARTTIME");
            builder.Property(nameof(AtlasModel.ResSection.ResourceEndTime)).HasColumnName("RESOURCEENDTIME");
            builder.Property(nameof(AtlasModel.ResSection.OptionalDelayMinute)).HasColumnName("OPTIONALDELAYMINUTE");
            builder.Property(nameof(AtlasModel.ResSection.SexException)).HasColumnName("SEXEXCEPTION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ResSection.MaxAge)).HasColumnName("MAXAGE");
            builder.Property(nameof(AtlasModel.ResSection.DontTakeGSSProvision)).HasColumnName("DONTTAKEGSSPROVISION");
            builder.Property(nameof(AtlasModel.ResSection.MinAge)).HasColumnName("MINAGE");
            builder.Property(nameof(AtlasModel.ResSection.SaglikNetKlinikleriRef)).HasColumnName("SAGLIKNETKLINIKLERI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResSection.TedaviTipiRef)).HasColumnName("TEDAVITIPI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResSection.TedaviTuruRef)).HasColumnName("TEDAVITURU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResSection.TakipTipiRef)).HasColumnName("TAKIPTIPI").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.Resource).WithOne().HasForeignKey<AtlasModel.Resource>(p => p.ObjectId);
        }
    }
}