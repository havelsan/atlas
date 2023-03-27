using System;
using System.Collections.Generic;
using TTDataDictionary;

namespace Core.Models
{
    public class SupplierAndProducerViewModel
    {

    }

    public class SupplierAndProcedureDataSource
    {
        public List<SuppliersAndProducer> suppliersAndProducers { get; set; }
    }

    public class SuppliersAndProducer
    {
        public Guid ObjectID { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Tax { get; set; }
    }

    public class InputDVO
    {
        public Guid objectID { get; set; }
        public int intType { get; set; }
        public bool isActive { get; set; }
        public string FirmName { get; set; }
        public string FirmGLNNo { get; set; }
        public string FirmTaxNo { get; set; }
        public string FirmEmail { get; set; }
        public string FirmAddress { get; set; }
        public string FirmNote { get; set; }
        public string FirmTaxOfficeName { get; set; }
        public string FirmTelephone { get; set; }
        public string FirmFax { get; set; }
        public int Code { get; set; }
        public string FirmIdentifierNo { get; set; }
    }

}
