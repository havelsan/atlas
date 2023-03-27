using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OlayAfetSMSGonderimConfig : IEntityTypeConfiguration<AtlasModel.OlayAfetSMSGonderim>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OlayAfetSMSGonderim> builder)
        {
            builder.ToTable("OLAYAFETSMSGONDERIM");
            builder.HasKey(nameof(AtlasModel.OlayAfetSMSGonderim.ObjectId));
            builder.Property(nameof(AtlasModel.OlayAfetSMSGonderim.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.OlayAfetSMSGonderim.PhoneNumber)).HasColumnName("PHONENUMBER");
            builder.Property(nameof(AtlasModel.OlayAfetSMSGonderim.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OlayAfetSMSGonderim.SKRSILKodlariRef)).HasColumnName("SKRSILKODLARI").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.OlayAfetSMSGonderim>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}