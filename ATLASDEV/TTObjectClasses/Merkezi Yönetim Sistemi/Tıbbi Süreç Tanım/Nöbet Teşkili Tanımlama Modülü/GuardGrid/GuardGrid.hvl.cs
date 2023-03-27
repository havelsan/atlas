
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GuardGrid")] 

    /// <summary>
    /// Nöbetçiler
    /// </summary>
    public  partial class GuardGrid : TTObject
    {
        public class GuardGridList : TTObjectCollection<GuardGrid> { }
                    
        public class ChildGuardGridCollection : TTObject.TTChildObjectCollection<GuardGrid>
        {
            public ChildGuardGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGuardGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Görevi
    /// </summary>
        public string Job
        {
            get { return (string)this["JOB"]; }
            set { this["JOB"] = value; }
        }

    /// <summary>
    /// resUserGuard
    /// </summary>
        public ResUser UserGuard
        {
            get { return (ResUser)((ITTObject)this).GetParent("USERGUARD"); }
            set { this["USERGUARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// GuardFormationDefinitionGuard
    /// </summary>
        public GuardFormationDefinition GuardFormationDefinition
        {
            get { return (GuardFormationDefinition)((ITTObject)this).GetParent("GUARDFORMATIONDEFINITION"); }
            set { this["GUARDFORMATIONDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected GuardGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GuardGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GuardGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GuardGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GuardGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GUARDGRID", dataRow) { }
        protected GuardGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GUARDGRID", dataRow, isImported) { }
        protected GuardGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GuardGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GuardGrid() : base() { }

    }
}