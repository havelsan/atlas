using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DPDetail
    {
        public Guid ObjectId { get; set; }
        public string GILCode { get; set; }
        public string GILName { get; set; }
        public double? GILPoint { get; set; }
        public double? CalcPoint { get; set; }
        public bool? IsModified { get; set; }
        public DateTime? PerformedDate { get; set; }
        public DPPointType? Type { get; set; }
        public string PateintName { get; set; }
        public string PatientUniqueRefno { get; set; }
        public string ProtocolNo { get; set; }
        public DateTime? PatientBirthDate { get; set; }
        public string RessectionName { get; set; }
        public string PatientStatus { get; set; }
        public string RuleName { get; set; }
        public string RuleDescription { get; set; }
        public double? BeforeModifyPoint { get; set; }
        public Guid? DPMasterRef { get; set; }
        public Guid? SubActionProcedureRef { get; set; }
        public Guid? SubEpisodeRef { get; set; }

        #region Parent Relations
        public virtual DPMaster DPMaster { get; set; }
        public virtual SubActionProcedure SubActionProcedure { get; set; }
        public virtual SubEpisode SubEpisode { get; set; }
        #endregion Parent Relations
    }
}