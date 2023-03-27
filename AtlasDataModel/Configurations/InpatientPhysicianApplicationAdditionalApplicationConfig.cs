using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InpatientPhysicianApplicationAdditionalApplicationConfig : IEntityTypeConfiguration<AtlasModel.InpatientPhysicianApplicationAdditionalApplication>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InpatientPhysicianApplicationAdditionalApplication> builder)
        {
            builder.ToTable("INPATIENTPHYSICIANAPPADD");
            builder.HasKey(nameof(AtlasModel.InpatientPhysicianApplicationAdditionalApplication.ObjectId));
            builder.Property(nameof(AtlasModel.InpatientPhysicianApplicationAdditionalApplication.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseAdditionalApplication).WithOne().HasForeignKey<AtlasModel.BaseAdditionalApplication>(p => p.ObjectId);
        }
    }
}