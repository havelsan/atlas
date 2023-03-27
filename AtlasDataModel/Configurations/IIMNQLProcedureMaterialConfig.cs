using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class IIMNQLProcedureMaterialConfig : IEntityTypeConfiguration<AtlasModel.IIMNQLProcedureMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.IIMNQLProcedureMaterial> builder)
        {
            builder.ToTable("IIMNQLPROCEDUREMATERIAL");
            builder.HasKey(nameof(AtlasModel.IIMNQLProcedureMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.IIMNQLProcedureMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.IIMNQLProcedureMaterial.Result)).HasColumnName("RESULT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.IIMNQLProcedureMaterial.InvoiceInclusionMasterRef)).HasColumnName("INVOICEINCLUSIONMASTER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.IIMNQLProcedureMaterial.ProcedureDefinitionRef)).HasColumnName("PROCEDUREDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.IIMNQLProcedureMaterial.InvoiceInclusionNQLRef)).HasColumnName("INVOICEINCLUSIONNQL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.InvoiceInclusionMaster).WithOne().HasForeignKey<AtlasModel.IIMNQLProcedureMaterial>(x => x.InvoiceInclusionMasterRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.IIMNQLProcedureMaterial>(x => x.ProcedureDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.InvoiceInclusionNQL).WithOne().HasForeignKey<AtlasModel.IIMNQLProcedureMaterial>(x => x.InvoiceInclusionNQLRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}