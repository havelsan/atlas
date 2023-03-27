
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
namespace TTObjectClasses
{
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DistributeDetail")] 

    /// <summary>
    /// Dağıtılmış Reçeteler Sekmesi
    /// </summary>
    public  partial class DistributeDetail : TTObject
    {
        public class DistributeDetailList : TTObjectCollection<DistributeDetail> { }
                    
        public class ChildDistributeDetailCollection : TTObject.TTChildObjectCollection<DistributeDetail>
        {
            public ChildDistributeDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDistributeDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Karantina No
    /// </summary>
        public long? PatientQuarantineNo
        {
            get { return (long?)this["PATIENTQUARANTINENO"]; }
            set { this["PATIENTQUARANTINENO"] = value; }
        }

    /// <summary>
    /// Ücret
    /// </summary>
        public BigCurrency? Price
        {
            get { return (BigCurrency?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public long? PatientProtocolNo
        {
            get { return (long?)this["PATIENTPROTOCOLNO"]; }
            set { this["PATIENTPROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Hasta Adı Soyadı
    /// </summary>
        public string PatientName
        {
            get { return (string)this["PATIENTNAME"]; }
            set { this["PATIENTNAME"] = value; }
        }

        public ExternalPharmacy ExternalPharmacy
        {
            get { return (ExternalPharmacy)((ITTObject)this).GetParent("EXTERNALPHARMACY"); }
            set { this["EXTERNALPHARMACY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Prescription Prescription
        {
            get { return (Prescription)((ITTObject)this).GetParent("PRESCRIPTION"); }
            set { this["PRESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PrescriptionDistribute PrescriptionDistribute
        {
            get { return (PrescriptionDistribute)((ITTObject)this).GetParent("PRESCRIPTIONDISTRIBUTE"); }
            set { this["PRESCRIPTIONDISTRIBUTE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DistributeDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DistributeDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DistributeDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DistributeDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DistributeDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISTRIBUTEDETAIL", dataRow) { }
        protected DistributeDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISTRIBUTEDETAIL", dataRow, isImported) { }
        public DistributeDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DistributeDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DistributeDetail() : base() { }

    }
}