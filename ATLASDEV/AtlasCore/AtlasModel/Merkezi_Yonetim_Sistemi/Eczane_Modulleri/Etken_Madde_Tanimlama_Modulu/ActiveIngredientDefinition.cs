using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ActiveIngredientDefinition
    {
        public Guid ObjectId { get; set; }
        public string QREF { get; set; }
        public string NATOStockNO { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public long? SPTSActiveIngredientID { get; set; }
        public string Name_Shadow { get; set; }
        public double? MaxDose { get; set; }
        public Guid? MaxDoseUnitRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}