using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    //public partial class TTIndexDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTIndexDef>
    //{
    //    public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTIndexDef> builder)
    //    {
    //        builder.HasKey(t => t.IndexDefId);
    //        builder.Property(t => t.IndexDefId).HasColumnName("INDEXDEFID").HasMaxLength(36);
    //        builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(26);
    //        builder.Property(t => t.IsUnique).HasColumnName("ISUNIQUE");
    //        builder.Property(t => t.Xml).HasColumnName("XML").HasMaxLength(2147483647);
    //        builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
    //        builder.Property(t => t.ObjectDefId).HasColumnName("OBJECTDEFID").HasMaxLength(36);
    //        builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
    //    }
    //}
}