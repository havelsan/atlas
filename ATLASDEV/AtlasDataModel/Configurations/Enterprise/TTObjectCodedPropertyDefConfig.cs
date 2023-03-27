using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTObjectCodedPropertyDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTObjectCodedPropertyDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTObjectCodedPropertyDef> builder)
        {
            builder.HasKey(t => t.CodedPropertyDefId);
            builder.Property(t => t.CodedPropertyDefId).HasColumnName("CODEDPROPERTYDEFID").HasMaxLength(36);
            builder.Property(t => t.ObjectDefId).HasColumnName("OBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(t => t.DataTypeId).HasColumnName("DATATYPEID").HasMaxLength(36);
            builder.Property(t => t.GetScript).HasColumnName("GETSCRIPT").HasMaxLength(2147483647);
            builder.Property(t => t.SetScript).HasColumnName("SETSCRIPT").HasMaxLength(2147483647);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
        }
    }
}