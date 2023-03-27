using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTFormDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTFormDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTFormDef> builder)
        {
            builder.HasKey(t => t.FormDefId);
            builder.Property(t => t.FormDefId).HasColumnName("FORMDEFID").HasMaxLength(36);
            builder.Property(t => t.ObjectDefId).HasColumnName("OBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(t => t.Namespace).HasColumnName("NAMESPACE").HasMaxLength(100);
            builder.Property(t => t.Caption).HasColumnName("CAPTION").HasMaxLength(200);
            builder.Property(t => t.PreScript).HasColumnName("PRESCRIPT").HasMaxLength(2147483647);
            builder.Property(t => t.PostScript).HasColumnName("POSTSCRIPT").HasMaxLength(2147483647);
            builder.Property(t => t.BaseFormDefId).HasColumnName("BASEFORMDEFID").HasMaxLength(36);
            builder.Property(t => t.Width).HasColumnName("WIDTH");
            builder.Property(t => t.Height).HasColumnName("HEIGHT");
            builder.Property(t => t.FormType).HasColumnName("FORMTYPE");
            builder.Property(t => t.Methods).HasColumnName("METHODS").HasMaxLength(2147483647);
            builder.Property(t => t.DifferenceXml).HasColumnName("DIFFERENCEXML").HasMaxLength(2147483647);
            builder.Property(t => t.PermissionDefId).HasColumnName("PERMISSIONDEFID").HasMaxLength(36);
            builder.Property(t => t.ModuleDefId).HasColumnName("MODULEDEFID").HasMaxLength(36);
            builder.Property(t => t.CheckOutId).HasColumnName("CHECKOUTID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.FormNo).HasColumnName("FORMNO").HasMaxLength(10);
            builder.Property(t => t.HelpNamespace).HasColumnName("HELPNAMESPACE").HasMaxLength(255);
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
            builder.Property(t => t.ClientSidePreScript).HasColumnName("CLIENTSIDEPRESCRIPT").HasMaxLength(2147483647);
            builder.Property(t => t.ClientSidePostScript).HasColumnName("CLIENTSIDEPOSTSCRIPT").HasMaxLength(2147483647);
            builder.Property(t => t.DeMethods).HasColumnName("CLIENTSIDEMETHODS").HasMaxLength(2147483647);
        }
    }
}