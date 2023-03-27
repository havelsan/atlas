using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AccountPeriodDefinitionConfig : IEntityTypeConfiguration<AtlasModel.AccountPeriodDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AccountPeriodDefinition> builder)
        {
            builder.ToTable("ACCOUNTPERIODDEFINITION");
            builder.HasKey(nameof(AtlasModel.AccountPeriodDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.AccountPeriodDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AccountPeriodDefinition.Year)).HasColumnName("YEAR");
            builder.Property(nameof(AtlasModel.AccountPeriodDefinition.Month)).HasColumnName("MONTH").HasColumnType("NUMBER(10)");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}