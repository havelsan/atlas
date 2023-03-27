using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugReturnActionConfig : IEntityTypeConfiguration<AtlasModel.DrugReturnAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugReturnAction> builder)
        {
            builder.ToTable("DRUGRETURNACTION");
            builder.HasKey(nameof(AtlasModel.DrugReturnAction.ObjectId));
            builder.Property(nameof(AtlasModel.DrugReturnAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugReturnAction.DrugReturnReason)).HasColumnName("DRUGRETURNREASON");
            builder.Property(nameof(AtlasModel.DrugReturnAction.PharmacyStoreDefinitionRef)).HasColumnName("PHARMACYSTOREDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.PharmacyStoreDefinition).WithOne().HasForeignKey<AtlasModel.DrugReturnAction>(x => x.PharmacyStoreDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}