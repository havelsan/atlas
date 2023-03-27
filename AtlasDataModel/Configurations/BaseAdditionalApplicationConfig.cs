using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseAdditionalApplicationConfig : IEntityTypeConfiguration<AtlasModel.BaseAdditionalApplication>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseAdditionalApplication> builder)
        {
            builder.ToTable("BASEADDITIONALAPPLICATION");
            builder.HasKey(nameof(AtlasModel.BaseAdditionalApplication.ObjectId));
            builder.Property(nameof(AtlasModel.BaseAdditionalApplication.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseAdditionalApplication.NurseNotes)).HasColumnName("NURSENOTES").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.BaseAdditionalApplication.Result)).HasColumnName("RESULT").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.BaseAdditionalApplication.Description)).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.BaseAdditionalApplication.ReportApplicationAreaRef)).HasColumnName("REPORTAPPLICATIONAREA").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseSurgeryAndManipulationProcedure).WithOne().HasForeignKey<AtlasModel.BaseSurgeryAndManipulationProcedure>(p => p.ObjectId);
        }
    }
}