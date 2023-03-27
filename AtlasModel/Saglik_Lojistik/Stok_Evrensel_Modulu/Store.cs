using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Store
    {
        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? ID { get; set; }
        public OpenCloseEnum? Status { get; set; }
        public string QREF { get; set; }
        public string Name_Shadow { get; set; }
        public bool? AutoReturningDocumentCreat { get; set; }
        public bool? MkysStore { get; set; }
        public bool? IsEmergencyStore { get; set; }
        public Guid? UnitStoreGetDataRef { get; set; }
    }
}