
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="METTarget")] 

    /// <summary>
    /// Hedef
    /// </summary>
    public  partial class METTarget : TTDefinitionSet
    {
        public class METTargetList : TTObjectCollection<METTarget> { }
                    
        public class ChildMETTargetCollection : TTObject.TTChildObjectCollection<METTarget>
        {
            public ChildMETTargetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMETTargetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// ID
    /// </summary>
        public int? ID
        {
            get { return (int?)this["ID"]; }
            set { this["ID"] = value; }
        }

    /// <summary>
    /// Tür
    /// </summary>
        public int? Type
        {
            get { return (int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        protected METTarget(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected METTarget(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected METTarget(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected METTarget(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected METTarget(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "METTARGET", dataRow) { }
        protected METTarget(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "METTARGET", dataRow, isImported) { }
        public METTarget(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public METTarget(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public METTarget() : base() { }

    }
}