using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    //public partial class TTDataTypeConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTDataType>
    //{
    //    public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTDataType> builder)
    //    {
    //        builder.HasKey(t => t.DataTypeId);
    //        builder.Property(t => t.DataTypeId).HasColumnName("DATATYPEID").HasMaxLength(36);
    //        builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(100);
    //        builder.Property(t => t.EType).HasColumnName("PRIMITIVETYPE");
    //        builder.Property(t => t.MinValue).HasColumnName("MINVALUE").HasMaxLength(2147483647);
    //        builder.Property(t => t.MaxValue).HasColumnName("MAXVALUE").HasMaxLength(2147483647);
    //        builder.Property(t => t.Length).HasColumnName("LENGTH");
    //        builder.Property(t => t.Precision).HasColumnName("PRECISION");
    //        builder.Property(t => t.DefaultValue).HasColumnName("DEFAULTVALUE").HasMaxLength(2147483647);
    //        builder.Property(t => t.Properties).HasColumnName("PROPERTIES").HasMaxLength(2147483647);
    //        builder.Property(t => t.ModuleDefId).HasColumnName("MODULEDEFID").HasMaxLength(36);
    //        builder.Property(t => t.CheckOutId).HasColumnName("CHECKOUTID").HasMaxLength(36);
    //        builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
    //        builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
    //    }
    //}
}