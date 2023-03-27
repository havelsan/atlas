using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class WorkDayExceptionDefConfig : IEntityTypeConfiguration<AtlasModel.WorkDayExceptionDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.WorkDayExceptionDef> builder)
        {
            builder.ToTable("WORKDAYEXCEPTIONDEF");
            builder.HasKey(nameof(AtlasModel.WorkDayExceptionDef.ObjectId));
            builder.Property(nameof(AtlasModel.WorkDayExceptionDef.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.WorkDayExceptionDef.Date)).HasColumnName("DATE");
            builder.Property(nameof(AtlasModel.WorkDayExceptionDef.Description)).HasColumnName("DESCRIPTION").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.WorkDayExceptionDef.Description_Shadow)).HasColumnName("DESCRIPTION_SHADOW");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}