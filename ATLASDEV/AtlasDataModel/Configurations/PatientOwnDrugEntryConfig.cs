using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientOwnDrugEntryConfig : IEntityTypeConfiguration<AtlasModel.PatientOwnDrugEntry>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientOwnDrugEntry> builder)
        {
            builder.ToTable("PATIENTOWNDRUGENTRY");
            builder.HasKey(nameof(AtlasModel.PatientOwnDrugEntry.ObjectId));
            builder.Property(nameof(AtlasModel.PatientOwnDrugEntry.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);
        }
    }
}