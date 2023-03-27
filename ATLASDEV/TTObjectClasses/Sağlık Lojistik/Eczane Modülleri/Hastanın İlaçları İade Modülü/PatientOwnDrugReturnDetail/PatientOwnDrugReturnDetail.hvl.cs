
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientOwnDrugReturnDetail")] 

    public  partial class PatientOwnDrugReturnDetail : TTObject
    {
        public class PatientOwnDrugReturnDetailList : TTObjectCollection<PatientOwnDrugReturnDetail> { }
                    
        public class ChildPatientOwnDrugReturnDetailCollection : TTObject.TTChildObjectCollection<PatientOwnDrugReturnDetail>
        {
            public ChildPatientOwnDrugReturnDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientOwnDrugReturnDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientOwnDrugReturn PatientOwnDrugReturn
        {
            get { return (PatientOwnDrugReturn)((ITTObject)this).GetParent("PATIENTOWNDRUGRETURN"); }
            set { this["PATIENTOWNDRUGRETURN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientOwnDrugTrx PatientOwnDrugTrx
        {
            get { return (PatientOwnDrugTrx)((ITTObject)this).GetParent("PATIENTOWNDRUGTRX"); }
            set { this["PATIENTOWNDRUGTRX"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientOwnDrugReturnDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientOwnDrugReturnDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientOwnDrugReturnDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientOwnDrugReturnDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientOwnDrugReturnDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTOWNDRUGRETURNDETAIL", dataRow) { }
        protected PatientOwnDrugReturnDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTOWNDRUGRETURNDETAIL", dataRow, isImported) { }
        public PatientOwnDrugReturnDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientOwnDrugReturnDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientOwnDrugReturnDetail() : base() { }

    }
}