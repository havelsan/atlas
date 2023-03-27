using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class CheckRadWorkListSecondTimeConfig : IEntityTypeConfiguration<AtlasModel.CheckRadWorkListSecondTime>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.CheckRadWorkListSecondTime> builder)
        {
            builder.ToTable("CHECKRADWORKLISTSECONDTIME");
            builder.HasKey(nameof(AtlasModel.CheckRadWorkListSecondTime.ObjectId));
            builder.Property(nameof(AtlasModel.CheckRadWorkListSecondTime.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseScheduledTask).WithOne().HasForeignKey<AtlasModel.BaseScheduledTask>(p => p.ObjectId);
        }
    }
}