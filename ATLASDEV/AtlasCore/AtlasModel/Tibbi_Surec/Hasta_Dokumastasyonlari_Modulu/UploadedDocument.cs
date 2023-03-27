using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class UploadedDocument
    {
        public Guid ObjectId { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Explanation { get; set; }
        public UploadedDocumentType? DocumentType { get; set; }
        public Guid? File { get; set; }
        public string FileName { get; set; }
        public Guid? EpisodeRef { get; set; }

        #region Parent Relations
        public virtual Episode Episode { get; set; }
        #endregion Parent Relations
    }
}