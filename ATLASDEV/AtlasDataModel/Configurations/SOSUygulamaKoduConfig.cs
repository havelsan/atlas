using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SOSUygulamaKoduConfig : IEntityTypeConfiguration<AtlasModel.SOSUygulamaKodu>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SOSUygulamaKodu> builder)
        {
            builder.ToTable("SOSUYGULAMAKODU");
            builder.HasKey(nameof(AtlasModel.SOSUygulamaKodu.ObjectId));
            builder.Property(nameof(AtlasModel.SOSUygulamaKodu.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SOSUygulamaKodu.SOSID)).HasColumnName("SOSID");
            builder.Property(nameof(AtlasModel.SOSUygulamaKodu.Code)).HasColumnName("CODE").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.SOSUygulamaKodu.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.SOSUygulamaKodu.XXXXXXRouteOfAdminRef)).HasColumnName("XXXXXXROUTEOFADMIN").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}