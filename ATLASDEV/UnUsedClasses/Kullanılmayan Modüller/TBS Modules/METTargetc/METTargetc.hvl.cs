
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="METTargetc")] 

    /// <summary>
    /// Hedef
    /// </summary>
    public  partial class METTargetc : TTObject
    {
        public class METTargetcList : TTObjectCollection<METTargetc> { }
                    
        public class ChildMETTargetcCollection : TTObject.TTChildObjectCollection<METTargetc>
        {
            public ChildMETTargetcCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMETTargetcCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tür
    /// </summary>
        public int? Type
        {
            get { return (int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected METTargetc(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected METTargetc(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected METTargetc(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected METTargetc(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected METTargetc(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "METTARGETC", dataRow) { }
        protected METTargetc(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "METTARGETC", dataRow, isImported) { }
        public METTargetc(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public METTargetc(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public METTargetc() : base() { }

    }
}