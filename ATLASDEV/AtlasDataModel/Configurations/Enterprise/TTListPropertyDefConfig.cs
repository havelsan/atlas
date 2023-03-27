using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTListPropertyDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTListPropertyDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTListPropertyDef> builder)
        {
            builder.HasKey(t => t.ListPropertyDefId);
            builder.Property(t => t.ListPropertyDefId).HasColumnName("LISTPROPERTYDEFID").HasMaxLength(36);
            builder.Property(t => t.ListDefId).HasColumnName("LISTDEFID").HasMaxLength(36);
            builder.Property(t => t.MemberName).HasColumnName("MEMBERNAME").HasMaxLength(255);
            builder.Property(t => t.Caption).HasColumnName("CAPTION").HasMaxLength(50);
            builder.Property(t => t.AccessType).HasColumnName("ACCESSTYPE");
            builder.Property(t => t.CriteriaOrder).HasColumnName("CRITERIAORDER");
            builder.Property(t => t.ControlWidth).HasColumnName("CONTROLWIDTH");
            builder.Property(t => t.FormFieldDefId).HasColumnName("FORMFIELDDEFID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}