using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DPDetailConfig : IEntityTypeConfiguration<AtlasModel.DPDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DPDetail> builder)
        {
            builder.ToTable("DPDETAIL");
            builder.HasKey(nameof(AtlasModel.DPDetail.ObjectId));
            builder.Property(nameof(AtlasModel.DPDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DPDetail.GILCode)).HasColumnName("GILCODE");
            builder.Property(nameof(AtlasModel.DPDetail.GILName)).HasColumnName("GILNAME");
            builder.Property(nameof(AtlasModel.DPDetail.GILPoint)).HasColumnName("GILPOINT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DPDetail.CalcPoint)).HasColumnName("CALCPOINT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DPDetail.IsModified)).HasColumnName("ISMODIFIED");
            builder.Property(nameof(AtlasModel.DPDetail.PerformedDate)).HasColumnName("PERFORMEDDATE");
            builder.Property(nameof(AtlasModel.DPDetail.Type)).HasColumnName("TYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DPDetail.PateintName)).HasColumnName("PATEINTNAME");
            builder.Property(nameof(AtlasModel.DPDetail.PatientUniqueRefno)).HasColumnName("PATIENTUNIQUEREFNO");
            builder.Property(nameof(AtlasModel.DPDetail.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.DPDetail.PatientBirthDate)).HasColumnName("PATIENTBIRTHDATE");
            builder.Property(nameof(AtlasModel.DPDetail.RessectionName)).HasColumnName("RESSECTIONNAME").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.DPDetail.PatientStatus)).HasColumnName("PATIENTSTATUS").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.DPDetail.RuleName)).HasColumnName("RULENAME");
            builder.Property(nameof(AtlasModel.DPDetail.RuleDescription)).HasColumnName("RULEDESCRIPTION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.DPDetail.BeforeModifyPoint)).HasColumnName("BEFOREMODIFYPOINT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DPDetail.DPMasterRef)).HasColumnName("DPMASTER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DPDetail.SubActionProcedureRef)).HasColumnName("SUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DPDetail.SubEpisodeRef)).HasColumnName("SUBEPISODE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DPMaster).WithOne().HasForeignKey<AtlasModel.DPDetail>(x => x.DPMasterRef).IsRequired(true);
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.DPDetail>(x => x.SubActionProcedureRef).IsRequired(true);
            builder.HasOne(t => t.SubEpisode).WithOne().HasForeignKey<AtlasModel.DPDetail>(x => x.SubEpisodeRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}