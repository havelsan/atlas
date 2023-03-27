using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MedicalResarch
    {
        public Guid ObjectId { get; set; }
        public int? Code { get; set; }
        public int? PatientCount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Desciption { get; set; }
        public decimal? BudgetTotalPrice { get; set; }
        public Guid? MedicalResarchTermDefRef { get; set; }

        #region Parent Relations
        public virtual MedicalResarchTermDef MedicalResarchTermDef { get; set; }
        #endregion Parent Relations
    }
}