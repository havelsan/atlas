using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OrthesisProsthesisProcedureConfig : IEntityTypeConfiguration<AtlasModel.OrthesisProsthesisProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OrthesisProsthesisProcedure> builder)
        {
            builder.ToTable("ORTHESISPROSTHESISPROC");
            builder.HasKey(nameof(AtlasModel.OrthesisProsthesisProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.OrthesisProsthesisProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.OrthesisProsthesisProcedure.IsPrintReport)).HasColumnName("ISPRINTREPORT");
            builder.Property(nameof(AtlasModel.OrthesisProsthesisProcedure.IsRequestReport)).HasColumnName("ISREQUESTREPORT");
            builder.Property(nameof(AtlasModel.OrthesisProsthesisProcedure.Side)).HasColumnName("SIDE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.OrthesisProsthesisProcedure.DrAnesteziTescilNo)).HasColumnName("DRANESTEZITESCILNO");
            builder.Property(nameof(AtlasModel.OrthesisProsthesisProcedure.RaporTakipNo)).HasColumnName("RAPORTAKIPNO");
            builder.Property(nameof(AtlasModel.OrthesisProsthesisProcedure.PayRatio)).HasColumnName("PAYRATIO").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.OrthesisProsthesisProcedure.Price)).HasColumnName("PRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.OrthesisProsthesisProcedure.AyniFarkliKesiRef)).HasColumnName("AYNIFARKLIKESI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OrthesisProsthesisProcedure.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OrthesisProsthesisProcedure.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OrthesisProsthesisProcedure.TechnicianRef)).HasColumnName("TECHNICIAN").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseOrthesisProsthesisProcedure).WithOne().HasForeignKey<AtlasModel.BaseOrthesisProsthesisProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.OrthesisProsthesisProcedure>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.OrthesisProsthesisProcedure>(x => x.ResUserRef).IsRequired(false);
            builder.HasOne(t => t.Technician).WithOne().HasForeignKey<AtlasModel.OrthesisProsthesisProcedure>(x => x.TechnicianRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}