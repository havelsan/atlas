
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserResource")] 

    public  partial class UserResource : TTObject
    {
        public class UserResourceList : TTObjectCollection<UserResource> { }
                    
        public class ChildUserResourceCollection : TTObject.TTChildObjectCollection<UserResource>
        {
            public ChildUserResourceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserResourceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUserResourceNames_Class : TTReportNqlObject 
        {
            public Guid? Resourceid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOURCEID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public GetUserResourceNames_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserResourceNames_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserResourceNames_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUserResourcesByResource_Class : TTReportNqlObject 
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

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTypeEnum? UserType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["USERTYPE"].DataType;
                    return (UserTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Userobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["USEROBJECTID"]);
                }
            }

            public GetUserResourcesByResource_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserResourcesByResource_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserResourcesByResource_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUserResourceByUser_Class : TTReportNqlObject 
        {
            public string Resourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Resourceobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOURCEOBJECTID"]);
                }
            }

            public GetUserResourceByUser_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserResourceByUser_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserResourceByUser_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUserReourcesByUserDist_Class : TTReportNqlObject 
        {
            public Guid? Resourceid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOURCEID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public GetUserReourcesByUserDist_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserReourcesByUserDist_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserReourcesByUserDist_Class() : base() { }
        }

        public static BindingList<UserResource> GetUserResource(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERRESOURCE"].QueryDefs["GetUserResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<UserResource>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<UserResource> GetByUser(TTObjectContext objectContext, Guid USER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERRESOURCE"].QueryDefs["GetByUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return ((ITTQuery)objectContext).QueryObjects<UserResource>(queryDef, paramList);
        }

        public static BindingList<UserResource.GetUserResourceNames_Class> GetUserResourceNames(Guid USEROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERRESOURCE"].QueryDefs["GetUserResourceNames"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USEROBJECTID", USEROBJECTID);

            return TTReportNqlObject.QueryObjects<UserResource.GetUserResourceNames_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserResource.GetUserResourceNames_Class> GetUserResourceNames(TTObjectContext objectContext, Guid USEROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERRESOURCE"].QueryDefs["GetUserResourceNames"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USEROBJECTID", USEROBJECTID);

            return TTReportNqlObject.QueryObjects<UserResource.GetUserResourceNames_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UserResource.GetUserResourcesByResource_Class> GetUserResourcesByResource(Guid RESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERRESOURCE"].QueryDefs["GetUserResourcesByResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCE", RESOURCE);

            return TTReportNqlObject.QueryObjects<UserResource.GetUserResourcesByResource_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserResource.GetUserResourcesByResource_Class> GetUserResourcesByResource(TTObjectContext objectContext, Guid RESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERRESOURCE"].QueryDefs["GetUserResourcesByResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCE", RESOURCE);

            return TTReportNqlObject.QueryObjects<UserResource.GetUserResourcesByResource_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UserResource.GetUserResourceByUser_Class> GetUserResourceByUser(Guid USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERRESOURCE"].QueryDefs["GetUserResourceByUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<UserResource.GetUserResourceByUser_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserResource.GetUserResourceByUser_Class> GetUserResourceByUser(TTObjectContext objectContext, Guid USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERRESOURCE"].QueryDefs["GetUserResourceByUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<UserResource.GetUserResourceByUser_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UserResource> GetByResource(TTObjectContext objectContext, Guid RESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERRESOURCE"].QueryDefs["GetByResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<UserResource>(queryDef, paramList);
        }

        public static BindingList<UserResource> GetByUserAndResource(TTObjectContext objectContext, Guid USER, Guid RESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERRESOURCE"].QueryDefs["GetByUserAndResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<UserResource>(queryDef, paramList);
        }

        public static BindingList<UserResource.GetUserReourcesByUserDist_Class> GetUserReourcesByUserDist(Guid USEROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERRESOURCE"].QueryDefs["GetUserReourcesByUserDist"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USEROBJECTID", USEROBJECTID);

            return TTReportNqlObject.QueryObjects<UserResource.GetUserReourcesByUserDist_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserResource.GetUserReourcesByUserDist_Class> GetUserReourcesByUserDist(TTObjectContext objectContext, Guid USEROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERRESOURCE"].QueryDefs["GetUserReourcesByUserDist"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USEROBJECTID", USEROBJECTID);

            return TTReportNqlObject.QueryObjects<UserResource.GetUserReourcesByUserDist_Class>(objectContext, queryDef, paramList, pi);
        }

        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection Resource
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UserResource(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserResource(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserResource(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserResource(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserResource(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USERRESOURCE", dataRow) { }
        protected UserResource(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USERRESOURCE", dataRow, isImported) { }
        public UserResource(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserResource(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserResource() : base() { }

    }
}