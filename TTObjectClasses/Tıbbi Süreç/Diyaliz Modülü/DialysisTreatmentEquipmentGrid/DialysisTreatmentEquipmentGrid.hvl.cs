
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DialysisTreatmentEquipmentGrid")] 

    /// <summary>
    /// Diyaliz Tedavi Cihazları
    /// </summary>
    public  partial class DialysisTreatmentEquipmentGrid : TTObject
    {
        public class DialysisTreatmentEquipmentGridList : TTObjectCollection<DialysisTreatmentEquipmentGrid> { }
                    
        public class ChildDialysisTreatmentEquipmentGridCollection : TTObject.TTChildObjectCollection<DialysisTreatmentEquipmentGrid>
        {
            public ChildDialysisTreatmentEquipmentGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDialysisTreatmentEquipmentGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tedavi Cihazı
    /// </summary>
        public ResEquipment TreatmentEquipment
        {
            get { return (ResEquipment)((ITTObject)this).GetParent("TREATMENTEQUIPMENT"); }
            set { this["TREATMENTEQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tedavi Cihazı
    /// </summary>
        public DialysisDefinition DialysisDefinition
        {
            get { return (DialysisDefinition)((ITTObject)this).GetParent("DIALYSISDEFINITION"); }
            set { this["DIALYSISDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DialysisTreatmentEquipmentGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DialysisTreatmentEquipmentGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DialysisTreatmentEquipmentGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DialysisTreatmentEquipmentGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DialysisTreatmentEquipmentGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIALYSISTREATMENTEQUIPMENTGRID", dataRow) { }
        protected DialysisTreatmentEquipmentGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIALYSISTREATMENTEQUIPMENTGRID", dataRow, isImported) { }
        protected DialysisTreatmentEquipmentGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DialysisTreatmentEquipmentGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DialysisTreatmentEquipmentGrid() : base() { }

    }
}