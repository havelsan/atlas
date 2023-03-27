using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PsychologyTestConfig : IEntityTypeConfiguration<AtlasModel.PsychologyTest>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PsychologyTest> builder)
        {
            builder.ToTable("PSYCHOLOGYTEST");
            builder.HasKey(nameof(AtlasModel.PsychologyTest.ObjectId));
            builder.Property(nameof(AtlasModel.PsychologyTest.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PsychologyTest.Description)).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);
        }
    }
}