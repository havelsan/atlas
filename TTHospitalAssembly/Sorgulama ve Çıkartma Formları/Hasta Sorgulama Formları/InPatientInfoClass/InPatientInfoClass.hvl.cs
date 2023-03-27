
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InPatientInfoClass")] 

    public  partial class InPatientInfoClass : TTObject
    {
        public class InPatientInfoClassList : TTObjectCollection<InPatientInfoClass> { }
                    
        public class ChildInPatientInfoClassCollection : TTObject.TTChildObjectCollection<InPatientInfoClass>
        {
            public ChildInPatientInfoClassCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInPatientInfoClassCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected InPatientInfoClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InPatientInfoClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InPatientInfoClass(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InPatientInfoClass(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InPatientInfoClass(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTINFOCLASS", dataRow) { }
        protected InPatientInfoClass(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTINFOCLASS", dataRow, isImported) { }
        public InPatientInfoClass(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InPatientInfoClass(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InPatientInfoClass() : base() { }

    }
}