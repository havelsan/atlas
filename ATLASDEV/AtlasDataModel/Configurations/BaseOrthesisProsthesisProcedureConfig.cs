using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseOrthesisProsthesisProcedureConfig : IEntityTypeConfiguration<AtlasModel.BaseOrthesisProsthesisProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseOrthesisProsthesisProcedure> builder)
        {
            builder.ToTable("BASEORTHESISPROSTHESISPROC");
            builder.HasKey(nameof(AtlasModel.BaseOrthesisProsthesisProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.BaseOrthesisProsthesisProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);
        }
    }
}