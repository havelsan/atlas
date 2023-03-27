
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrOutPatientPrescription")] 

    /// <summary>
    /// Ayaktan Hasta Reçetesi
    /// </summary>
    public  partial class ehrOutPatientPrescription : ehrEpisodeAction
    {
        public class ehrOutPatientPrescriptionList : TTObjectCollection<ehrOutPatientPrescription> { }
                    
        public class ChildehrOutPatientPrescriptionCollection : TTObject.TTChildObjectCollection<ehrOutPatientPrescription>
        {
            public ChildehrOutPatientPrescriptionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrOutPatientPrescriptionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Provizyon Açıklama
    /// </summary>
        public string SPTSProvisionDesc
        {
            get { return (string)this["SPTSPROVISIONDESC"]; }
            set { this["SPTSPROVISIONDESC"] = value; }
        }

    /// <summary>
    /// Serbest Tanı
    /// </summary>
        public string FreeDiagnosis
        {
            get { return (string)this["FREEDIAGNOSIS"]; }
            set { this["FREEDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Makbuz Numarası
    /// </summary>
        public string ReceiptNO
        {
            get { return (string)this["RECEIPTNO"]; }
            set { this["RECEIPTNO"] = value; }
        }

        virtual protected void CreateehrOutPatientDrugOrderCollection()
        {
            _ehrOutPatientDrugOrder = new ehrOutPatientDrugOrder.ChildehrOutPatientDrugOrderCollection(this, new Guid("933be9d4-909a-4eb5-bf5b-f7d378698264"));
            ((ITTChildObjectCollection)_ehrOutPatientDrugOrder).GetChildren();
        }

        protected ehrOutPatientDrugOrder.ChildehrOutPatientDrugOrderCollection _ehrOutPatientDrugOrder = null;
    /// <summary>
    /// Child collection for Ayaktan Hasta Reçetesi-İlaçlar
    /// </summary>
        public ehrOutPatientDrugOrder.ChildehrOutPatientDrugOrderCollection ehrOutPatientDrugOrder
        {
            get
            {
                if (_ehrOutPatientDrugOrder == null)
                    CreateehrOutPatientDrugOrderCollection();
                return _ehrOutPatientDrugOrder;
            }
        }

        protected ehrOutPatientPrescription(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrOutPatientPrescription(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrOutPatientPrescription(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrOutPatientPrescription(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrOutPatientPrescription(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHROUTPATIENTPRESCRIPTION", dataRow) { }
        protected ehrOutPatientPrescription(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHROUTPATIENTPRESCRIPTION", dataRow, isImported) { }
        public ehrOutPatientPrescription(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrOutPatientPrescription(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrOutPatientPrescription() : base() { }

    }
}