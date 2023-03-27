
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserMessageGroupDefinition")] 

    /// <summary>
    /// Kullanıcı Grupları
    /// </summary>
    public  partial class UserMessageGroupDefinition : TTDefinitionSet
    {
        public class UserMessageGroupDefinitionList : TTObjectCollection<UserMessageGroupDefinition> { }
                    
        public class ChildUserMessageGroupDefinitionCollection : TTObject.TTChildObjectCollection<UserMessageGroupDefinition>
        {
            public ChildUserMessageGroupDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserMessageGroupDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUserMessageGroupDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Caption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GroupClassType? ClassType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLASSTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].AllPropertyDefs["CLASSTYPE"].DataType;
                    return (GroupClassType?)(int)dataType.ConvertValue(val);
                }
            }

            public string Condition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONDITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].AllPropertyDefs["CONDITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUserMessageGroupDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserMessageGroupDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserMessageGroupDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllMessageGroupDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Caption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GroupClassType? ClassType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLASSTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].AllPropertyDefs["CLASSTYPE"].DataType;
                    return (GroupClassType?)(int)dataType.ConvertValue(val);
                }
            }

            public string Condition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONDITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].AllPropertyDefs["CONDITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAllMessageGroupDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllMessageGroupDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllMessageGroupDef_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUserMessageGroupList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Caption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUserMessageGroupList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserMessageGroupList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserMessageGroupList_Class() : base() { }
        }

        public static BindingList<UserMessageGroupDefinition.GetUserMessageGroupDefinition_Class> GetUserMessageGroupDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].QueryDefs["GetUserMessageGroupDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UserMessageGroupDefinition.GetUserMessageGroupDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<UserMessageGroupDefinition.GetUserMessageGroupDefinition_Class> GetUserMessageGroupDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].QueryDefs["GetUserMessageGroupDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UserMessageGroupDefinition.GetUserMessageGroupDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<UserMessageGroupDefinition.GetAllMessageGroupDef_Class> GetAllMessageGroupDef(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].QueryDefs["GetAllMessageGroupDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UserMessageGroupDefinition.GetAllMessageGroupDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserMessageGroupDefinition.GetAllMessageGroupDef_Class> GetAllMessageGroupDef(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].QueryDefs["GetAllMessageGroupDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UserMessageGroupDefinition.GetAllMessageGroupDef_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UserMessageGroupDefinition> GetAllMessageGroupDefinition(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].QueryDefs["GetAllMessageGroupDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<UserMessageGroupDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<UserMessageGroupDefinition.GetUserMessageGroupList_Class> GetUserMessageGroupList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].QueryDefs["GetUserMessageGroupList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UserMessageGroupDefinition.GetUserMessageGroupList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<UserMessageGroupDefinition.GetUserMessageGroupList_Class> GetUserMessageGroupList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].QueryDefs["GetUserMessageGroupList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UserMessageGroupDefinition.GetUserMessageGroupList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Başlık
    /// </summary>
        public string Caption
        {
            get { return (string)this["CAPTION"]; }
            set { this["CAPTION"] = value; }
        }

    /// <summary>
    /// Tipi
    /// </summary>
        public GroupClassType? ClassType
        {
            get { return (GroupClassType?)(int?)this["CLASSTYPE"]; }
            set { this["CLASSTYPE"] = value; }
        }

    /// <summary>
    /// SQL Condition
    /// </summary>
        public string Condition
        {
            get { return (string)this["CONDITION"]; }
            set { this["CONDITION"] = value; }
        }

        virtual protected void CreateUserMessageGroupUsersCollection()
        {
            _UserMessageGroupUsers = new UserMessageGroupUsers.ChildUserMessageGroupUsersCollection(this, new Guid("de6a3a6d-d005-430c-86af-077aafc6c279"));
            ((ITTChildObjectCollection)_UserMessageGroupUsers).GetChildren();
        }

        protected UserMessageGroupUsers.ChildUserMessageGroupUsersCollection _UserMessageGroupUsers = null;
    /// <summary>
    /// Child collection for Kullanıcı Mesaj Grubu
    /// </summary>
        public UserMessageGroupUsers.ChildUserMessageGroupUsersCollection UserMessageGroupUsers
        {
            get
            {
                if (_UserMessageGroupUsers == null)
                    CreateUserMessageGroupUsersCollection();
                return _UserMessageGroupUsers;
            }
        }

        protected UserMessageGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserMessageGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserMessageGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserMessageGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserMessageGroupDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USERMESSAGEGROUPDEFINITION", dataRow) { }
        protected UserMessageGroupDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USERMESSAGEGROUPDEFINITION", dataRow, isImported) { }
        public UserMessageGroupDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserMessageGroupDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserMessageGroupDefinition() : base() { }

    }
}