using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AnesthesiaResponsibleDoctorConfig : IEntityTypeConfiguration<AtlasModel.AnesthesiaResponsibleDoctor>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AnesthesiaResponsibleDoctor> builder)
        {
            builder.ToTable("ANESTHESIARESPDOCTOR");
            builder.HasKey(nameof(AtlasModel.AnesthesiaResponsibleDoctor.ObjectId));
            builder.Property(nameof(AtlasModel.AnesthesiaResponsibleDoctor.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AnesthesiaResponsibleDoctor.ResponsibleDoctorRef)).HasColumnName("RESPONSIBLEDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AnesthesiaResponsibleDoctor.AnesthesiaAndReanimationRef)).HasColumnName("ANESTHESIAANDREANIMATION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResponsibleDoctor).WithOne().HasForeignKey<AtlasModel.AnesthesiaResponsibleDoctor>(x => x.ResponsibleDoctorRef).IsRequired(false);
            builder.HasOne(t => t.AnesthesiaAndReanimation).WithOne().HasForeignKey<AtlasModel.AnesthesiaResponsibleDoctor>(x => x.AnesthesiaAndReanimationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}