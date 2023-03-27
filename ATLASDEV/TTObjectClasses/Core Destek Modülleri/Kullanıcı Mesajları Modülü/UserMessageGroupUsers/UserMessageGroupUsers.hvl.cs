
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserMessageGroupUsers")] 

    /// <summary>
    /// Kullanıcı Mesaj Grubu Kullanıcıları
    /// </summary>
    public  partial class UserMessageGroupUsers : TTObject
    {
        public class UserMessageGroupUsersList : TTObjectCollection<UserMessageGroupUsers> { }
                    
        public class ChildUserMessageGroupUsersCollection : TTObject.TTChildObjectCollection<UserMessageGroupUsers>
        {
            public ChildUserMessageGroupUsersCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserMessageGroupUsersCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<UserMessageGroupUsers> GetUserMessageGroupUsers(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPUSERS"].QueryDefs["GetUserMessageGroupUsers"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<UserMessageGroupUsers>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Kullanıcı Mesaj Grubu
    /// </summary>
        public UserMessageGroupDefinition UserMessageGroupDefinition
        {
            get { return (UserMessageGroupDefinition)((ITTObject)this).GetParent("USERMESSAGEGROUPDEFINITION"); }
            set { this["USERMESSAGEGROUPDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kullanıcı Mesaj Grubu Kullanıcıları
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UserMessageGroupUsers(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserMessageGroupUsers(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserMessageGroupUsers(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserMessageGroupUsers(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserMessageGroupUsers(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USERMESSAGEGROUPUSERS", dataRow) { }
        protected UserMessageGroupUsers(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USERMESSAGEGROUPUSERS", dataRow, isImported) { }
        public UserMessageGroupUsers(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserMessageGroupUsers(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserMessageGroupUsers() : base() { }

    }
}