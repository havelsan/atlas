using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingSystemInterrogationConfig : IEntityTypeConfiguration<AtlasModel.NursingSystemInterrogation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingSystemInterrogation> builder)
        {
            builder.ToTable("NURSINGSYSTEMINTERROGATION");
            builder.HasKey(nameof(AtlasModel.NursingSystemInterrogation.ObjectId));
            builder.Property(nameof(AtlasModel.NursingSystemInterrogation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingSystemInterrogation.BaseNursSysInterrogationRef)).HasColumnName("BASENURSSYSINTERROGATION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.BaseNursSysInterrogation).WithOne().HasForeignKey<AtlasModel.NursingSystemInterrogation>(x => x.BaseNursSysInterrogationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}