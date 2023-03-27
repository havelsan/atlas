using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DPRuleMasterConfig : IEntityTypeConfiguration<AtlasModel.DPRuleMaster>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DPRuleMaster> builder)
        {
            builder.ToTable("DPRULEMASTER");
            builder.HasKey(nameof(AtlasModel.DPRuleMaster.ObjectId));
            builder.Property(nameof(AtlasModel.DPRuleMaster.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DPRuleMaster.Code)).HasColumnName("CODE");
            builder.Property(nameof(AtlasModel.DPRuleMaster.Name)).HasColumnName("NAME").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.DPRuleMaster.GILDefinitionRef)).HasColumnName("GILDEFINITION").HasMaxLength(36).IsFixedLength();
        }
    }
}