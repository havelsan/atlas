using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingCareConfig : IEntityTypeConfiguration<AtlasModel.NursingCare>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingCare> builder)
        {
            builder.ToTable("NURSINGCARE");
            builder.HasKey(nameof(AtlasModel.NursingCare.ObjectId));
            builder.Property(nameof(AtlasModel.NursingCare.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingCare.Amount)).HasColumnName("AMOUNT");
            builder.Property(nameof(AtlasModel.NursingCare.Note)).HasColumnName("NOTE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingCare.NursingResult)).HasColumnName("NURSINGRESULT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingCare.NursingProblemRef)).HasColumnName("NURSINGPROBLEM").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}