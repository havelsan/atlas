
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaSavedQueries")] 

    /// <summary>
    /// Kullanıcı Sorguları
    /// </summary>
    public  partial class MedulaSavedQueries : TTObject
    {
        public class MedulaSavedQueriesList : TTObjectCollection<MedulaSavedQueries> { }
                    
        public class ChildMedulaSavedQueriesCollection : TTObject.TTChildObjectCollection<MedulaSavedQueries>
        {
            public ChildMedulaSavedQueriesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaSavedQueriesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetQueryByName_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Value
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULASAVEDQUERIES"].AllPropertyDefs["VALUE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetQueryByName_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetQueryByName_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetQueryByName_Class() : base() { }
        }

        [Serializable] 

        public partial class GellAllQueriesByUserName_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULASAVEDQUERIES"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GellAllQueriesByUserName_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GellAllQueriesByUserName_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GellAllQueriesByUserName_Class() : base() { }
        }

    /// <summary>
    /// İsim ile kaydedilmiş sorgu bulmak
    /// </summary>
        public static BindingList<MedulaSavedQueries.GetQueryByName_Class> GetQueryByName(string NAME, string RESUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULASAVEDQUERIES"].QueryDefs["GetQueryByName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NAME", NAME);
            paramList.Add("RESUSER", RESUSER);

            return TTReportNqlObject.QueryObjects<MedulaSavedQueries.GetQueryByName_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// İsim ile kaydedilmiş sorgu bulmak
    /// </summary>
        public static BindingList<MedulaSavedQueries.GetQueryByName_Class> GetQueryByName(TTObjectContext objectContext, string NAME, string RESUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULASAVEDQUERIES"].QueryDefs["GetQueryByName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NAME", NAME);
            paramList.Add("RESUSER", RESUSER);

            return TTReportNqlObject.QueryObjects<MedulaSavedQueries.GetQueryByName_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MedulaSavedQueries.GellAllQueriesByUserName_Class> GellAllQueriesByUserName(string RESUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULASAVEDQUERIES"].QueryDefs["GellAllQueriesByUserName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);

            return TTReportNqlObject.QueryObjects<MedulaSavedQueries.GellAllQueriesByUserName_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedulaSavedQueries.GellAllQueriesByUserName_Class> GellAllQueriesByUserName(TTObjectContext objectContext, string RESUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULASAVEDQUERIES"].QueryDefs["GellAllQueriesByUserName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);

            return TTReportNqlObject.QueryObjects<MedulaSavedQueries.GellAllQueriesByUserName_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sorgu Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Kaydedilen Kriterler
    /// </summary>
        public string Value
        {
            get { return (string)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

    /// <summary>
    /// Aktif Mi
    /// </summary>
        public bool? IsActive
        {
            get { return (bool?)this["ISACTIVE"]; }
            set { this["ISACTIVE"] = value; }
        }

    /// <summary>
    /// Kullanıcı
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaSavedQueries(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaSavedQueries(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaSavedQueries(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaSavedQueries(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaSavedQueries(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULASAVEDQUERIES", dataRow) { }
        protected MedulaSavedQueries(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULASAVEDQUERIES", dataRow, isImported) { }
        public MedulaSavedQueries(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaSavedQueries(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaSavedQueries() : base() { }

    }
}