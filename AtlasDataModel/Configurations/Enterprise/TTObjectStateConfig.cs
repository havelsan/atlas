using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTObjectStateConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTObjectState>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTObjectState> builder)
        {
            builder.Property(t => t.StateDefId).HasColumnName("STATEDEFID").HasMaxLength(36);
            builder.Property(t => t.ObjectId).HasColumnName("OBJECTID").HasMaxLength(36);
            builder.Property(t => t.IsUndo).HasColumnName("ISUNDO");
            builder.Property(t => t.BranchDateTimeTick).HasColumnName("BRANCHDATETIMETICK");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(t => t.UserId).HasColumnName("USERID").HasMaxLength(36);
            builder.Property(t => t.BranchDate).HasColumnName("BRANCHDATE");
        }
    }
}