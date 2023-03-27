using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EStatusNotRepCommitteeObjConfig : IEntityTypeConfiguration<AtlasModel.EStatusNotRepCommitteeObj>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EStatusNotRepCommitteeObj> builder)
        {
            builder.ToTable("ESTATUSNOTREPCOMMITTEEOBJ");
            builder.HasKey(nameof(AtlasModel.EStatusNotRepCommitteeObj.ObjectId));
            builder.Property(nameof(AtlasModel.EStatusNotRepCommitteeObj.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EStatusNotRepCommitteeObj.ApplicationCouncilSituation)).HasColumnName("APPLICATIONCOUNCILSITUATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EStatusNotRepCommitteeObj.ApplicationType)).HasColumnName("APPLICATIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EStatusNotRepCommitteeObj.PatientApplicationID)).HasColumnName("PATIENTAPPLICATIONID").HasMaxLength(100);
        }
    }
}