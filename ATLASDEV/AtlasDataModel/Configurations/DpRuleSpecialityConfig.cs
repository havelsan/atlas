using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DpRuleSpecialityConfig : IEntityTypeConfiguration<AtlasModel.DpRuleSpeciality>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DpRuleSpeciality> builder)
        {
            builder.ToTable("DPRULESPECIALITY");
            builder.HasKey(nameof(AtlasModel.DpRuleSpeciality.ObjectId));
            builder.Property(nameof(AtlasModel.DpRuleSpeciality.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DpRuleSpeciality.Master)).HasColumnName("MASTER");
            builder.Property(nameof(AtlasModel.DpRuleSpeciality.Code)).HasColumnName("CODE");
            builder.Property(nameof(AtlasModel.DpRuleSpeciality.BannOrMustType)).HasColumnName("BANNORMUSTTYPE");
            builder.Property(nameof(AtlasModel.DpRuleSpeciality.Name)).HasColumnName("NAME").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.DpRuleSpeciality.DPRuleMasterRef)).HasColumnName("DPRULEMASTER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DPRuleMaster).WithOne().HasForeignKey<AtlasModel.DpRuleSpeciality>(x => x.DPRuleMasterRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}