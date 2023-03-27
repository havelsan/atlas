using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class CollectiveInvoiceOpDetailConfig : IEntityTypeConfiguration<AtlasModel.CollectiveInvoiceOpDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.CollectiveInvoiceOpDetail> builder)
        {
            builder.ToTable("COLLECTIVEINVOICEOPDETAIL");
            builder.HasKey(nameof(AtlasModel.CollectiveInvoiceOpDetail.ObjectId));
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOpDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOpDetail.ExecObjectID)).HasColumnName("EXECOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOpDetail.ExecObjectType)).HasColumnName("EXECOBJECTTYPE");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOpDetail.ExecDate)).HasColumnName("EXECDATE");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOpDetail.ErrorCode)).HasColumnName("ERRORCODE");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOpDetail.ErrorMessage)).HasColumnName("ERRORMESSAGE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOpDetail.MedulaTakipNo)).HasColumnName("MEDULATAKIPNO");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOpDetail.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOpDetail.CollectiveInvoiceOpRef)).HasColumnName("COLLECTIVEINVOICEOP").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.CollectiveInvoiceOp).WithOne().HasForeignKey<AtlasModel.CollectiveInvoiceOpDetail>(x => x.CollectiveInvoiceOpRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}