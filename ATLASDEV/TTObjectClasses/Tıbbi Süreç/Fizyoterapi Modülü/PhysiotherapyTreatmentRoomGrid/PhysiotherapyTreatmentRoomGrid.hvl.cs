
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PhysiotherapyTreatmentRoomGrid")] 

    /// <summary>
    /// Fizyoterapi Tedavi Odaları Gridi
    /// </summary>
    public  partial class PhysiotherapyTreatmentRoomGrid : TTObject
    {
        public class PhysiotherapyTreatmentRoomGridList : TTObjectCollection<PhysiotherapyTreatmentRoomGrid> { }
                    
        public class ChildPhysiotherapyTreatmentRoomGridCollection : TTObject.TTChildObjectCollection<PhysiotherapyTreatmentRoomGrid>
        {
            public ChildPhysiotherapyTreatmentRoomGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhysiotherapyTreatmentRoomGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tedavi Odası
    /// </summary>
        public ResTreatmentDiagnosisRoom TreatmentRoom
        {
            get { return (ResTreatmentDiagnosisRoom)((ITTObject)this).GetParent("TREATMENTROOM"); }
            set { this["TREATMENTROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tedavi Odaları
    /// </summary>
        public PhysiotherapyDefinition PhysiotherapyDefinition
        {
            get { return (PhysiotherapyDefinition)((ITTObject)this).GetParent("PHYSIOTHERAPYDEFINITION"); }
            set { this["PHYSIOTHERAPYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PhysiotherapyTreatmentRoomGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PhysiotherapyTreatmentRoomGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PhysiotherapyTreatmentRoomGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PhysiotherapyTreatmentRoomGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PhysiotherapyTreatmentRoomGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHYSIOTHERAPYTREATMENTROOMGRID", dataRow) { }
        protected PhysiotherapyTreatmentRoomGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHYSIOTHERAPYTREATMENTROOMGRID", dataRow, isImported) { }
        public PhysiotherapyTreatmentRoomGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PhysiotherapyTreatmentRoomGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PhysiotherapyTreatmentRoomGrid() : base() { }

    }
}