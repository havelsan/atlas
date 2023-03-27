
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HospitalInformation")] 

    public  partial class HospitalInformation : BaseAction
    {
        public class HospitalInformationList : TTObjectCollection<HospitalInformation> { }
                    
        public class ChildHospitalInformationCollection : TTObject.TTChildObjectCollection<HospitalInformation>
        {
            public ChildHospitalInformationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHospitalInformationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public PatientVisitor PatientVisitor
        {
            get { return (PatientVisitor)((ITTObject)this).GetParent("PATIENTVISITOR"); }
            set { this["PATIENTVISITOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HospitalInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HospitalInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HospitalInformation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HospitalInformation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HospitalInformation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HOSPITALINFORMATION", dataRow) { }
        protected HospitalInformation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HOSPITALINFORMATION", dataRow, isImported) { }
        public HospitalInformation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HospitalInformation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HospitalInformation() : base() { }

    }
}