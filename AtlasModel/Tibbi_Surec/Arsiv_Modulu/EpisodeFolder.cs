using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EpisodeFolder
    {
        public Guid ObjectId { get; set; }
        public bool? FolderStatus { get; set; }
        public string EpisodeFolderID { get; set; }
        public string FolderInformation { get; set; }
        public string ManuelArchiveNo { get; set; }
        public Guid? PatientFolderRef { get; set; }
        public Guid? EpisodeFolderLocationRef { get; set; }
        public Guid? LastEpisodeFolderTransactionRef { get; set; }
        public Guid? FileCreationAndAnalysisRef { get; set; }
        public Guid? MyEpisodeRef { get; set; }

        #region Parent Relations
        public virtual PatientFolder PatientFolder { get; set; }
        public virtual ResSection EpisodeFolderLocation { get; set; }
        public virtual EpisodeFolderTransaction LastEpisodeFolderTransaction { get; set; }
        public virtual FileCreationAndAnalysis FileCreationAndAnalysis { get; set; }
        public virtual Episode MyEpisode { get; set; }
        #endregion Parent Relations
    }
}