
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientDrugTransaction")] 

    /// <summary>
    /// Hasta İlaç Hareketleri
    /// </summary>
    public  partial class PatientDrugTransaction : TTObject
    {
        public class PatientDrugTransactionList : TTObjectCollection<PatientDrugTransaction> { }
                    
        public class ChildPatientDrugTransactionCollection : TTObject.TTChildObjectCollection<PatientDrugTransaction>
        {
            public ChildPatientDrugTransactionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientDrugTransactionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientDrugTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientDrugTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientDrugTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientDrugTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientDrugTransaction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTDRUGTRANSACTION", dataRow) { }
        protected PatientDrugTransaction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTDRUGTRANSACTION", dataRow, isImported) { }
        public PatientDrugTransaction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientDrugTransaction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientDrugTransaction() : base() { }

    }
}