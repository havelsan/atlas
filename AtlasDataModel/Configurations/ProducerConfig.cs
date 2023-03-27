using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ProducerConfig : IEntityTypeConfiguration<AtlasModel.Producer>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Producer> builder)
        {
            builder.ToTable("PRODUCER");
            builder.HasKey(nameof(AtlasModel.Producer.ObjectId));
            builder.Property(nameof(AtlasModel.Producer.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Producer.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Producer.SPTSProducerID)).HasColumnName("SPTSPRODUCERID");
            builder.Property(nameof(AtlasModel.Producer.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.Producer.Code)).HasColumnName("CODE");
            builder.Property(nameof(AtlasModel.Producer.VademecumID)).HasColumnName("VADEMECUMID");
            builder.Property(nameof(AtlasModel.Producer.Address)).HasColumnName("ADDRESS").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Producer.Email)).HasColumnName("EMAIL").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Producer.Fax)).HasColumnName("FAX").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Producer.TaxNo)).HasColumnName("TAXNO");
            builder.Property(nameof(AtlasModel.Producer.SupplierNumber)).HasColumnName("SUPPLIERNUMBER").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Producer.TaxOfficeName)).HasColumnName("TAXOFFICENAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Producer.Telephone)).HasColumnName("TELEPHONE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Producer.Note)).HasColumnName("NOTE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Producer.GLNNo)).HasColumnName("GLNNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Producer.FirmIdentifierNo)).HasColumnName("FIRMIDENTIFIERNO");
            builder.Property(nameof(AtlasModel.Producer.ProcuderCodeSeq)).HasColumnName("PROCUDERCODESEQ");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}