using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTObjectStateTransitionDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTObjectStateTransitionDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTObjectStateTransitionDef> builder)
        {
            builder.HasKey(t => t.StateTransitionDefId);
            builder.Property(t => t.StateTransitionDefId).HasColumnName("STATETRANSITIONDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(t => t.DisplayText).HasColumnName("DISPLAYTEXT").HasMaxLength(150);
            builder.Property(t => t.FromStateDefId).HasColumnName("FROMSTATEDEFID").HasMaxLength(36);
            builder.Property(t => t.ToStateDefId).HasColumnName("TOSTATEDEFID").HasMaxLength(36);
            builder.Property(t => t.PreScript).HasColumnName("PRESCRIPT").HasMaxLength(2147483647);
            builder.Property(t => t.PostScript).HasColumnName("POSTSCRIPT").HasMaxLength(2147483647);
            builder.Property(t => t.UndoScript).HasColumnName("UNDOSCRIPT").HasMaxLength(2147483647);
            builder.Property(t => t.ShouldCallBasePreScript).HasColumnName("SHOULDCALLBASEPRESCRIPT");
            builder.Property(t => t.ShouldCallBasePostScript).HasColumnName("SHOULDCALLBASEPOSTSCRIPT");
            builder.Property(t => t.ShouldCallBaseUndoScript).HasColumnName("SHOULDCALLBASEUNDOSCRIPT");
            builder.Property(t => t.ChildShouldCallPreScript).HasColumnName("CHILDSHOULDCALLPRESCRIPT");
            builder.Property(t => t.ChildShouldCallPostScript).HasColumnName("CHILDSHOULDCALLPOSTSCRIPT");
            builder.Property(t => t.ChildShouldCallUndoScript).HasColumnName("CHILDSHOULDCALLUNDOSCRIPT");
            builder.Property(t => t.OrderNo).HasColumnName("ORDERNO");
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
        }
    }
}