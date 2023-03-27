
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PAActionTypeObject")] 

    public  partial class PAActionTypeObject : TTObject
    {
        public class PAActionTypeObjectList : TTObjectCollection<PAActionTypeObject> { }
                    
        public class ChildPAActionTypeObjectCollection : TTObject.TTChildObjectCollection<PAActionTypeObject>
        {
            public ChildPAActionTypeObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPAActionTypeObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Başlatılacak işlem
    /// </summary>
        public ActionTypeEnum? ActionType
        {
            get { return (ActionTypeEnum?)(int?)this["ACTIONTYPE"]; }
            set { this["ACTIONTYPE"] = value; }
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

        protected PAActionTypeObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PAActionTypeObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PAActionTypeObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PAActionTypeObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PAActionTypeObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAACTIONTYPEOBJECT", dataRow) { }
        protected PAActionTypeObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAACTIONTYPEOBJECT", dataRow, isImported) { }
        public PAActionTypeObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PAActionTypeObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PAActionTypeObject() : base() { }

    }
}