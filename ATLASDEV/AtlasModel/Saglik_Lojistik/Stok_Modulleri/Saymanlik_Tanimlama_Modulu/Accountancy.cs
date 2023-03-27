using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Accountancy
    {
        public Guid ObjectId { get; set; }
        public string QREF { get; set; }
        public string AccountancyCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AccountancyNO { get; set; }
        public bool? IsNonBarcode { get; set; }
        public string Name_Shadow { get; set; }
        public string QREF_Shadow { get; set; }
        public string GLNNo { get; set; }
        public Guid? AccountancyMilitaryUnitRef { get; set; }
        public Guid? UnitStoreGetDataRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}