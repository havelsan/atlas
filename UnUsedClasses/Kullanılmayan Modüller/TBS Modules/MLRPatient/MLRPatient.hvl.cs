
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MLRPatient")] 

    /// <summary>
    /// Hasta
    /// </summary>
    public  partial class MLRPatient : Patient
    {
        public class MLRPatientList : TTObjectCollection<MLRPatient> { }
                    
        public class ChildMLRPatientCollection : TTObject.TTChildObjectCollection<MLRPatient>
        {
            public ChildMLRPatientCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMLRPatientCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MLRPatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MLRPatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MLRPatient(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MLRPatient(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MLRPatient(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MLRPATIENT", dataRow) { }
        protected MLRPatient(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MLRPATIENT", dataRow, isImported) { }
        public MLRPatient(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MLRPatient(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MLRPatient() : base() { }

    }
}