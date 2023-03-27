using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTObjectStateDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTObjectStateDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTObjectStateDef> builder)
        {
            builder.HasKey(t => t.StateDefId);
            builder.Property(t => t.StateDefId).HasColumnName("STATEDEFID").HasMaxLength(36);
            builder.Property(t => t.ObjectDefId).HasColumnName("OBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(t => t.DisplayText).HasColumnName("DISPLAYTEXT").HasMaxLength(150);
            builder.Property(t => t.BaseStateDefId).HasColumnName("BASESTATEDEFID").HasMaxLength(36);
            builder.Property(t => t.FormDefId).HasColumnName("FORMDEFID").HasMaxLength(36);
            builder.Property(t => t.IsEntry).HasColumnName("ISENTRY");
            builder.Property(t => t.IsProtected).HasColumnName("ISPROTECTED");
            builder.Property(t => t.Status).HasColumnName("STATUS");
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
            builder.Property(t => t.Disabled).HasColumnName("DISABLED");
        }
    }
}