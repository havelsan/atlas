using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SpecialPanelCriteriaValueConfig : IEntityTypeConfiguration<AtlasModel.SpecialPanelCriteriaValue>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SpecialPanelCriteriaValue> builder)
        {
            builder.ToTable("SPECIALPANELCRITERIAVALUE");
            builder.HasKey(nameof(AtlasModel.SpecialPanelCriteriaValue.ObjectId));
            builder.Property(nameof(AtlasModel.SpecialPanelCriteriaValue.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SpecialPanelCriteriaValue.Value)).HasColumnName("VALUE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.SpecialPanelCriteriaValue.Name)).HasColumnName("NAME").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.SpecialPanelCriteriaValue.SpecialPanelRef)).HasColumnName("SPECIALPANEL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SpecialPanel).WithOne().HasForeignKey<AtlasModel.SpecialPanelCriteriaValue>(x => x.SpecialPanelRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}