using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EpisodeFolderTransactionConfig : IEntityTypeConfiguration<AtlasModel.EpisodeFolderTransaction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EpisodeFolderTransaction> builder)
        {
            builder.ToTable("EPISODEFOLDERTRANSACTION");
            builder.HasKey(nameof(AtlasModel.EpisodeFolderTransaction.ObjectId));
            builder.Property(nameof(AtlasModel.EpisodeFolderTransaction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EpisodeFolderTransaction.TransactionDate)).HasColumnName("TRANSACTIONDATE");
            builder.Property(nameof(AtlasModel.EpisodeFolderTransaction.TransactionID)).HasColumnName("TRANSACTIONID");
            builder.Property(nameof(AtlasModel.EpisodeFolderTransaction.TransactionType)).HasColumnName("TRANSACTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EpisodeFolderTransaction.EpisodeFolderLocationRef)).HasColumnName("EPISODEFOLDERLOCATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeFolderTransaction.EpisodeFolderRef)).HasColumnName("EPISODEFOLDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.EpisodeFolderTransaction.TransactionUserRef)).HasColumnName("TRANSACTIONUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.EpisodeFolderLocation).WithOne().HasForeignKey<AtlasModel.EpisodeFolderTransaction>(x => x.EpisodeFolderLocationRef).IsRequired(false);
            builder.HasOne(t => t.EpisodeFolder).WithOne().HasForeignKey<AtlasModel.EpisodeFolderTransaction>(x => x.EpisodeFolderRef).IsRequired(false);
            builder.HasOne(t => t.TransactionUser).WithOne().HasForeignKey<AtlasModel.EpisodeFolderTransaction>(x => x.TransactionUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}