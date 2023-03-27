
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SOSUrunAtc")] 

    public  partial class SOSUrunAtc : TerminologyManagerDef
    {
        public class SOSUrunAtcList : TTObjectCollection<SOSUrunAtc> { }
                    
        public class ChildSOSUrunAtcCollection : TTObject.TTChildObjectCollection<SOSUrunAtc>
        {
            public ChildSOSUrunAtcCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSOSUrunAtcCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SOSAtc SOSAtc
        {
            get { return (SOSAtc)((ITTObject)this).GetParent("SOSATC"); }
            set { this["SOSATC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SOSUrunBilgisi SOSUrunBilgisi
        {
            get { return (SOSUrunBilgisi)((ITTObject)this).GetParent("SOSURUNBILGISI"); }
            set { this["SOSURUNBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SOSUrunAtc(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SOSUrunAtc(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SOSUrunAtc(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SOSUrunAtc(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SOSUrunAtc(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOSURUNATC", dataRow) { }
        protected SOSUrunAtc(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOSURUNATC", dataRow, isImported) { }
        public SOSUrunAtc(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SOSUrunAtc(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SOSUrunAtc() : base() { }

    }
}