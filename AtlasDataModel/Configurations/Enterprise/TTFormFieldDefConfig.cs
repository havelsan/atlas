using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTFormFieldDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTFormFieldDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTFormFieldDef> builder)
        {
            builder.HasKey(t => t.FieldDefId);
            builder.Property(t => t.FieldDefId).HasColumnName("FIELDDEFID").HasMaxLength(36);
            builder.Property(t => t.FormDefId).HasColumnName("FORMDEFID").HasMaxLength(36);
            builder.Property(t => t.ParentFieldDefId).HasColumnName("PARENTFIELDDEFID").HasMaxLength(36);
            builder.Property(t => t.OrderNo).HasColumnName("ORDERNO");
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(t => t.ControlClass).HasColumnName("CONTROLCLASS").HasMaxLength(250);
            builder.Property(t => t.DataMember).HasColumnName("DATAMEMBER").HasMaxLength(255);
            builder.Property(t => t.ControlProperties).HasColumnName("CONTROLPROPERTIES").HasMaxLength(2147483647);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}