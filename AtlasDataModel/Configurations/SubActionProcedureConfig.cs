using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubActionProcedureConfig : IEntityTypeConfiguration<AtlasModel.SubActionProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubActionProcedure> builder)
        {
            builder.ToTable("SUBACTIONPROCEDURE");
            builder.HasKey(nameof(AtlasModel.SubActionProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.SubActionProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SubActionProcedure.ID)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.SubActionProcedure.Eligible)).HasColumnName("ELIGIBLE");
            builder.Property(nameof(AtlasModel.SubActionProcedure.ReasonOfCancel)).HasColumnName("REASONOFCANCEL").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.SubActionProcedure.WorkListDate)).HasColumnName("WORKLISTDATE");
            builder.Property(nameof(AtlasModel.SubActionProcedure.PricingDate)).HasColumnName("PRICINGDATE");
            builder.Property(nameof(AtlasModel.SubActionProcedure.Amount)).HasColumnName("AMOUNT");
            builder.Property(nameof(AtlasModel.SubActionProcedure.ActionDate)).HasColumnName("ACTIONDATE");
            builder.Property(nameof(AtlasModel.SubActionProcedure.Emergency)).HasColumnName("EMERGENCY");
            builder.Property(nameof(AtlasModel.SubActionProcedure.Active)).HasColumnName("ACTIVE");
            builder.Property(nameof(AtlasModel.SubActionProcedure.OlapDate)).HasColumnName("OLAPDATE");
            builder.Property(nameof(AtlasModel.SubActionProcedure.OlapLastUpdate)).HasColumnName("OLAPLASTUPDATE");
            builder.Property(nameof(AtlasModel.SubActionProcedure.AccountOperationDone)).HasColumnName("ACCOUNTOPERATIONDONE");
            builder.Property(nameof(AtlasModel.SubActionProcedure.AccTrxsMultipliedByAmount)).HasColumnName("ACCTRXSMULTIPLIEDBYAMOUNT");
            builder.Property(nameof(AtlasModel.SubActionProcedure.PatientPay)).HasColumnName("PATIENTPAY");
            builder.Property(nameof(AtlasModel.SubActionProcedure.ExtraDescription)).HasColumnName("EXTRADESCRIPTION").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.SubActionProcedure.SUTRuleStatus)).HasColumnName("SUTRULESTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SubActionProcedure.DiscountPercent)).HasColumnName("DISCOUNTPERCENT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.SubActionProcedure.PerformedDate)).HasColumnName("PERFORMEDDATE");
            builder.Property(nameof(AtlasModel.SubActionProcedure.CreationDate)).HasColumnName("CREATIONDATE");
            builder.Property(nameof(AtlasModel.SubActionProcedure.IsOldAction)).HasColumnName("ISOLDACTION");
            builder.Property(nameof(AtlasModel.SubActionProcedure.MedulaReportNo)).HasColumnName("MEDULAREPORTNO");
            builder.Property(nameof(AtlasModel.SubActionProcedure.RightLeftInformation)).HasColumnName("RIGHTLEFTINFORMATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SubActionProcedure.EpisodeRef)).HasColumnName("EPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionProcedure.ProcedureSpecialityRef)).HasColumnName("PROCEDURESPECIALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionProcedure.EpisodeActionRef)).HasColumnName("EPISODEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionProcedure.PackageDefinitionRef)).HasColumnName("PACKAGEDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionProcedure.MasterSubActionProcedureRef)).HasColumnName("MASTERSUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionProcedure.MasterPackgSubActionProcedureRef)).HasColumnName("MASTERPACKGSUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionProcedure.MedulaHastaKabulRef)).HasColumnName("MEDULAHASTAKABUL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionProcedure.SubEpisodeRef)).HasColumnName("SUBEPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionProcedure.ProcedureObjectRef)).HasColumnName("PROCEDUREOBJECT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionProcedure.ProcedureDoctorRef)).HasColumnName("PROCEDUREDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionProcedure.ProcedureByUserRef)).HasColumnName("PROCEDUREBYUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionProcedure.RequestedByUserRef)).HasColumnName("REQUESTEDBYUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionProcedure.ReasonForRepetitionRef)).HasColumnName("REASONFORREPETITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Episode).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(x => x.EpisodeRef).IsRequired(false);
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(x => x.EpisodeActionRef).IsRequired(true);
            builder.HasOne(t => t.MasterSubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(x => x.MasterSubActionProcedureRef).IsRequired(false);
            builder.HasOne(t => t.MasterPackgSubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(x => x.MasterPackgSubActionProcedureRef).IsRequired(false);
            builder.HasOne(t => t.SubEpisode).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(x => x.SubEpisodeRef).IsRequired(true);
            builder.HasOne(t => t.ProcedureObject).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(x => x.ProcedureObjectRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDoctor).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(x => x.ProcedureDoctorRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureByUser).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(x => x.ProcedureByUserRef).IsRequired(false);
            builder.HasOne(t => t.RequestedByUser).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(x => x.RequestedByUserRef).IsRequired(false);
            builder.HasOne(t => t.ReasonForRepetition).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(x => x.ReasonForRepetitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}