using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResUserConfig : IEntityTypeConfiguration<AtlasModel.ResUser>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResUser> builder)
        {
            builder.ToTable("RESUSER");
            builder.HasKey(nameof(AtlasModel.ResUser.ObjectId));
            builder.Property(nameof(AtlasModel.ResUser.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResUser.WorkPlace)).HasColumnName("WORKPLACE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ResUser.Work)).HasColumnName("WORK").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ResUser.EmploymentRecordID)).HasColumnName("EMPLOYMENTRECORDID").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ResUser.LogonName)).HasColumnName("LOGONNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ResUser.DateOfPromotion)).HasColumnName("DATEOFPROMOTION");
            builder.Property(nameof(AtlasModel.ResUser.Title)).HasColumnName("TITLE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ResUser.PhoneNumber)).HasColumnName("PHONENUMBER").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.ResUser.SpecialityRegistryNo)).HasColumnName("SPECIALITYREGISTRYNO").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ResUser.DateOfLeave)).HasColumnName("DATEOFLEAVE");
            builder.Property(nameof(AtlasModel.ResUser.UserType)).HasColumnName("USERTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ResUser.Status)).HasColumnName("STATUS");
            builder.Property(nameof(AtlasModel.ResUser.DiplomaRegisterNo)).HasColumnName("DIPLOMAREGISTERNO").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ResUser.DateOfJoin)).HasColumnName("DATEOFJOIN");
            builder.Property(nameof(AtlasModel.ResUser.ExternalID)).HasColumnName("EXTERNALID");
            builder.Property(nameof(AtlasModel.ResUser.DiplomaNo)).HasColumnName("DIPLOMANO").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ResUser.SentToMHRS)).HasColumnName("SENTTOMHRS");
            builder.Property(nameof(AtlasModel.ResUser.StaffOfficer)).HasColumnName("STAFFOFFICER");
            builder.Property(nameof(AtlasModel.ResUser.UsesESignature)).HasColumnName("USESESIGNATURE");
            builder.Property(nameof(AtlasModel.ResUser.ErecetePassword)).HasColumnName("ERECETEPASSWORD").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.ResUser.TakesPerformanceScore)).HasColumnName("TAKESPERFORMANCESCORE");
            builder.Property(nameof(AtlasModel.ResUser.MkysUserName)).HasColumnName("MKYSUSERNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ResUser.MkysPassword)).HasColumnName("MKYSPASSWORD").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ResUser.PreDischargeLimit)).HasColumnName("PREDISCHARGELIMIT");
            builder.Property(nameof(AtlasModel.ResUser.TitleCode)).HasColumnName("TITLECODE");
            builder.Property(nameof(AtlasModel.ResUser.StatusDefinition)).HasColumnName("STATUSDEFINITION");
            builder.Property(nameof(AtlasModel.ResUser.EMail)).HasColumnName("EMAIL").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ResUser.RecordType)).HasColumnName("RECORDTYPE").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ResUser.RecordCompany)).HasColumnName("RECORDCOMPANY").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ResUser.RecordCompanyCode)).HasColumnName("RECORDCOMPANYCODE").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ResUser.RecordDefinition)).HasColumnName("RECORDDEFINITION").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.ResUser.IntegrationId)).HasColumnName("INTEGRATIONID").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ResUser.IntegrationVersion)).HasColumnName("INTEGRATIONVERSION").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ResUser.KPSUserName)).HasColumnName("KPSUSERNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ResUser.KPSPassword)).HasColumnName("KPSPASSWORD").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ResUser.FirstWorkHealthExamDate)).HasColumnName("FIRSTWORKHEALTHEXAMDATE");
            builder.Property(nameof(AtlasModel.ResUser.SecondWorkHealthExamDate)).HasColumnName("SECONDWORKHEALTHEXAMDATE");
            builder.Property(nameof(AtlasModel.ResUser.ThirdWorkHealthExamDate)).HasColumnName("THIRDWORKHEALTHEXAMDATE");
            builder.Property(nameof(AtlasModel.ResUser.FourthWorkHealthExamDate)).HasColumnName("FOURTHWORKHEALTHEXAMDATE");
            builder.Property(nameof(AtlasModel.ResUser.IsClinician)).HasColumnName("ISCLINICIAN");
            builder.Property(nameof(AtlasModel.ResUser.PersonRef)).HasColumnName("PERSON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResUser.RankRef)).HasColumnName("RANK").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResUser.MilitaryClassRef)).HasColumnName("MILITARYCLASS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResUser.UserDigitalSignatureRef)).HasColumnName("USERDIGITALSIGNATURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResUser.ForcesCommandRef)).HasColumnName("FORCESCOMMAND").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResUser.CKYSUserTypeRef)).HasColumnName("CKYSUSERTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResUser.PACountRef)).HasColumnName("PACOUNT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResUser.DoctorQuotaRef)).HasColumnName("DOCTORQUOTA").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.Resource).WithOne().HasForeignKey<AtlasModel.Resource>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Person).WithOne().HasForeignKey<AtlasModel.ResUser>(x => x.PersonRef).IsRequired(false);
            builder.HasOne(t => t.PACount).WithOne().HasForeignKey<AtlasModel.ResUser>(x => x.PACountRef).IsRequired(false);
            builder.HasOne(t => t.DoctorQuota).WithOne().HasForeignKey<AtlasModel.ResUser>(x => x.DoctorQuotaRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}