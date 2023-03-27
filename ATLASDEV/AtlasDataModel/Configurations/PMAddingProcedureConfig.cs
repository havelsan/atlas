using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PMAddingProcedureConfig : IEntityTypeConfiguration<AtlasModel.PMAddingProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PMAddingProcedure> builder)
        {
            builder.ToTable("PMADDINGPROCEDURES");
            builder.HasKey(nameof(AtlasModel.PMAddingProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.PMAddingProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PMAddingProcedure.PayerPrice)).HasColumnName("PAYERPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.PMAddingProcedure.PatientPrice)).HasColumnName("PATIENTPRICE").HasColumnType("NUMBER(15,2)");
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);
        }
    }
}