
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingReasonGrid")] 

    public  partial class NursingReasonGrid : TTObject
    {
        public class NursingReasonGridList : TTObjectCollection<NursingReasonGrid> { }
                    
        public class ChildNursingReasonGridCollection : TTObject.TTChildObjectCollection<NursingReasonGrid>
        {
            public ChildNursingReasonGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingReasonGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hemşirelik Neden
    /// </summary>
        public NursingReasonDefinition NursingReason
        {
            get { return (NursingReasonDefinition)((ITTObject)this).GetParent("NURSINGREASON"); }
            set { this["NURSINGREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public NursingCare NursingNanda
        {
            get { return (NursingCare)((ITTObject)this).GetParent("NURSINGNANDA"); }
            set { this["NURSINGNANDA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingReasonGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingReasonGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingReasonGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingReasonGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingReasonGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGREASONGRID", dataRow) { }
        protected NursingReasonGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGREASONGRID", dataRow, isImported) { }
        public NursingReasonGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingReasonGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingReasonGrid() : base() { }

    }
}