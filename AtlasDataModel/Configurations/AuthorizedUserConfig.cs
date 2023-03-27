using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AuthorizedUserConfig : IEntityTypeConfiguration<AtlasModel.AuthorizedUser>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AuthorizedUser> builder)
        {
            builder.ToTable("AUTHORIZEDUSER");
            builder.HasKey(nameof(AtlasModel.AuthorizedUser.ObjectId));
            builder.Property(nameof(AtlasModel.AuthorizedUser.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AuthorizedUser.ActionRef)).HasColumnName("ACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AuthorizedUser.SubactionProcedureRef)).HasColumnName("SUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AuthorizedUser.UserRef)).HasColumnName("USER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Action).WithOne().HasForeignKey<AtlasModel.AuthorizedUser>(x => x.ActionRef).IsRequired(false);
            builder.HasOne(t => t.SubactionProcedure).WithOne().HasForeignKey<AtlasModel.AuthorizedUser>(x => x.SubactionProcedureRef).IsRequired(false);
            builder.HasOne(t => t.User).WithOne().HasForeignKey<AtlasModel.AuthorizedUser>(x => x.UserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}