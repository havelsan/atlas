using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ProcedurePriceDefinitionConfig : IEntityTypeConfiguration<AtlasModel.ProcedurePriceDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ProcedurePriceDefinition> builder)
        {
            builder.ToTable("PROCEDUREPRICEDEFINITION");
            builder.HasKey(nameof(AtlasModel.ProcedurePriceDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.ProcedurePriceDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ProcedurePriceDefinition.AMOUNT)).HasColumnName("AMOUNT");
            builder.Property(nameof(AtlasModel.ProcedurePriceDefinition.ProcedureObjectRef)).HasColumnName("PROCEDUREOBJECT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ProcedurePriceDefinition.PricingDetailRef)).HasColumnName("PRICINGDETAIL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ProcedureObject).WithOne().HasForeignKey<AtlasModel.ProcedurePriceDefinition>(x => x.ProcedureObjectRef).IsRequired(true);
            builder.HasOne(t => t.PricingDetail).WithOne().HasForeignKey<AtlasModel.ProcedurePriceDefinition>(x => x.PricingDetailRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}