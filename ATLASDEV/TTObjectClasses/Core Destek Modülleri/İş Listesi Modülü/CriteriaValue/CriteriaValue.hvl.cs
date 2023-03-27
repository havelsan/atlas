
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CriteriaValue")] 

    public  partial class CriteriaValue : TTObject
    {
        public class CriteriaValueList : TTObjectCollection<CriteriaValue> { }
                    
        public class ChildCriteriaValueCollection : TTObject.TTChildObjectCollection<CriteriaValue>
        {
            public ChildCriteriaValueCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCriteriaValueCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<CriteriaValue> GetCriteriaValuesBySpecialPanel(TTObjectContext objectContext, string SPECIALPANEL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CRITERIAVALUE"].QueryDefs["GetCriteriaValuesBySpecialPanel"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPECIALPANEL", SPECIALPANEL);

            return ((ITTQuery)objectContext).QueryObjects<CriteriaValue>(queryDef, paramList);
        }

        public static BindingList<CriteriaValue> GetCriteriaValuesBySpecialPanelAndUser(TTObjectContext objectContext, string SPECIALPANEL, string USER, string CRITERIADEF)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CRITERIAVALUE"].QueryDefs["GetCriteriaValuesBySpecialPanelAndUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPECIALPANEL", SPECIALPANEL);
            paramList.Add("USER", USER);
            paramList.Add("CRITERIADEF", CRITERIADEF);

            return ((ITTQuery)objectContext).QueryObjects<CriteriaValue>(queryDef, paramList);
        }

        public string Value
        {
            get { return (string)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        public CriteriaDefinition PCriteriaValue
        {
            get { return (CriteriaDefinition)((ITTObject)this).GetParent("PCRITERIAVALUE"); }
            set { this["PCRITERIAVALUE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialPanelDefinition SpecialPanel
        {
            get { return (SpecialPanelDefinition)((ITTObject)this).GetParent("SPECIALPANEL"); }
            set { this["SPECIALPANEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CriteriaValue(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CriteriaValue(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CriteriaValue(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CriteriaValue(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CriteriaValue(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CRITERIAVALUE", dataRow) { }
        protected CriteriaValue(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CRITERIAVALUE", dataRow, isImported) { }
        public CriteriaValue(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CriteriaValue(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CriteriaValue() : base() { }

    }
}