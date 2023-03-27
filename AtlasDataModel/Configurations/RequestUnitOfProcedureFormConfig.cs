using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class RequestUnitOfProcedureFormConfig : IEntityTypeConfiguration<AtlasModel.RequestUnitOfProcedureForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.RequestUnitOfProcedureForm> builder)
        {
            builder.ToTable("REQUESTUNITOFPROCEDUREFORM");
            builder.HasKey(nameof(AtlasModel.RequestUnitOfProcedureForm.ObjectId));
            builder.Property(nameof(AtlasModel.RequestUnitOfProcedureForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.RequestUnitOfProcedureForm.ProcedureRequestFormDefRef)).HasColumnName("PROCEDUREREQUESTFORMDEF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RequestUnitOfProcedureForm.ResourceRef)).HasColumnName("RESOURCE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ProcedureRequestFormDef).WithOne().HasForeignKey<AtlasModel.RequestUnitOfProcedureForm>(x => x.ProcedureRequestFormDefRef).IsRequired(false);
            builder.HasOne(t => t.Resource).WithOne().HasForeignKey<AtlasModel.RequestUnitOfProcedureForm>(x => x.ResourceRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}