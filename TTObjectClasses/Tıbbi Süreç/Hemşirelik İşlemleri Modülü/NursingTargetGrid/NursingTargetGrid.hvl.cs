
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingTargetGrid")] 

    public  partial class NursingTargetGrid : TTObject
    {
        public class NursingTargetGridList : TTObjectCollection<NursingTargetGrid> { }
                    
        public class ChildNursingTargetGridCollection : TTObject.TTChildObjectCollection<NursingTargetGrid>
        {
            public ChildNursingTargetGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingTargetGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hemşirelik Hedef
    /// </summary>
        public NursingTargetDefinition NursingTarget
        {
            get { return (NursingTargetDefinition)((ITTObject)this).GetParent("NURSINGTARGET"); }
            set { this["NURSINGTARGET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public NursingCare NursingNanda
        {
            get { return (NursingCare)((ITTObject)this).GetParent("NURSINGNANDA"); }
            set { this["NURSINGNANDA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingTargetGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingTargetGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingTargetGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingTargetGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingTargetGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGTARGETGRID", dataRow) { }
        protected NursingTargetGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGTARGETGRID", dataRow, isImported) { }
        public NursingTargetGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingTargetGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingTargetGrid() : base() { }

    }
}