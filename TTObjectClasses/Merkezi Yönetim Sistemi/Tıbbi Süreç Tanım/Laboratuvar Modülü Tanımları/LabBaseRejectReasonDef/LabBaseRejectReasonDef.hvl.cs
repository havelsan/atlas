
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LabBaseRejectReasonDef")] 

    public  partial class LabBaseRejectReasonDef : LabBaseReasonDef
    {
        public class LabBaseRejectReasonDefList : TTObjectCollection<LabBaseRejectReasonDef> { }
                    
        public class ChildLabBaseRejectReasonDefCollection : TTObject.TTChildObjectCollection<LabBaseRejectReasonDef>
        {
            public ChildLabBaseRejectReasonDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLabBaseRejectReasonDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected LabBaseRejectReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LabBaseRejectReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LabBaseRejectReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LabBaseRejectReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LabBaseRejectReasonDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABBASEREJECTREASONDEF", dataRow) { }
        protected LabBaseRejectReasonDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABBASEREJECTREASONDEF", dataRow, isImported) { }
        public LabBaseRejectReasonDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LabBaseRejectReasonDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LabBaseRejectReasonDef() : base() { }

    }
}