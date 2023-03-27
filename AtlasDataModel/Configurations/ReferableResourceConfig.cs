using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReferableResourceConfig : IEntityTypeConfiguration<AtlasModel.ReferableResource>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ReferableResource> builder)
        {
            builder.ToTable("REFERABLERESOURCE");
            builder.HasKey(nameof(AtlasModel.ReferableResource.ObjectId));
            builder.Property(nameof(AtlasModel.ReferableResource.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ReferableResource.ResourceObjectID)).HasColumnName("RESOURCEOBJECTID");
            builder.Property(nameof(AtlasModel.ReferableResource.ResourceName)).HasColumnName("RESOURCENAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ReferableResource.ResourceName_Shadow)).HasColumnName("RESOURCENAME_SHADOW");
            builder.Property(nameof(AtlasModel.ReferableResource.LastUpdateRealSiteGuid)).HasColumnName("LASTUPDATEREALSITEGUID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ReferableResource.LastUpdateSiteGuid)).HasColumnName("LASTUPDATESITEGUID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ReferableResource.ReferableHospitalRef)).HasColumnName("REFERABLEHOSPITAL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}