using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SupplierConfig : IEntityTypeConfiguration<AtlasModel.Supplier>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Supplier> builder)
        {
            builder.ToTable("SUPPLIER");
            builder.HasKey(nameof(AtlasModel.Supplier.ObjectId));
            builder.Property(nameof(AtlasModel.Supplier.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Supplier.Note)).HasColumnName("NOTE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Supplier.Type)).HasColumnName("TYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Supplier.Email)).HasColumnName("EMAIL").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Supplier.Address)).HasColumnName("ADDRESS").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.Supplier.TaxOfficeName)).HasColumnName("TAXOFFICENAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Supplier.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Supplier.TaxNo)).HasColumnName("TAXNO");
            builder.Property(nameof(AtlasModel.Supplier.Fax)).HasColumnName("FAX").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Supplier.Telephone)).HasColumnName("TELEPHONE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Supplier.RelatedPerson)).HasColumnName("RELATEDPERSON").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Supplier.Code)).HasColumnName("CODE");
            builder.Property(nameof(AtlasModel.Supplier.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.Supplier.GLNNo)).HasColumnName("GLNNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Supplier.ActivityType)).HasColumnName("ACTIVITYTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Supplier.SupplierNumber)).HasColumnName("SUPPLIERNUMBER").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Supplier.FirmIdentifierNo)).HasColumnName("FIRMIDENTIFIERNO");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}