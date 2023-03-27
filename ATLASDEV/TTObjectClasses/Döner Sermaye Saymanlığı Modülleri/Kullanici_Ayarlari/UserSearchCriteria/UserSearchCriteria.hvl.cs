
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserSearchCriteria")] 

    public  partial class UserSearchCriteria : TTObject
    {
        public class UserSearchCriteriaList : TTObjectCollection<UserSearchCriteria> { }
                    
        public class ChildUserSearchCriteriaCollection : TTObject.TTChildObjectCollection<UserSearchCriteria>
        {
            public ChildUserSearchCriteriaCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserSearchCriteriaCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUserSearchCriteria_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERSEARCHCRITERIA"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PageName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAGENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERSEARCHCRITERIA"].AllPropertyDefs["PAGENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsDefault
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDEFAULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERSEARCHCRITERIA"].AllPropertyDefs["ISDEFAULT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetUserSearchCriteria_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserSearchCriteria_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserSearchCriteria_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("0aa7acb6-bd1c-46c4-ab51-79747e041e0a"); } }
    /// <summary>
    /// Kullanımda
    /// </summary>
            public static Guid InUse { get { return new Guid("bd265de9-9b50-4d8b-b55e-cc17648e7323"); } }
        }

    /// <summary>
    /// Kullanıcı Sorgu Kriterleri (Value olmadan)
    /// </summary>
        public static BindingList<UserSearchCriteria.GetUserSearchCriteria_Class> GetUserSearchCriteria(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERSEARCHCRITERIA"].QueryDefs["GetUserSearchCriteria"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UserSearchCriteria.GetUserSearchCriteria_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kullanıcı Sorgu Kriterleri (Value olmadan)
    /// </summary>
        public static BindingList<UserSearchCriteria.GetUserSearchCriteria_Class> GetUserSearchCriteria(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERSEARCHCRITERIA"].QueryDefs["GetUserSearchCriteria"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UserSearchCriteria.GetUserSearchCriteria_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Arama Kriteri Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Arama modeli json
    /// </summary>
        public string Value
        {
            get { return (string)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        public bool? IsDefault
        {
            get { return (bool?)this["ISDEFAULT"]; }
            set { this["ISDEFAULT"] = value; }
        }

    /// <summary>
    /// Sayfa Adı
    /// </summary>
        public string PageName
        {
            get { return (string)this["PAGENAME"]; }
            set { this["PAGENAME"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UserSearchCriteria(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserSearchCriteria(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserSearchCriteria(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserSearchCriteria(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserSearchCriteria(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USERSEARCHCRITERIA", dataRow) { }
        protected UserSearchCriteria(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USERSEARCHCRITERIA", dataRow, isImported) { }
        public UserSearchCriteria(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserSearchCriteria(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserSearchCriteria() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}