using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SEPEpicrisisConfig : IEntityTypeConfiguration<AtlasModel.SEPEpicrisis>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SEPEpicrisis> builder)
        {
            builder.ToTable("SEPEPICRISIS");
            builder.HasKey(nameof(AtlasModel.SEPEpicrisis.ObjectId));
            builder.Property(nameof(AtlasModel.SEPEpicrisis.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SEPEpicrisis.CreateDate)).HasColumnName("CREATEDATE");
            builder.Property(nameof(AtlasModel.SEPEpicrisis.Description)).HasColumnName("DESCRIPTION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.SEPEpicrisis.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.SEPEpicrisis>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}