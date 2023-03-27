
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TemplateGroup")] 

    public  partial class TemplateGroup : TTObject
    {
        public class TemplateGroupList : TTObjectCollection<TemplateGroup> { }
                    
        public class ChildTemplateGroupCollection : TTObject.TTChildObjectCollection<TemplateGroup>
        {
            public ChildTemplateGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTemplateGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<TemplateGroup> GetTemplateGroup(TTObjectContext objectContext, string GROUPNAMEPARAMETER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEMPLATEGROUP"].QueryDefs["GetTemplateGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("GROUPNAMEPARAMETER", GROUPNAMEPARAMETER);

            return ((ITTQuery)objectContext).QueryObjects<TemplateGroup>(queryDef, paramList);
        }

    /// <summary>
    /// Eski Sistemdeki Grup Adı 
    /// </summary>
        public string OldGroupName
        {
            get { return (string)this["OLDGROUPNAME"]; }
            set { this["OLDGROUPNAME"] = value; }
        }

    /// <summary>
    /// Group Adı
    /// </summary>
        public string GroupName
        {
            get { return (string)this["GROUPNAME"]; }
            set { this["GROUPNAME"] = value; }
        }

        public string GroupName_Shadow
        {
            get { return (string)this["GROUPNAME_SHADOW"]; }
        }

        protected TemplateGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TemplateGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TemplateGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TemplateGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TemplateGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TEMPLATEGROUP", dataRow) { }
        protected TemplateGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TEMPLATEGROUP", dataRow, isImported) { }
        public TemplateGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TemplateGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TemplateGroup() : base() { }

    }
}