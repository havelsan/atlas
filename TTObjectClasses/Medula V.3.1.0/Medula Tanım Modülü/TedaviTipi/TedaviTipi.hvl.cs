
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TedaviTipi")] 

    /// <summary>
    /// Tedavi Tipi
    /// </summary>
    public  partial class TedaviTipi : BaseMedulaDefinition
    {
        public class TedaviTipiList : TTObjectCollection<TedaviTipi> { }
                    
        public class ChildTedaviTipiCollection : TTObject.TTChildObjectCollection<TedaviTipi>
        {
            public ChildTedaviTipiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTedaviTipiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTedaviTipiNql_Class : TTReportNqlObject 
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

            public string tedaviTipiAdi_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITIPIADI_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITIPI"].AllPropertyDefs["TEDAVITIPIADI_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tedaviTipiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITIPI"].AllPropertyDefs["TEDAVITIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tedaviTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITIPI"].AllPropertyDefs["TEDAVITIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTedaviTipiNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTedaviTipiNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTedaviTipiNql_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTedaviTipiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string tedaviTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITIPI"].AllPropertyDefs["TEDAVITIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tedaviTipiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITIPI"].AllPropertyDefs["TEDAVITIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTedaviTipiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTedaviTipiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTedaviTipiDefinitionQuery_Class() : base() { }
        }

        public static BindingList<TedaviTipi> GetTedaviTipiByTedaviTipiKodu(TTObjectContext objectContext, string TEDAVITIPIKODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVITIPI"].QueryDefs["GetTedaviTipiByTedaviTipiKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TEDAVITIPIKODU", TEDAVITIPIKODU);

            return ((ITTQuery)objectContext).QueryObjects<TedaviTipi>(queryDef, paramList);
        }

        public static BindingList<TedaviTipi.GetTedaviTipiNql_Class> GetTedaviTipiNql(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVITIPI"].QueryDefs["GetTedaviTipiNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TedaviTipi.GetTedaviTipiNql_Class>(queryDef, paramList, pi);
        }

        public static BindingList<TedaviTipi.GetTedaviTipiNql_Class> GetTedaviTipiNql(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVITIPI"].QueryDefs["GetTedaviTipiNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TedaviTipi.GetTedaviTipiNql_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<TedaviTipi.GetTedaviTipiDefinitionQuery_Class> GetTedaviTipiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVITIPI"].QueryDefs["GetTedaviTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TedaviTipi.GetTedaviTipiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TedaviTipi.GetTedaviTipiDefinitionQuery_Class> GetTedaviTipiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVITIPI"].QueryDefs["GetTedaviTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TedaviTipi.GetTedaviTipiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string tedaviTipiAdi_Shadow
        {
            get { return (string)this["TEDAVITIPIADI_SHADOW"]; }
        }

    /// <summary>
    /// Tedavi Tipi Adı
    /// </summary>
        public string tedaviTipiAdi
        {
            get { return (string)this["TEDAVITIPIADI"]; }
            set { this["TEDAVITIPIADI"] = value; }
        }

    /// <summary>
    /// Tedavi Tipi Kodu
    /// </summary>
        public string tedaviTipiKodu
        {
            get { return (string)this["TEDAVITIPIKODU"]; }
            set { this["TEDAVITIPIKODU"] = value; }
        }

        protected TedaviTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TedaviTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TedaviTipi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TedaviTipi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TedaviTipi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TEDAVITIPI", dataRow) { }
        protected TedaviTipi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TEDAVITIPI", dataRow, isImported) { }
        public TedaviTipi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TedaviTipi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TedaviTipi() : base() { }

    }
}