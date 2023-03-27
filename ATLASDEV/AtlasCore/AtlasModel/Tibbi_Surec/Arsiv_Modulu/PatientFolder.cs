using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientFolder
    {
        public Guid ObjectId { get; set; }
        public long? PatientFolderID { get; set; }
        public string Shelf { get; set; }
        public FolderStatusEnum? FolderStatus { get; set; }
        public string Row { get; set; }
        public Guid? LastPatientFolderTransactionRef { get; set; }
        public Guid? FolderLocationRef { get; set; }
        public Guid? BuildingRef { get; set; }

        #region Parent Relations
        public virtual PatientFolderTransaction LastPatientFolderTransaction { get; set; }
        public virtual ResSection FolderLocation { get; set; }
        #endregion Parent Relations
    }
}