using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingProblemReasonRelationConfig : IEntityTypeConfiguration<AtlasModel.NursingProblemReasonRelation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingProblemReasonRelation> builder)
        {
            builder.ToTable("NURSINGPROBLEMREASONREL");
            builder.HasKey(nameof(AtlasModel.NursingProblemReasonRelation.ObjectId));
            builder.Property(nameof(AtlasModel.NursingProblemReasonRelation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
        }
    }
}