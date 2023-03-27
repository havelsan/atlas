
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserTitleDefinition")] 

    public  partial class UserTitleDefinition : TTDefinitionSet
    {
        public class UserTitleDefinitionList : TTObjectCollection<UserTitleDefinition> { }
                    
        public class ChildUserTitleDefinitionCollection : TTObject.TTChildObjectCollection<UserTitleDefinition>
        {
            public ChildUserTitleDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserTitleDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<UserTitleDefinition> GetByCode(TTObjectContext objectContext, int Code)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERTITLEDEFINITION"].QueryDefs["GetByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", Code);

            return ((ITTQuery)objectContext).QueryObjects<UserTitleDefinition>(queryDef, paramList);
        }

        public static BindingList<UserTitleDefinition> GetAllUserTitle(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERTITLEDEFINITION"].QueryDefs["GetAllUserTitle"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<UserTitleDefinition>(queryDef, paramList, injectionSQL);
        }

        public string DisplayText
        {
            get { return (string)this["DISPLAYTEXT"]; }
            set { this["DISPLAYTEXT"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        protected UserTitleDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserTitleDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserTitleDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserTitleDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserTitleDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USERTITLEDEFINITION", dataRow) { }
        protected UserTitleDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USERTITLEDEFINITION", dataRow, isImported) { }
        public UserTitleDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserTitleDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserTitleDefinition() : base() { }

    }
}