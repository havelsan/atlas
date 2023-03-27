using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTSequenceConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTSequence>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTSequence> builder)
        {
            builder.Property(t => t.DataTypeId).HasColumnName("DATATYPEID").HasMaxLength(36);
            builder.Property(t => t.GroupName).HasColumnName("GROUPNAME").HasMaxLength(50);
            builder.Property(t => t.Year).HasColumnName("YEAR");
            builder.Property(t => t.Seed).HasColumnName("SEED");
            builder.Property(t => t.DbSequenceName).HasColumnName("DBSEQUENCENAME").HasMaxLength(30);
        }
    }
}