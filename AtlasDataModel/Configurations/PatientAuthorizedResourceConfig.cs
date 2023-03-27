using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientAuthorizedResourceConfig : IEntityTypeConfiguration<AtlasModel.PatientAuthorizedResource>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientAuthorizedResource> builder)
        {
            builder.ToTable("PATIENTAUTHORIZEDRESOURCE");
            builder.HasKey(nameof(AtlasModel.PatientAuthorizedResource.ObjectId));
            builder.Property(nameof(AtlasModel.PatientAuthorizedResource.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientAuthorizedResource.ResourceRef)).HasColumnName("RESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAuthorizedResource.EpisodeRef)).HasColumnName("EPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientAuthorizedResource.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Resource).WithOne().HasForeignKey<AtlasModel.PatientAuthorizedResource>(x => x.ResourceRef).IsRequired(false);
            builder.HasOne(t => t.Episode).WithOne().HasForeignKey<AtlasModel.PatientAuthorizedResource>(x => x.EpisodeRef).IsRequired(false);
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.PatientAuthorizedResource>(x => x.PatientRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}