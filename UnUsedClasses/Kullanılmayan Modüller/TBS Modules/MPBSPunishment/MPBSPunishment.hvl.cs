
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSPunishment")] 

    public  partial class MPBSPunishment : MPBSDisciplineRegistration
    {
        public class MPBSPunishmentList : TTObjectCollection<MPBSPunishment> { }
                    
        public class ChildMPBSPunishmentCollection : TTObject.TTChildObjectCollection<MPBSPunishment>
        {
            public ChildMPBSPunishmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSPunishmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Personel
    /// </summary>
        public MPBSPersonnel Personnel
        {
            get { return (MPBSPersonnel)((ITTObject)this).GetParent("PERSONNEL"); }
            set { this["PERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSPunishment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSPunishment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSPunishment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSPunishment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSPunishment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSPUNISHMENT", dataRow) { }
        protected MPBSPunishment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSPUNISHMENT", dataRow, isImported) { }
        public MPBSPunishment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSPunishment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSPunishment() : base() { }

    }
}