
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommittee_RedecisionMatterSliceAnectodeGrid")] 

    public  partial class HealthCommittee_RedecisionMatterSliceAnectodeGrid : MatterSliceAnectodeGrid
    {
        public class HealthCommittee_RedecisionMatterSliceAnectodeGridList : TTObjectCollection<HealthCommittee_RedecisionMatterSliceAnectodeGrid> { }
                    
        public class ChildHealthCommittee_RedecisionMatterSliceAnectodeGridCollection : TTObject.TTChildObjectCollection<HealthCommittee_RedecisionMatterSliceAnectodeGrid>
        {
            public ChildHealthCommittee_RedecisionMatterSliceAnectodeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommittee_RedecisionMatterSliceAnectodeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public HealthCommittee HealthCommittee
        {
            get { return (HealthCommittee)((ITTObject)this).GetParent("HEALTHCOMMITTEE"); }
            set { this["HEALTHCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HealthCommittee_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommittee_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommittee_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommittee_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommittee_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEE_REDECISIONMATTERSLICEANECTODEGRID", dataRow) { }
        protected HealthCommittee_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEE_REDECISIONMATTERSLICEANECTODEGRID", dataRow, isImported) { }
        public HealthCommittee_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommittee_RedecisionMatterSliceAnectodeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommittee_RedecisionMatterSliceAnectodeGrid() : base() { }

    }
}