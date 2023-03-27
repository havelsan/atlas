using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class CheckRadWorkListFirstTimeConfig : IEntityTypeConfiguration<AtlasModel.CheckRadWorkListFirstTime>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.CheckRadWorkListFirstTime> builder)
        {
            builder.ToTable("CHECKRADWORKLISTFIRSTTIME");
            builder.HasKey(nameof(AtlasModel.CheckRadWorkListFirstTime.ObjectId));
            builder.Property(nameof(AtlasModel.CheckRadWorkListFirstTime.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseScheduledTask).WithOne().HasForeignKey<AtlasModel.BaseScheduledTask>(p => p.ObjectId);
        }
    }
}