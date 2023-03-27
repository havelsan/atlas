
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserOptionGroup")] 

    public  partial class UserOptionGroup : TTDefinitionSet
    {
        public class UserOptionGroupList : TTObjectCollection<UserOptionGroup> { }
                    
        public class ChildUserOptionGroupCollection : TTObject.TTChildObjectCollection<UserOptionGroup>
        {
            public ChildUserOptionGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserOptionGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<UserOptionGroup> GetUserOptionGroups(TTObjectContext objectContext, UserOptionGroupType UserOptionGroupType)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USEROPTIONGROUP"].QueryDefs["GetUserOptionGroups"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USEROPTIONGROUPTYPE", (int)UserOptionGroupType);

            return ((ITTQuery)objectContext).QueryObjects<UserOptionGroup>(queryDef, paramList);
        }

        public UserOptionType? UserOptionType
        {
            get { return (UserOptionType?)(int?)this["USEROPTIONTYPE"]; }
            set { this["USEROPTIONTYPE"] = value; }
        }

        public UserOptionGroupType? UserOptionGroupType
        {
            get { return (UserOptionGroupType?)(int?)this["USEROPTIONGROUPTYPE"]; }
            set { this["USEROPTIONGROUPTYPE"] = value; }
        }

        protected UserOptionGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserOptionGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserOptionGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserOptionGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserOptionGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USEROPTIONGROUP", dataRow) { }
        protected UserOptionGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USEROPTIONGROUP", dataRow, isImported) { }
        public UserOptionGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserOptionGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserOptionGroup() : base() { }

    }
}