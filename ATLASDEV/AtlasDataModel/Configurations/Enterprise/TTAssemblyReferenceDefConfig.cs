using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTAssemblyReferenceDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTAssemblyReferenceDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTAssemblyReferenceDef> builder)
        {
            builder.HasKey(t => t.AssemblyDefId);
            builder.Property(t => t.AssemblyDefId).HasColumnName("ASSEMBLYDEFID").HasMaxLength(36);
            builder.Property(t => t.ReferencedAssemblyDefId).HasColumnName("REFERENCEDASSEMBLYDEFID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}