
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeOfProfessors_MatterSliceAnectodeGrid")] 

    public  partial class HealthCommitteeOfProfessors_MatterSliceAnectodeGrid : MatterSliceAnectodeGrid
    {
        public class HealthCommitteeOfProfessors_MatterSliceAnectodeGridList : TTObjectCollection<HealthCommitteeOfProfessors_MatterSliceAnectodeGrid> { }
                    
        public class ChildHealthCommitteeOfProfessors_MatterSliceAnectodeGridCollection : TTObject.TTChildObjectCollection<HealthCommitteeOfProfessors_MatterSliceAnectodeGrid>
        {
            public ChildHealthCommitteeOfProfessors_MatterSliceAnectodeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeOfProfessors_MatterSliceAnectodeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public HealthCommitteeOfProfessors HealthCommitteeOfProfessors
        {
            get { return (HealthCommitteeOfProfessors)((ITTObject)this).GetParent("HEALTHCOMMITTEEOFPROFESSORS"); }
            set { this["HEALTHCOMMITTEEOFPROFESSORS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HealthCommitteeOfProfessors_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeOfProfessors_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeOfProfessors_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeOfProfessors_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeOfProfessors_MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEOFPROFESSORS_MATTERSLICEANECTODEGRID", dataRow) { }
        protected HealthCommitteeOfProfessors_MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEOFPROFESSORS_MATTERSLICEANECTODEGRID", dataRow, isImported) { }
        public HealthCommitteeOfProfessors_MatterSliceAnectodeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeOfProfessors_MatterSliceAnectodeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeOfProfessors_MatterSliceAnectodeGrid() : base() { }

    }
}