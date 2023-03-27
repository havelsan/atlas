
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSMobilization")] 

    /// <summary>
    /// Seferberlik
    /// </summary>
    public  partial class MPBSMobilization : TTObject
    {
        public class MPBSMobilizationList : TTObjectCollection<MPBSMobilization> { }
                    
        public class ChildMPBSMobilizationCollection : TTObject.TTChildObjectCollection<MPBSMobilization>
        {
            public ChildMPBSMobilizationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSMobilizationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Seferberlik No
    /// </summary>
        public int? MobilizationNo
        {
            get { return (int?)this["MOBILIZATIONNO"]; }
            set { this["MOBILIZATIONNO"] = value; }
        }

        protected MPBSMobilization(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSMobilization(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSMobilization(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSMobilization(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSMobilization(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSMOBILIZATION", dataRow) { }
        protected MPBSMobilization(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSMOBILIZATION", dataRow, isImported) { }
        public MPBSMobilization(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSMobilization(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSMobilization() : base() { }

    }
}