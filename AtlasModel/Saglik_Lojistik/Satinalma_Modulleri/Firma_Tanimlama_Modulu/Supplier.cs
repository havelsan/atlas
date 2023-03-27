using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Supplier
    {
        public Guid ObjectId { get; set; }
        public string Note { get; set; }
        public SupplierTypeEnum? Type { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string TaxOfficeName { get; set; }
        public string Name { get; set; }
        public string TaxNo { get; set; }
        public string Fax { get; set; }
        public string Telephone { get; set; }
        public string RelatedPerson { get; set; }
        public long? Code { get; set; }
        public string Name_Shadow { get; set; }
        public string GLNNo { get; set; }
        public ActivityTypeEnum? ActivityType { get; set; }
        public string SupplierNumber { get; set; }
        public long? FirmIdentifierNo { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}