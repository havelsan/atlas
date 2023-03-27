
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TreatmentDischarge_MatterSliceAnectodeGrid")] 

    public  partial class TreatmentDischarge_MatterSliceAnectodeGrid : MatterSliceAnectodeGrid
    {
        public class TreatmentDischarge_MatterSliceAnectodeGridList : TTObjectCollection<TreatmentDischarge_MatterSliceAnectodeGrid> { }
                    
        public class ChildTreatmentDischarge_MatterSliceAnectodeGridCollection : TTObject.TTChildObjectCollection<TreatmentDischarge_MatterSliceAnectodeGrid>
        {
            public ChildTreatmentDischarge_MatterSliceAnectodeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTreatmentDischarge_MatterSliceAnectodeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public TreatmentDischarge TreatmentDischarge
        {
            get { return (TreatmentDischarge)((ITTObject)this).GetParent("TREATMENTDISCHARGE"); }
            set { this["TREATMENTDISCHARGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TreatmentDischarge_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TreatmentDischarge_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TreatmentDischarge_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TreatmentDischarge_MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TreatmentDischarge_MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TREATMENTDISCHARGE_MATTERSLICEANECTODEGRID", dataRow) { }
        protected TreatmentDischarge_MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TREATMENTDISCHARGE_MATTERSLICEANECTODEGRID", dataRow, isImported) { }
        public TreatmentDischarge_MatterSliceAnectodeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TreatmentDischarge_MatterSliceAnectodeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TreatmentDischarge_MatterSliceAnectodeGrid() : base() { }

    }
}