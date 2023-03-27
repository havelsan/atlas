using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseAnesthesiaProcedureConfig : IEntityTypeConfiguration<AtlasModel.BaseAnesthesiaProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseAnesthesiaProcedure> builder)
        {
            builder.ToTable("BASEANESTHESIAPROCEDURE");
            builder.HasKey(nameof(AtlasModel.BaseAnesthesiaProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.BaseAnesthesiaProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseAnesthesiaProcedure.Note)).HasColumnName("NOTE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.BaseAnesthesiaProcedure.ProcedureDoctor2Ref)).HasColumnName("PROCEDUREDOCTOR2").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ProcedureDoctor2).WithOne().HasForeignKey<AtlasModel.BaseAnesthesiaProcedure>(x => x.ProcedureDoctor2Ref).IsRequired(false);
            #endregion Parent Relations
        }
    }
}