
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InfectionApprovalDrugOrder")] 

    public  partial class InfectionApprovalDrugOrder : TTObject
    {
        public class InfectionApprovalDrugOrderList : TTObjectCollection<InfectionApprovalDrugOrder> { }
                    
        public class ChildInfectionApprovalDrugOrderCollection : TTObject.TTChildObjectCollection<InfectionApprovalDrugOrder>
        {
            public ChildInfectionApprovalDrugOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInfectionApprovalDrugOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Gün
    /// </summary>
        public int? Day
        {
            get { return (int?)this["DAY"]; }
            set { this["DAY"] = value; }
        }

    /// <summary>
    /// Doz Miktarı
    /// </summary>
        public double? DoseAmount
        {
            get { return (double?)this["DOSEAMOUNT"]; }
            set { this["DOSEAMOUNT"] = value; }
        }

    /// <summary>
    /// Doz Aralığı
    /// </summary>
        public FrequencyEnum? Frequency
        {
            get { return (FrequencyEnum?)(int?)this["FREQUENCY"]; }
            set { this["FREQUENCY"] = value; }
        }

    /// <summary>
    /// Kullanma Açıklaması
    /// </summary>
        public string UsageNote
        {
            get { return (string)this["USAGENOTE"]; }
            set { this["USAGENOTE"] = value; }
        }

    /// <summary>
    /// Paket Adedi
    /// </summary>
        public double? PackageAmount
        {
            get { return (double?)this["PACKAGEAMOUNT"]; }
            set { this["PACKAGEAMOUNT"] = value; }
        }

        public InpatientPrescription InpatientPrescription
        {
            get { return (InpatientPrescription)((ITTObject)this).GetParent("INPATIENTPRESCRIPTION"); }
            set { this["INPATIENTPRESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InpatientDrugOrder InpatientDrugOrder
        {
            get { return (InpatientDrugOrder)((ITTObject)this).GetParent("INPATIENTDRUGORDER"); }
            set { this["INPATIENTDRUGORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InfectionApprovalDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InfectionApprovalDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InfectionApprovalDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InfectionApprovalDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InfectionApprovalDrugOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INFECTIONAPPROVALDRUGORDER", dataRow) { }
        protected InfectionApprovalDrugOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INFECTIONAPPROVALDRUGORDER", dataRow, isImported) { }
        public InfectionApprovalDrugOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InfectionApprovalDrugOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InfectionApprovalDrugOrder() : base() { }

    }
}