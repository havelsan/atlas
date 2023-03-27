using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientOldDebt
    {
        public Guid ObjectId { get; set; }
        public string OldID { get; set; }
        public decimal? TotalDebt { get; set; }
        public string ProcedureType { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureName { get; set; }
        public string PaymentType { get; set; }
        public decimal? TransactionDebt { get; set; }
        public string OldPatientID { get; set; }
        public DateTime? OldPADate { get; set; }
        public string OldPANo { get; set; }
        public string OldPatientNameSurname { get; set; }
        public string OldUniqueRefNo { get; set; }
        public bool? IsRemoved { get; set; }
        public Guid? OldDebtReceiptDocumentRef { get; set; }
        public Guid? PatientRef { get; set; }
        public Guid? ProcedureDefinitionRef { get; set; }

        #region Parent Relations
        public virtual OldDebtReceiptDocument OldDebtReceiptDocument { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        #endregion Parent Relations
    }
}