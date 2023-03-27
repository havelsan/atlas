using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EpisodeActionSMSInfoConfig : IEntityTypeConfiguration<AtlasModel.EpisodeActionSMSInfo>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EpisodeActionSMSInfo> builder)
        {
            builder.ToTable("EPISODEACTIONSMSINFO");
            builder.HasKey(nameof(AtlasModel.EpisodeActionSMSInfo.ObjectId));
            builder.Property(nameof(AtlasModel.EpisodeActionSMSInfo.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EpisodeActionSMSInfo.ResponsibleUserID)).HasColumnName("RESPONSIBLEUSERID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeActionSMSInfo.DoctorUserID)).HasColumnName("DOCTORUSERID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeActionSMSInfo.ChiefUserID)).HasColumnName("CHIEFUSERID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeActionSMSInfo.EpisodeActionDate)).HasColumnName("EPISODEACTIONDATE");
            builder.Property(nameof(AtlasModel.EpisodeActionSMSInfo.IsActiveFlag)).HasColumnName("ISACTIVEFLAG");
            builder.Property(nameof(AtlasModel.EpisodeActionSMSInfo.CompletedFlag)).HasColumnName("COMPLETEDFLAG");
            builder.Property(nameof(AtlasModel.EpisodeActionSMSInfo.InternalObjectDefName)).HasColumnName("INTERNALOBJECTDEFNAME");
            builder.Property(nameof(AtlasModel.EpisodeActionSMSInfo.SMSNumberForResponsible)).HasColumnName("SMSNUMBERFORRESPONSIBLE");
            builder.Property(nameof(AtlasModel.EpisodeActionSMSInfo.SMSNumberForDoctor)).HasColumnName("SMSNUMBERFORDOCTOR");
            builder.Property(nameof(AtlasModel.EpisodeActionSMSInfo.SMSNumberForChief)).HasColumnName("SMSNUMBERFORCHIEF");
            builder.Property(nameof(AtlasModel.EpisodeActionSMSInfo.EpisodeActionRef)).HasColumnName("EPISODEACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeActionSMSInfo>(x => x.EpisodeActionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}