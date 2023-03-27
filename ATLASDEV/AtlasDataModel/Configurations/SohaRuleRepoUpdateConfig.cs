using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SohaRuleRepoUpdateConfig : IEntityTypeConfiguration<AtlasModel.SohaRuleRepoUpdate>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SohaRuleRepoUpdate> builder)
        {
            builder.ToTable("SOHARULEREPOUPDATE");
            builder.HasKey(nameof(AtlasModel.SohaRuleRepoUpdate.ObjectId));
            builder.Property(nameof(AtlasModel.SohaRuleRepoUpdate.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SohaRuleRepoUpdate.UpdateDate)).HasColumnName("UPDATEDATE");
            builder.Property(nameof(AtlasModel.SohaRuleRepoUpdate.RepositoryType)).HasColumnName("REPOSITORYTYPE").HasColumnType("NUMBER(10)");
        }
    }
}