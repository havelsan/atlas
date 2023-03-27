
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCProfessors_RedecisionMatterSliceAnectodeGrid")] 

    public  partial class HCProfessors_RedecisionMatterSliceAnectodeGrid : MatterSliceAnectodeGrid
    {
        public class HCProfessors_RedecisionMatterSliceAnectodeGridList : TTObjectCollection<HCProfessors_RedecisionMatterSliceAnectodeGrid> { }
                    
        public class ChildHCProfessors_RedecisionMatterSliceAnectodeGridCollection : TTObject.TTChildObjectCollection<HCProfessors_RedecisionMatterSliceAnectodeGrid>
        {
            public ChildHCProfessors_RedecisionMatterSliceAnectodeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCProfessors_RedecisionMatterSliceAnectodeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public HealthCommitteeOfProfessors HealthCommitteeOfProfessors
        {
            get { return (HealthCommitteeOfProfessors)((ITTObject)this).GetParent("HEALTHCOMMITTEEOFPROFESSORS"); }
            set { this["HEALTHCOMMITTEEOFPROFESSORS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCProfessors_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCProfessors_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCProfessors_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCProfessors_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCProfessors_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCPROFESSORS_REDECISIONMATTERSLICEANECTODEGRID", dataRow) { }
        protected HCProfessors_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCPROFESSORS_REDECISIONMATTERSLICEANECTODEGRID", dataRow, isImported) { }
        public HCProfessors_RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCProfessors_RedecisionMatterSliceAnectodeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCProfessors_RedecisionMatterSliceAnectodeGrid() : base() { }

    }
}