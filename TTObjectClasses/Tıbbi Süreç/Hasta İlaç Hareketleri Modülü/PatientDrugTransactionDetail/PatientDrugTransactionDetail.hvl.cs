
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientDrugTransactionDetail")] 

    public  partial class PatientDrugTransactionDetail : TTObject
    {
        public class PatientDrugTransactionDetailList : TTObjectCollection<PatientDrugTransactionDetail> { }
                    
        public class ChildPatientDrugTransactionDetailCollection : TTObject.TTChildObjectCollection<PatientDrugTransactionDetail>
        {
            public ChildPatientDrugTransactionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientDrugTransactionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public PatientDrugTransaction PatientDrugTransaction
        {
            get { return (PatientDrugTransaction)((ITTObject)this).GetParent("PATIENTDRUGTRANSACTION"); }
            set { this["PATIENTDRUGTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientDrugTransactionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientDrugTransactionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientDrugTransactionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientDrugTransactionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientDrugTransactionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTDRUGTRANSACTIONDETAIL", dataRow) { }
        protected PatientDrugTransactionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTDRUGTRANSACTIONDETAIL", dataRow, isImported) { }
        public PatientDrugTransactionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientDrugTransactionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientDrugTransactionDetail() : base() { }

    }
}