using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientOwnDrugReturnConfig : IEntityTypeConfiguration<AtlasModel.PatientOwnDrugReturn>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientOwnDrugReturn> builder)
        {
            builder.ToTable("PATIENTOWNDRUGRETURN");
            builder.HasKey(nameof(AtlasModel.PatientOwnDrugReturn.ObjectId));
            builder.Property(nameof(AtlasModel.PatientOwnDrugReturn.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);
        }
    }
}