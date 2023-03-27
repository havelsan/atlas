
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LabBaseRepeatReasonDef")] 

    public  partial class LabBaseRepeatReasonDef : LabBaseReasonDef
    {
        public class LabBaseRepeatReasonDefList : TTObjectCollection<LabBaseRepeatReasonDef> { }
                    
        public class ChildLabBaseRepeatReasonDefCollection : TTObject.TTChildObjectCollection<LabBaseRepeatReasonDef>
        {
            public ChildLabBaseRepeatReasonDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLabBaseRepeatReasonDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected LabBaseRepeatReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LabBaseRepeatReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LabBaseRepeatReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LabBaseRepeatReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LabBaseRepeatReasonDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABBASEREPEATREASONDEF", dataRow) { }
        protected LabBaseRepeatReasonDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABBASEREPEATREASONDEF", dataRow, isImported) { }
        public LabBaseRepeatReasonDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LabBaseRepeatReasonDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LabBaseRepeatReasonDef() : base() { }

    }
}