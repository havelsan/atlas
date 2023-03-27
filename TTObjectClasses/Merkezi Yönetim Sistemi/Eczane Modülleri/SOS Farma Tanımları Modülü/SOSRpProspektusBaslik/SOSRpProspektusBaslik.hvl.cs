
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SOSRpProspektusBaslik")] 

    public  partial class SOSRpProspektusBaslik : TerminologyManagerDef
    {
        public class SOSRpProspektusBaslikList : TTObjectCollection<SOSRpProspektusBaslik> { }
                    
        public class ChildSOSRpProspektusBaslikCollection : TTObject.TTChildObjectCollection<SOSRpProspektusBaslik>
        {
            public ChildSOSRpProspektusBaslikCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSOSRpProspektusBaslikCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public long? SOSID
        {
            get { return (long?)this["SOSID"]; }
            set { this["SOSID"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public long? SOSALTID
        {
            get { return (long?)this["SOSALTID"]; }
            set { this["SOSALTID"] = value; }
        }

        public string KubKt
        {
            get { return (string)this["KUBKT"]; }
            set { this["KUBKT"] = value; }
        }

        protected SOSRpProspektusBaslik(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SOSRpProspektusBaslik(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SOSRpProspektusBaslik(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SOSRpProspektusBaslik(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SOSRpProspektusBaslik(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOSRPPROSPEKTUSBASLIK", dataRow) { }
        protected SOSRpProspektusBaslik(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOSRPPROSPEKTUSBASLIK", dataRow, isImported) { }
        public SOSRpProspektusBaslik(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SOSRpProspektusBaslik(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SOSRpProspektusBaslik() : base() { }

    }
}