
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PsychologyAuthorizedUser")] 

    public  partial class PsychologyAuthorizedUser : TTObject
    {
        public class PsychologyAuthorizedUserList : TTObjectCollection<PsychologyAuthorizedUser> { }
                    
        public class ChildPsychologyAuthorizedUserCollection : TTObject.TTChildObjectCollection<PsychologyAuthorizedUser>
        {
            public ChildPsychologyAuthorizedUserCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPsychologyAuthorizedUserCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public PsychologyBasedObject PsychologyBasedObject
        {
            get { return (PsychologyBasedObject)((ITTObject)this).GetParent("PSYCHOLOGYBASEDOBJECT"); }
            set { this["PSYCHOLOGYBASEDOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PsychologyAuthorizedUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PsychologyAuthorizedUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PsychologyAuthorizedUser(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PsychologyAuthorizedUser(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PsychologyAuthorizedUser(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PSYCHOLOGYAUTHORIZEDUSER", dataRow) { }
        protected PsychologyAuthorizedUser(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PSYCHOLOGYAUTHORIZEDUSER", dataRow, isImported) { }
        public PsychologyAuthorizedUser(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PsychologyAuthorizedUser(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PsychologyAuthorizedUser() : base() { }

    }
}