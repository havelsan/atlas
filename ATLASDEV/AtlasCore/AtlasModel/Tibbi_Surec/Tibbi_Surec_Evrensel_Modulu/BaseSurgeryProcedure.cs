using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseSurgeryProcedure
    {
        public Guid ObjectId { get; set; }
        public SurgeryLeftRight? Position { get; set; }
        public IncisionType? IncisionType { get; set; }
        public Guid? DescriptionOfProcedureObject { get; set; }
        public string ToothNumber { get; set; }
        public bool? ToothAnomaly { get; set; }
        public int? ToothCommitmentNumber { get; set; }
        public DateTime? PackageStartDate { get; set; }
        public DateTime? PackageEndDate { get; set; }
        public string Aciklama { get; set; }
        public Guid? PackageProcedureObjectRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseSurgeryAndManipulationProcedure BaseSurgeryAndManipulationProcedure { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual PackageProcedureDefinition PackageProcedureObject { get; set; }
        #endregion Parent Relations
    }
}