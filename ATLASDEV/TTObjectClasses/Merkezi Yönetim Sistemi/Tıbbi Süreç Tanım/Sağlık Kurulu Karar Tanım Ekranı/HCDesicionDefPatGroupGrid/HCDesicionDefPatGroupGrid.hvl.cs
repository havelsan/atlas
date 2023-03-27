
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCDesicionDefPatGroupGrid")] 

    public  partial class HCDesicionDefPatGroupGrid : TTObject
    {
        public class HCDesicionDefPatGroupGridList : TTObjectCollection<HCDesicionDefPatGroupGrid> { }
                    
        public class ChildHCDesicionDefPatGroupGridCollection : TTObject.TTChildObjectCollection<HCDesicionDefPatGroupGrid>
        {
            public ChildHCDesicionDefPatGroupGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCDesicionDefPatGroupGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<HCDesicionDefPatGroupGrid> GetHCDesicionDefPatGroup(TTObjectContext objectContext, PatientGroupEnum PATIENTGROUPENUM)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCDESICIONDEFPATGROUPGRID"].QueryDefs["GetHCDesicionDefPatGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTGROUPENUM", (int)PATIENTGROUPENUM);

            return ((ITTQuery)objectContext).QueryObjects<HCDesicionDefPatGroupGrid>(queryDef, paramList);
        }

        public PatientGroupDefinition PatientGroup
        {
            get { return (PatientGroupDefinition)((ITTObject)this).GetParent("PATIENTGROUP"); }
            set { this["PATIENTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta Grubu
    /// </summary>
        public HealthCommitteeDecisionDefinition HealthCommittee
        {
            get { return (HealthCommitteeDecisionDefinition)((ITTObject)this).GetParent("HEALTHCOMMITTEE"); }
            set { this["HEALTHCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCDesicionDefPatGroupGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCDesicionDefPatGroupGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCDesicionDefPatGroupGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCDesicionDefPatGroupGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCDesicionDefPatGroupGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCDESICIONDEFPATGROUPGRID", dataRow) { }
        protected HCDesicionDefPatGroupGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCDESICIONDEFPATGROUPGRID", dataRow, isImported) { }
        public HCDesicionDefPatGroupGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCDesicionDefPatGroupGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCDesicionDefPatGroupGrid() : base() { }

    }
}