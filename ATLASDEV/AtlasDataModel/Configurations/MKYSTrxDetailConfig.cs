using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MKYSTrxDetailConfig : IEntityTypeConfiguration<AtlasModel.MKYSTrxDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MKYSTrxDetail> builder)
        {
            builder.ToTable("MKYSTRXDETAIL");
            builder.HasKey(nameof(AtlasModel.MKYSTrxDetail.ObjectId));
            builder.Property(nameof(AtlasModel.MKYSTrxDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MKYSTrxDetail.Amount)).HasColumnName("AMOUNT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.MKYSTrxDetail.InMKYSTrxRef)).HasColumnName("INMKYSTRX").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MKYSTrxDetail.OutMKYSTrxRef)).HasColumnName("OUTMKYSTRX").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.InMKYSTrx).WithOne().HasForeignKey<AtlasModel.MKYSTrxDetail>(x => x.InMKYSTrxRef).IsRequired(false);
            builder.HasOne(t => t.OutMKYSTrx).WithOne().HasForeignKey<AtlasModel.MKYSTrxDetail>(x => x.OutMKYSTrxRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}