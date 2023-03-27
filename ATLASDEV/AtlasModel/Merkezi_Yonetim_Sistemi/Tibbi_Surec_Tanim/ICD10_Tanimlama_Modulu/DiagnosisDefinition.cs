using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DiagnosisDefinition
    {
        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Level { get; set; }
        public bool? SendBulasiciHastalikBildirim { get; set; }
        public bool? CausesMotherDeath { get; set; }
        public int? Precision { get; set; }
        public bool? IsLeaf { get; set; }
        public string Code { get; set; }
        public string Code_Shadow { get; set; }
        public string KamaStar { get; set; }
        public bool? CausesDeath { get; set; }
        public string ParentGroupCode { get; set; }
        public bool? DialysisReportNotMust { get; set; }
        public InfectiousIllnesesInformationGroup? InfectiousIllnesesInfoGroup { get; set; }
        public FTRDiagnosisGroupEnum? FtrDiagnoseGroup { get; set; }
        public string Name_Shadow { get; set; }
        public bool? IsInfluenzaDiagnos { get; set; }
        public Guid? ParentGroupRef { get; set; }
        public Guid? EMClinicDecisionQuideDefRef { get; set; }
        public Guid? TeshisRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual DiagnosisDefinition ParentGroup { get; set; }
        #endregion Parent Relations
    }
}