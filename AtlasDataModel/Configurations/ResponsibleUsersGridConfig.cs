using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResponsibleUsersGridConfig : IEntityTypeConfiguration<AtlasModel.ResponsibleUsersGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResponsibleUsersGrid> builder)
        {
            builder.ToTable("RESPONSIBLEUSERSGRID");
            builder.HasKey(nameof(AtlasModel.ResponsibleUsersGrid.ObjectId));
            builder.Property(nameof(AtlasModel.ResponsibleUsersGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResponsibleUsersGrid.ResSectionRef)).HasColumnName("RESSECTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResponsibleUsersGrid.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResponsibleUsersGrid>(x => x.ResSectionRef).IsRequired(true);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.ResponsibleUsersGrid>(x => x.ResUserRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}