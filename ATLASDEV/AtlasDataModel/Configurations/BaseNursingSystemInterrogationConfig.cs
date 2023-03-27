using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseNursingSystemInterrogationConfig : IEntityTypeConfiguration<AtlasModel.BaseNursingSystemInterrogation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseNursingSystemInterrogation> builder)
        {
            builder.ToTable("BASENURSINGSYSINTERROG");
            builder.HasKey(nameof(AtlasModel.BaseNursingSystemInterrogation.ObjectId));
            builder.Property(nameof(AtlasModel.BaseNursingSystemInterrogation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}