using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AccountancyConfig : IEntityTypeConfiguration<AtlasModel.Accountancy>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Accountancy> builder)
        {
            builder.ToTable("ACCOUNTANCY");
            builder.HasKey(nameof(AtlasModel.Accountancy.ObjectId));
            builder.Property(nameof(AtlasModel.Accountancy.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Accountancy.QREF)).HasColumnName("QREF").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Accountancy.AccountancyCode)).HasColumnName("ACCOUNTANCYCODE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Accountancy.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Accountancy.Address)).HasColumnName("ADDRESS").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Accountancy.AccountancyNO)).HasColumnName("ACCOUNTANCYNO").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Accountancy.IsNonBarcode)).HasColumnName("ISNONBARCODE");
            builder.Property(nameof(AtlasModel.Accountancy.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.Accountancy.QREF_Shadow)).HasColumnName("QREF_SHADOW");
            builder.Property(nameof(AtlasModel.Accountancy.GLNNo)).HasColumnName("GLNNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Accountancy.AccountancyMilitaryUnitRef)).HasColumnName("ACCOUNTANCYMILITARYUNIT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Accountancy.UnitStoreGetDataRef)).HasColumnName("UNITSTOREGETDATA").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}