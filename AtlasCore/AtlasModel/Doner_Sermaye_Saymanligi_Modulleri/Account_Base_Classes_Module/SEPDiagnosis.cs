using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SEPDiagnosis
    {
        public Guid ObjectId { get; set; }
        public long? Id { get; set; }
        public string MedulaProcessNo { get; set; }
        public bool? IsMainDiagnose { get; set; }
        public DiagnosisTypeEnum? DiagnosisType { get; set; }
        public string MedulaResultCode { get; set; }
        public string MedulaResultMessage { get; set; }
        public Guid? DiagnoseRef { get; set; }
        public Guid? DiagnosisGridRef { get; set; }
        public Guid? SubEpisodeProtocolRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? DiagnosisSubEpisodeRef { get; set; }

        #region Parent Relations
        public virtual DiagnosisDefinition Diagnose { get; set; }
        public virtual DiagnosisGrid DiagnosisGrid { get; set; }
        public virtual SubEpisodeProtocol SubEpisodeProtocol { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual DiagnosisSubEpisode DiagnosisSubEpisode { get; set; }
        #endregion Parent Relations
    }
}