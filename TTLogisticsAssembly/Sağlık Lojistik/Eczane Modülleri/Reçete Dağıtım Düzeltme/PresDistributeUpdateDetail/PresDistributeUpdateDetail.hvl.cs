
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresDistributeUpdateDetail")] 

    public  partial class PresDistributeUpdateDetail : TTObject
    {
        public class PresDistributeUpdateDetailList : TTObjectCollection<PresDistributeUpdateDetail> { }
                    
        public class ChildPresDistributeUpdateDetailCollection : TTObject.TTChildObjectCollection<PresDistributeUpdateDetail>
        {
            public ChildPresDistributeUpdateDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresDistributeUpdateDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hasta Adı Soyadı
    /// </summary>
        public string PatientName
        {
            get { return (string)this["PATIENTNAME"]; }
            set { this["PATIENTNAME"] = value; }
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
        public double? Price
        {
            get { return (double?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// İptal Et
    /// </summary>
        public bool? IsCancel
        {
            get { return (bool?)this["ISCANCEL"]; }
            set { this["ISCANCEL"] = value; }
        }

        public Prescription Prescription
        {
            get { return (Prescription)((ITTObject)this).GetParent("PRESCRIPTION"); }
            set { this["PRESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ExternalPharmacy ExternalPharmacy
        {
            get { return (ExternalPharmacy)((ITTObject)this).GetParent("EXTERNALPHARMACY"); }
            set { this["EXTERNALPHARMACY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PresDistributeUpdate PresDistributeUpdate
        {
            get { return (PresDistributeUpdate)((ITTObject)this).GetParent("PRESDISTRIBUTEUPDATE"); }
            set { this["PRESDISTRIBUTEUPDATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PresDistributeUpdateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresDistributeUpdateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresDistributeUpdateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresDistributeUpdateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresDistributeUpdateDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESDISTRIBUTEUPDATEDETAIL", dataRow) { }
        protected PresDistributeUpdateDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESDISTRIBUTEUPDATEDETAIL", dataRow, isImported) { }
        public PresDistributeUpdateDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresDistributeUpdateDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresDistributeUpdateDetail() : base() { }

    }
}