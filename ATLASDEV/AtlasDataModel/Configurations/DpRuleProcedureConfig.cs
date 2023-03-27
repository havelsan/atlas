using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DpRuleProcedureConfig : IEntityTypeConfiguration<AtlasModel.DpRuleProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DpRuleProcedure> builder)
        {
            builder.ToTable("DPRULEPROCEDURE");
            builder.HasKey(nameof(AtlasModel.DpRuleProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.DpRuleProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DpRuleProcedure.Master)).HasColumnName("MASTER");
            builder.Property(nameof(AtlasModel.DpRuleProcedure.Code)).HasColumnName("CODE");
            builder.Property(nameof(AtlasModel.DpRuleProcedure.BannOrMustType)).HasColumnName("BANNORMUSTTYPE");
            builder.Property(nameof(AtlasModel.DpRuleProcedure.TimeType)).HasColumnName("TIMETYPE");
            builder.Property(nameof(AtlasModel.DpRuleProcedure.Name)).HasColumnName("NAME").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.DpRuleProcedure.DPRuleMasterRef)).HasColumnName("DPRULEMASTER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DPRuleMaster).WithOne().HasForeignKey<AtlasModel.DpRuleProcedure>(x => x.DPRuleMasterRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}