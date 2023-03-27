
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MNZPatient")] 

    /// <summary>
    /// Hasta
    /// </summary>
    public  partial class MNZPatient : Patient
    {
        public class MNZPatientList : TTObjectCollection<MNZPatient> { }
                    
        public class ChildMNZPatientCollection : TTObject.TTChildObjectCollection<MNZPatient>
        {
            public ChildMNZPatientCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMNZPatientCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MNZPatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MNZPatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MNZPatient(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MNZPatient(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MNZPatient(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MNZPATIENT", dataRow) { }
        protected MNZPatient(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MNZPATIENT", dataRow, isImported) { }
        public MNZPatient(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MNZPatient(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MNZPatient() : base() { }

    }
}