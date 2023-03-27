using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTListDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTListDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTListDef> builder)
        {
            builder.HasKey(t => t.ListDefId);
            builder.Property(t => t.ListDefId).HasColumnName("LISTDEFID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(t => t.Caption).HasColumnName("CAPTION").HasMaxLength(2147483647);
            builder.Property(t => t.ObjectDefId).HasColumnName("OBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.ValuePropertyName).HasColumnName("VALUEPROPERTYNAME").HasMaxLength(50);
            builder.Property(t => t.TreeViewParentPath).HasColumnName("TREEVIEWPARENTPATH").HasMaxLength(1000);
            builder.Property(t => t.AllowSelectionFromTree).HasColumnName("ALLOWSELECTIONFROMTREE");
            builder.Property(t => t.AllowOnlyLeafSelection).HasColumnName("ALLOWONLYLEAFSELECTION");
            builder.Property(t => t.AutoSearchOnTreeSelect).HasColumnName("AUTOSEARCHONTREESELECT");
            builder.Property(t => t.AutoFillList).HasColumnName("AUTOFILLLIST");
            builder.Property(t => t.FilterExpression).HasColumnName("FILTEREXPRESSION").HasMaxLength(2147483647);
            builder.Property(t => t.DefaultFilterExpression).HasColumnName("DEFAULTFILTEREXPRESSION").HasMaxLength(2147483647);
            builder.Property(t => t.DisplayExpression).HasColumnName("DISPLAYEXPRESSION").HasMaxLength(2147483647);
            builder.Property(t => t.FormWidth).HasColumnName("FORMWIDTH");
            builder.Property(t => t.FormHeight).HasColumnName("FORMHEIGHT");
            builder.Property(t => t.FormDefId).HasColumnName("FORMDEFID").HasMaxLength(36);
            builder.Property(t => t.ModuleDefId).HasColumnName("MODULEDEFID").HasMaxLength(36);
            builder.Property(t => t.QueryDefId).HasColumnName("QUERYDEFID").HasMaxLength(36);
            builder.Property(t => t.Methods).HasColumnName("METHODS").HasMaxLength(2147483647);
            builder.Property(t => t.CheckOutId).HasColumnName("CHECKOUTID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
        }
    }
}