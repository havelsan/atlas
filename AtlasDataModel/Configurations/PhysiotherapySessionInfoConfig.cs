using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PhysiotherapySessionInfoConfig : IEntityTypeConfiguration<AtlasModel.PhysiotherapySessionInfo>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PhysiotherapySessionInfo> builder)
        {
            builder.ToTable("PHYSIOTHERAPYSESSIONINFO");
            builder.HasKey(nameof(AtlasModel.PhysiotherapySessionInfo.ObjectId));
            builder.Property(nameof(AtlasModel.PhysiotherapySessionInfo.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PhysiotherapySessionInfo.PlannedDate)).HasColumnName("PLANNEDDATE");
            builder.Property(nameof(AtlasModel.PhysiotherapySessionInfo.PhysiotherapyRequestRef)).HasColumnName("PHYSIOTHERAPYREQUEST").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.PhysiotherapyRequest).WithOne().HasForeignKey<AtlasModel.PhysiotherapySessionInfo>(x => x.PhysiotherapyRequestRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}