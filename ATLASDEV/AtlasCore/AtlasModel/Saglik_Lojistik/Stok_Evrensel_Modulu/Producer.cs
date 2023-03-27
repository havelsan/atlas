using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Producer
    {
        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public long? SPTSProducerID { get; set; }
        public string Name_Shadow { get; set; }
        public long? Code { get; set; }
        public long? VademecumID { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string TaxNo { get; set; }
        public string SupplierNumber { get; set; }
        public string TaxOfficeName { get; set; }
        public string Telephone { get; set; }
        public string Note { get; set; }
        public string GLNNo { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}