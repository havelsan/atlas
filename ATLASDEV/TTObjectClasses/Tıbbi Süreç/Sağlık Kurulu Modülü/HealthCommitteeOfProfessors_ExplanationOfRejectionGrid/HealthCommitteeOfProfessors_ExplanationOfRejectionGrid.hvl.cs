
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeOfProfessors_ExplanationOfRejectionGrid")] 

    public  partial class HealthCommitteeOfProfessors_ExplanationOfRejectionGrid : ExplanationOfRejectionGrid
    {
        public class HealthCommitteeOfProfessors_ExplanationOfRejectionGridList : TTObjectCollection<HealthCommitteeOfProfessors_ExplanationOfRejectionGrid> { }
                    
        public class ChildHealthCommitteeOfProfessors_ExplanationOfRejectionGridCollection : TTObject.TTChildObjectCollection<HealthCommitteeOfProfessors_ExplanationOfRejectionGrid>
        {
            public ChildHealthCommitteeOfProfessors_ExplanationOfRejectionGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeOfProfessors_ExplanationOfRejectionGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public HealthCommitteeOfProfessors HealthCommitteeOfProfessors
        {
            get { return (HealthCommitteeOfProfessors)((ITTObject)this).GetParent("HEALTHCOMMITTEEOFPROFESSORS"); }
            set { this["HEALTHCOMMITTEEOFPROFESSORS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HealthCommitteeOfProfessors_ExplanationOfRejectionGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeOfProfessors_ExplanationOfRejectionGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeOfProfessors_ExplanationOfRejectionGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeOfProfessors_ExplanationOfRejectionGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeOfProfessors_ExplanationOfRejectionGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEOFPROFESSORS_EXPLANATIONOFREJECTIONGRID", dataRow) { }
        protected HealthCommitteeOfProfessors_ExplanationOfRejectionGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEOFPROFESSORS_EXPLANATIONOFREJECTIONGRID", dataRow, isImported) { }
        public HealthCommitteeOfProfessors_ExplanationOfRejectionGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeOfProfessors_ExplanationOfRejectionGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeOfProfessors_ExplanationOfRejectionGrid() : base() { }

    }
}