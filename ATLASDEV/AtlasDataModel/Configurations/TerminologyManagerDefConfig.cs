using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TerminologyManagerDefConfig : IEntityTypeConfiguration<AtlasModel.TerminologyManagerDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TerminologyManagerDef> builder)
        {
            builder.ToTable("TERMINOLOGYMANAGER");
            builder.HasKey(nameof(AtlasModel.TerminologyManagerDef.ObjectId));
            builder.Property(nameof(AtlasModel.TerminologyManagerDef.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
        }
    }
}