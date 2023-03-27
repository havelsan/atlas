
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyGridEquipmentDefinition")] 

    public  partial class RadiologyGridEquipmentDefinition : TTDefinitionSet
    {
        public class RadiologyGridEquipmentDefinitionList : TTObjectCollection<RadiologyGridEquipmentDefinition> { }
                    
        public class ChildRadiologyGridEquipmentDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyGridEquipmentDefinition>
        {
            public ChildRadiologyGridEquipmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyGridEquipmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<RadiologyGridEquipmentDefinition> GetRadGridEquipments(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYGRIDEQUIPMENTDEFINITION"].QueryDefs["GetRadGridEquipments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RadiologyGridEquipmentDefinition>(queryDef, paramList, injectionSQL);
        }

        public ResRadiologyEquipment Equipment
        {
            get { return (ResRadiologyEquipment)((ITTObject)this).GetParent("EQUIPMENT"); }
            set { this["EQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RadiologyTestDefinition RadiologyTest
        {
            get { return (RadiologyTestDefinition)((ITTObject)this).GetParent("RADIOLOGYTEST"); }
            set { this["RADIOLOGYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RadiologyGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyGridEquipmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyGridEquipmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYGRIDEQUIPMENTDEFINITION", dataRow) { }
        protected RadiologyGridEquipmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYGRIDEQUIPMENTDEFINITION", dataRow, isImported) { }
        public RadiologyGridEquipmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyGridEquipmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyGridEquipmentDefinition() : base() { }

    }
}