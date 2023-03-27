
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserTemplate")] 

    /// <summary>
    /// Kullanıcı Şablonları
    /// </summary>
    public  partial class UserTemplate : TTObject
    {
        public class UserTemplateList : TTObjectCollection<UserTemplate> { }
                    
        public class ChildUserTemplateCollection : TTObject.TTChildObjectCollection<UserTemplate>
        {
            public ChildUserTemplateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserTemplateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUserTemplate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERTEMPLATE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? TAObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TAOBJECTID"]);
                }
            }

            public Guid? TAObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TAOBJECTDEFID"]);
                }
            }

            public GetUserTemplate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserTemplate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserTemplate_Class() : base() { }
        }

        public static BindingList<UserTemplate.GetUserTemplate_Class> GetUserTemplate(Guid RESUSERID, Guid TAOBJECTDEFID, string FILITERDATA, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERTEMPLATE"].QueryDefs["GetUserTemplate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSERID", RESUSERID);
            paramList.Add("TAOBJECTDEFID", TAOBJECTDEFID);
            paramList.Add("FILITERDATA", FILITERDATA);

            return TTReportNqlObject.QueryObjects<UserTemplate.GetUserTemplate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserTemplate.GetUserTemplate_Class> GetUserTemplate(TTObjectContext objectContext, Guid RESUSERID, Guid TAOBJECTDEFID, string FILITERDATA, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERTEMPLATE"].QueryDefs["GetUserTemplate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSERID", RESUSERID);
            paramList.Add("TAOBJECTDEFID", TAOBJECTDEFID);
            paramList.Add("FILITERDATA", FILITERDATA);

            return TTReportNqlObject.QueryObjects<UserTemplate.GetUserTemplate_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Template Action ObjectID
    /// </summary>
        public Guid? TAObjectID
        {
            get { return (Guid?)this["TAOBJECTID"]; }
            set { this["TAOBJECTID"] = value; }
        }

    /// <summary>
    /// Template Action ObjectDefID
    /// </summary>
        public Guid? TAObjectDefID
        {
            get { return (Guid?)this["TAOBJECTDEFID"]; }
            set { this["TAOBJECTDEFID"] = value; }
        }

    /// <summary>
    /// Filitre Data
    /// </summary>
        public string FiliterData
        {
            get { return (string)this["FILITERDATA"]; }
            set { this["FILITERDATA"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UserTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserTemplate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USERTEMPLATE", dataRow) { }
        protected UserTemplate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USERTEMPLATE", dataRow, isImported) { }
        public UserTemplate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserTemplate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserTemplate() : base() { }

    }
}