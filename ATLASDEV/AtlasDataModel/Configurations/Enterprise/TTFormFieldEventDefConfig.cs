using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTFormFieldEventDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTFormFieldEventDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTFormFieldEventDef> builder)
        {
            builder.HasKey(t => t.EventDefId);
            builder.Property(t => t.EventDefId).HasColumnName("EVENTDEFID").HasMaxLength(36);
            builder.Property(t => t.FieldDefId).HasColumnName("FIELDDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(250);
            builder.Property(t => t.Body).HasColumnName("BODY").HasMaxLength(2147483647);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}