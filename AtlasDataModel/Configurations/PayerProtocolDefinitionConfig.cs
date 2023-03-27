using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PayerProtocolDefinitionConfig : IEntityTypeConfiguration<AtlasModel.PayerProtocolDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PayerProtocolDefinition> builder)
        {
            builder.ToTable("PAYERPROTOCOLDEFINITION");
            builder.HasKey(nameof(AtlasModel.PayerProtocolDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.PayerProtocolDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PayerProtocolDefinition.ProtocolStartDate)).HasColumnName("PROTOCOLSTARTDATE");
            builder.Property(nameof(AtlasModel.PayerProtocolDefinition.ProtocolEndDate)).HasColumnName("PROTOCOLENDDATE");
            builder.Property(nameof(AtlasModel.PayerProtocolDefinition.PayerRef)).HasColumnName("PAYER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PayerProtocolDefinition.ProtocolRef)).HasColumnName("PROTOCOL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Payer).WithOne().HasForeignKey<AtlasModel.PayerProtocolDefinition>(x => x.PayerRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}