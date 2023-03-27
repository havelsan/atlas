
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SpecialPanelCriteriaValue")] 

    public  partial class SpecialPanelCriteriaValue : TTObject
    {
        public class SpecialPanelCriteriaValueList : TTObjectCollection<SpecialPanelCriteriaValue> { }
                    
        public class ChildSpecialPanelCriteriaValueCollection : TTObject.TTChildObjectCollection<SpecialPanelCriteriaValue>
        {
            public ChildSpecialPanelCriteriaValueCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSpecialPanelCriteriaValueCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<SpecialPanelCriteriaValue> GetSPCriteriaValueByParent(TTObjectContext objectContext, string SPECIALPANEL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALPANELCRITERIAVALUE"].QueryDefs["GetSPCriteriaValueByParent"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPECIALPANEL", SPECIALPANEL);

            return ((ITTQuery)objectContext).QueryObjects<SpecialPanelCriteriaValue>(queryDef, paramList);
        }

        public string Value
        {
            get { return (string)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public SpecialPanelDefinition SpecialPanel
        {
            get { return (SpecialPanelDefinition)((ITTObject)this).GetParent("SPECIALPANEL"); }
            set { this["SPECIALPANEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SpecialPanelCriteriaValue(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SpecialPanelCriteriaValue(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SpecialPanelCriteriaValue(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SpecialPanelCriteriaValue(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SpecialPanelCriteriaValue(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPECIALPANELCRITERIAVALUE", dataRow) { }
        protected SpecialPanelCriteriaValue(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPECIALPANELCRITERIAVALUE", dataRow, isImported) { }
        public SpecialPanelCriteriaValue(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SpecialPanelCriteriaValue(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SpecialPanelCriteriaValue() : base() { }

    }
}