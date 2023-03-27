
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PAProcedureObject")] 

    public  partial class PAProcedureObject : TTObject
    {
        public class PAProcedureObjectList : TTObjectCollection<PAProcedureObject> { }
                    
        public class ChildPAProcedureObjectCollection : TTObject.TTChildObjectCollection<PAProcedureObject>
        {
            public ChildPAProcedureObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPAProcedureObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection Resource
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientAdmissionStartedActions PAStartedActions
        {
            get { return (PatientAdmissionStartedActions)((ITTObject)this).GetParent("PASTARTEDACTIONS"); }
            set { this["PASTARTEDACTIONS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection MainResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("MAINRESOURCE"); }
            set { this["MAINRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PAProcedureObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PAProcedureObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PAProcedureObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PAProcedureObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PAProcedureObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAPROCEDUREOBJECT", dataRow) { }
        protected PAProcedureObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAPROCEDUREOBJECT", dataRow, isImported) { }
        public PAProcedureObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PAProcedureObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PAProcedureObject() : base() { }

    }
}