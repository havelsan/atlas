using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubactionProcedureSMSInfoConfig : IEntityTypeConfiguration<AtlasModel.SubactionProcedureSMSInfo>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubactionProcedureSMSInfo> builder)
        {
            builder.ToTable("SUBACTIONPROCEDURESMSINFO");
            builder.HasKey(nameof(AtlasModel.SubactionProcedureSMSInfo.ObjectId));
            builder.Property(nameof(AtlasModel.SubactionProcedureSMSInfo.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SubactionProcedureSMSInfo.ChiefUserID)).HasColumnName("CHIEFUSERID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubactionProcedureSMSInfo.CompletedFlag)).HasColumnName("COMPLETEDFLAG");
            builder.Property(nameof(AtlasModel.SubactionProcedureSMSInfo.DoctorUserID)).HasColumnName("DOCTORUSERID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubactionProcedureSMSInfo.ProcedureDate)).HasColumnName("PROCEDUREDATE");
            builder.Property(nameof(AtlasModel.SubactionProcedureSMSInfo.InternalObjectDefNAme)).HasColumnName("INTERNALOBJECTDEFNAME").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SubactionProcedureSMSInfo.IsActiveFlag)).HasColumnName("ISACTIVEFLAG");
            builder.Property(nameof(AtlasModel.SubactionProcedureSMSInfo.ResponsibleUserID)).HasColumnName("RESPONSIBLEUSERID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubactionProcedureSMSInfo.SMSNumberForChief)).HasColumnName("SMSNUMBERFORCHIEF");
            builder.Property(nameof(AtlasModel.SubactionProcedureSMSInfo.SMSNumberForDoctor)).HasColumnName("SMSNUMBERFORDOCTOR");
            builder.Property(nameof(AtlasModel.SubactionProcedureSMSInfo.SMSNumberForResponsible)).HasColumnName("SMSNUMBERFORRESPONSIBLE");
            builder.Property(nameof(AtlasModel.SubactionProcedureSMSInfo.SubActionProcedureRef)).HasColumnName("SUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubactionProcedureSMSInfo>(x => x.SubActionProcedureRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}