
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSWatchExcuse")] 

    /// <summary>
    /// Nöbet Mazeret
    /// </summary>
    public  partial class MPBSWatchExcuse : TTObject
    {
        public class MPBSWatchExcuseList : TTObjectCollection<MPBSWatchExcuse> { }
                    
        public class ChildMPBSWatchExcuseCollection : TTObject.TTChildObjectCollection<MPBSWatchExcuse>
        {
            public ChildMPBSWatchExcuseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSWatchExcuseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected MPBSWatchExcuse(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSWatchExcuse(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSWatchExcuse(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSWatchExcuse(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSWatchExcuse(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSWATCHEXCUSE", dataRow) { }
        protected MPBSWatchExcuse(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSWATCHEXCUSE", dataRow, isImported) { }
        public MPBSWatchExcuse(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSWatchExcuse(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSWatchExcuse() : base() { }

    }
}