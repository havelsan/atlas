using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PsychologyAuthorizedUserConfig : IEntityTypeConfiguration<AtlasModel.PsychologyAuthorizedUser>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PsychologyAuthorizedUser> builder)
        {
            builder.ToTable("PSYCHOLOGYAUTHORIZEDUSER");
            builder.HasKey(nameof(AtlasModel.PsychologyAuthorizedUser.ObjectId));
            builder.Property(nameof(AtlasModel.PsychologyAuthorizedUser.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PsychologyAuthorizedUser.PsychologyBasedObjectRef)).HasColumnName("PSYCHOLOGYBASEDOBJECT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PsychologyAuthorizedUser.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.PsychologyBasedObject).WithOne().HasForeignKey<AtlasModel.PsychologyAuthorizedUser>(x => x.PsychologyBasedObjectRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.PsychologyAuthorizedUser>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}