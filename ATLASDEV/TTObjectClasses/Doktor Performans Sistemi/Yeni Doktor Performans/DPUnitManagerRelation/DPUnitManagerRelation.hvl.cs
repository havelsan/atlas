
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DPUnitManagerRelation")] 

    public  partial class DPUnitManagerRelation : TTObject
    {
        public class DPUnitManagerRelationList : TTObjectCollection<DPUnitManagerRelation> { }
                    
        public class ChildDPUnitManagerRelationCollection : TTObject.TTChildObjectCollection<DPUnitManagerRelation>
        {
            public ChildDPUnitManagerRelationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDPUnitManagerRelationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// GetByUnitManager
    /// </summary>
        public static BindingList<DPUnitManagerRelation> GetByUnitManager(TTObjectContext objectContext, Guid UNITMANAGER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPUNITMANAGERRELATION"].QueryDefs["GetByUnitManager"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNITMANAGER", UNITMANAGER);

            return ((ITTQuery)objectContext).QueryObjects<DPUnitManagerRelation>(queryDef, paramList);
        }

        public Guid? TTUserUnitManager
        {
            get { return (Guid?)this["TTUSERUNITMANAGER"]; }
            set { this["TTUSERUNITMANAGER"] = value; }
        }

        public ResUser RelatedUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RELATEDUSER"); }
            set { this["RELATEDUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DPUnitManagerRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DPUnitManagerRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DPUnitManagerRelation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DPUnitManagerRelation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DPUnitManagerRelation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPUNITMANAGERRELATION", dataRow) { }
        protected DPUnitManagerRelation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPUNITMANAGERRELATION", dataRow, isImported) { }
        public DPUnitManagerRelation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DPUnitManagerRelation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DPUnitManagerRelation() : base() { }

    }
}